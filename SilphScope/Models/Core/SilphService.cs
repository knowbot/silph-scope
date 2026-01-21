using SilphScope.Models.Core.Memory;
using SilphScope.Models.Core.Messages;
using SilphScope.Models.Games;
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

        public SilphServiceState State => _state;

        private volatile SilphServiceState _state = SilphServiceState.Stopped;

        private readonly CancellationTokenSource _cts = new();
        private readonly Lock _lock = new();
        private readonly Thread _thread;
        private int _tickRate = 100;

        private readonly ProcessMemory _processMemory;
        private readonly Game _targetGame;
        private SilphContext? _context;

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
            _thread = new Thread(ThreadLoop) { IsBackground = true };
            _thread.Start();
        }

        public void SetTickRate(int value)
        {
            _tickRate = value;
        }

        private void SetState(SilphServiceState value)
        {
            lock (_lock)
            {
                if (_state == value) return;
                _state = value;
                // send message
            }
        }

        public void Start()
        {
            if (_thread.IsAlive) return;
            SetState(SilphServiceState.Scanning);
            _thread.Start();
        }

        private void ThreadLoop()
        {
            CancellationToken token = _cts.Token;
            while (!token.IsCancellationRequested)
            {
                try
                {
                    // TODO: Check if process has exited
                    //if ()
                    //{
                    //    OnMessage?.Invoke(this, new DebugMessage("Target process exited. Stopping service."));
                    //    SetState(SilphServiceState.Stopped);
                    //    break;
                    //}
                    if (_state == SilphServiceState.Scanning)
                    {
                        ScanForAnchor();
                    }
                    token.WaitHandle.WaitOne(_tickRate);
                }
                catch (Exception ex)
                {
                    {
                        OnMessage?.Invoke(this, new DebugMessage($"{ex.Message}"));
                    }
                }
            }
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
                OnMessage?.Invoke(this, new DebugMessage("Found match at: 0x" + res.ToString("X")));
                // TODO: add sanity check
                // TODO: compatibility with other games? make a class responsible for getting the save address and reading the context
                nint baseAddr = res - _targetGame.Layout.Anchor;
                nint localSaveAddr = BitConverter.ToInt32(_processMemory.Read(baseAddr + _targetGame.Layout.SavePointer, 4));
                if (localSaveAddr >= _targetGame.Layout.RamStart && localSaveAddr <= _targetGame.Layout.RamEnd)
                {
                    nint saveAddr = _targetGame.Layout.GetSaveAddr(baseAddr, localSaveAddr);
                    _context = new(_targetGame, saveAddr, _processMemory.Read(saveAddr, _targetGame.Layout.SaveSize));
                    Gen4PkmnParser partyParser = new();
                    List<Pokemon> party = partyParser.ParseParty(_context);

                    GameState state = new(null, party.ToArray(), null);
                    OnMessage?.Invoke(this, new GameStateUpdateMessage(state));

                    SetState(SilphServiceState.Started);
                    break;
                }
            }
            return;
        }

        protected override void Dispose(bool disposing)
        {
            SetState(SilphServiceState.Stopped);
            _context = null;
            _cts.Cancel();
            if (_thread.IsAlive)
            {
                _thread.Join();
            }
            base.Dispose(disposing);
        }
    }
}
