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

        private nint _saveAddr;
        private readonly APkmnParser _pkmnParser;
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
            _pkmnParser = new Gen4PkmnParser();
            _trainerParser = new TrainerParser();
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
                //try
                //{
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
                        UpdateGameData();
                        break;
                }
                token.WaitHandle.WaitOne(_tickRate);
                //}
                //catch (Exception ex)
                //{
                //    {
                //        OnMessage?.Invoke(this, new DebugMessage($"Error in ThreadLoop: {ex.Message}"));
                //    }
                //}
            }
        }

        private void UpdateGameData()
        {
            ScanForAnchor();
            //SilphContext context = new(_targetGame, _saveAddr, _processMemory.Read(_saveAddr, _targetGame.Layout.SaveSize));
            //List<Pokemon> party = _pkmnParser.ParseParty(context);
            //GameState gameState = new(null, party.ToArray(), null);
            //OnMessage?.Invoke(this, new GameStateUpdate(gameState));

            //    catch (Exception ex)
            //    {
            //        OnMessage?.Invoke(this, new DebugMessage($"Memory read failed at 0x{_saveAddr:X}: {ex.Message}"));
            //    }
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
                // TODO: add sanity check
                // TODO: compatibility with other games? make a class responsible for getting the save address and reading the context
                nint baseAddr = res - _targetGame.Layout.Anchor;
                nint localSaveAddr = BitConverter.ToInt32(_processMemory.Read(baseAddr + _targetGame.Layout.SavePointer, 4));
                if (localSaveAddr >= _targetGame.Layout.RamStart && localSaveAddr <= _targetGame.Layout.RamEnd)
                {
                    //OnMessage?.Invoke(this, new DebugMessage("Anchor located, save is at: 0x" + localSaveAddr.ToString("X")));
                    nint newSaveAddr = _targetGame.Layout.GetSaveAddr(baseAddr, localSaveAddr);
                    if (newSaveAddr != _saveAddr)
                    {
                        OnMessage?.Invoke(this, new DebugMessage($"Save address updated, was: 0x{_saveAddr:X}, is 0x{newSaveAddr:X}"));
                        _saveAddr = newSaveAddr;
                    }
                    SilphContext context = new(_targetGame, _saveAddr, _processMemory.Read(_saveAddr, _targetGame.Layout.SaveSize));
                    List<Pokemon> party = _pkmnParser.ParseParty(context);
                    GameState gameState = new(null, party.ToArray(), null);
                    OnMessage?.Invoke(this, new GameStateUpdate(gameState));
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
