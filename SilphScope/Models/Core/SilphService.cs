using SilphScope.Models.Core.Memory;
using SilphScope.Models.Core.Messages;
using SilphScope.Models.Games;
using SilphScope.Models.Games.Parsers.Common;
using SilphScope.Models.Games.Parsers.Gen4;
using SilphScope.Models.Games.State;
using SilphScope.Models.Games.State.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SilphScope.Models.Core
{
    public class SilphService : TracingDisposable
    {
        public delegate void ProcessWatchMessageHandler(SilphService sender, SilphServiceMessage message);
        public event ProcessWatchMessageHandler? OnMessage;

        public SilphState State => _state;

        private volatile SilphState _state = SilphState.Stopped;

        private readonly CancellationTokenSource _cts = new();
        private readonly Lock _lock = new();
        private readonly Thread _thread;
        private int _tickRate = 500;

        private readonly ProcessMemory _processMemory;
        private readonly Game _targetGame;

        private nint _baseAddr;
        private readonly IPartyParser _partyParser;
        private readonly IBoxParser _boxParser;
        private readonly TrainerParser _trainerParser;

        public SilphService(Process process, Game game)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _processMemory = new ProcessMemory(process, new WindowsMemoryAccess());
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                _processMemory = new ProcessMemory(process, new LinuxMemoryAccess());
            }
            else
            {
                throw new PlatformNotSupportedException("SilphScope does not support the current OS.");
            }

            _targetGame = game;
            _trainerParser = new TrainerParser();
            switch (_targetGame.Generation)
            {
                case 4:
                    _partyParser = new Gen4PartyParser();
                    _boxParser = new Gen4BoxParser();
                    break;
                default:
                    throw new PlatformNotSupportedException("Generation not supported");
            }
            _thread = new Thread(ThreadLoop) { IsBackground = true };
        }

        public void SetTickRate(int value)
        {
            _tickRate = value;
        }

        private void SetState(SilphState value)
        {
            lock (_lock)
            {
                if (_state == value) return;
                _state = value;
                OnMessage?.Invoke(this, new SilphStateChangedMessage(_state));
            }
        }

        public void Start()
        {
            if (_thread.IsAlive) return;
            SetState(SilphState.Scanning);
            _thread.Start();
        }

        public void Stop()
        {
            SetState(SilphState.Stopped);
        }

        private void ThreadLoop()
        {
            CancellationToken token = _cts.Token;
            while (!token.IsCancellationRequested)
            {
                // TODO: move this to event?
                if (_processMemory.Process.HasExited)
                {
                    OnMessage?.Invoke(this, new DebugMessage("Target process exited. Stopping service."));
                    Stop();
                    break;
                }
                switch (_state)
                {
                    case SilphState.Scanning:
                        ScanForAnchor();
                        break;
                    case SilphState.Started:
                        OnMessage?.Invoke(this, new GameDetectedMessage(_targetGame));
                        UpdateGameData();
                        break;
                }
                token.WaitHandle.WaitOne(_tickRate);
            }
        }

        private nint GetSaveAddr()
        {
            nint localSaveAddr = BitConverter.ToInt32(_processMemory.Read(_baseAddr + _targetGame.Layout.SavePointer, 4));
            return _targetGame.Layout.GetSaveAddr(_baseAddr, localSaveAddr);
        }

        private void UpdateGameData()
        {
            //try
            //{
            nint saveAddr = GetSaveAddr();
            SilphContext context = new(_targetGame, saveAddr, _processMemory.Read(saveAddr, _targetGame.Layout.SaveSize));
            Trainer trainer = _trainerParser.Parse(context);
            Pkmn[] party = _partyParser.Parse(context);
            Box[] boxes = _boxParser.Parse(context);
            FrameData gameState = new(trainer, [.. party], boxes);
            OnMessage?.Invoke(this, new GameStateUpdateMessage(gameState));
            //}
            //catch (ParserException ex)
            //{
            //    OnMessage?.Invoke(this, new DebugMessage($"Error while reading game data: {ex.Message}"));
            //}
        }

        private void ScanForAnchor()
        {
            List<nint> candidateAddresses = _processMemory.PatternScanAll(_targetGame.Layout.AnchorString); // Find memory signature
            if (candidateAddresses.Count == 0)
            {
                return;
            }

            foreach (nint res in candidateAddresses)
            {
                // TODO: add better sanity check
                /* 
                 * TODO: other games might not rely on a pointer to the save data loaded in RAM. 
                 * Consider just reading entire RAM into a buffer, and pass that to the parsers
                 */
                _baseAddr = res - _targetGame.Layout.Anchor;
                nint localSaveAddr = BitConverter.ToInt32(_processMemory.Read(_baseAddr + _targetGame.Layout.SavePointer, 4));
                if (localSaveAddr >= _targetGame.Layout.RamStart && localSaveAddr <= _targetGame.Layout.RamEnd)
                {
                    SetState(SilphState.Started);
                    break;
                }
            }
            return;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                SetState(SilphState.Stopped);
                _cts.Cancel();
                if (_thread.IsAlive)
                {
                    _thread.Join();
                }
            }
            base.Dispose(disposing);
        }
    }
}
