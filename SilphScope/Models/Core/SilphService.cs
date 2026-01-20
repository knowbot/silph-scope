using SilphScope.Models.Core.Memory;
using SilphScope.Models.Core.Messages;
using SilphScope.Models.Games;
using SilphScope.Models.Games.Parsers.Gen4;
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
        public bool Initialized { get => _initialized; private set => _initialized = value; }
        public bool Stopped { get => _stopped; private set => _stopped = value; }

        private bool _stopped;
        private bool _initialized;
        private readonly Lock _locker = new();
        private readonly Thread _thread;
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

        // TODO: needed?
        public SilphServiceStatus GetStatus() => Stopped ? SilphServiceStatus.Stopped : Initialized ? SilphServiceStatus.Started : SilphServiceStatus.Scanning;

        private void ThreadLoop()
        {
            while (!ShouldStop())
            {
                // If not initialized yet, attempt initialization
                if (!_initialized)
                {
                    Init();
                }
            }
        }

        private void Init()
        {
            List<nint> candidateAddresses = _processMemory.PatternScanAll(_targetGame.Layout.AnchorString); // Find memory signature

            if (candidateAddresses.Count == 0)
            {
                OnMessage?.Invoke(this, new DebugMessage("No matches found."));
                return;
            }

            foreach (nint res in candidateAddresses)
            {
                OnMessage?.Invoke(this, new DebugMessage("Found match at: 0x" + res.ToString("X")));
                nint baseAddr = res - _targetGame.Layout.Anchor;
                // Verify candidate address is good
                nint localSaveAddr = BitConverter.ToInt32(_processMemory.Read(baseAddr + _targetGame.Layout.SavePointer, 4));
                if (localSaveAddr != 0)
                {
                    nint saveAddr = _targetGame.Layout.GetSaveAddr(baseAddr, localSaveAddr);
                    OnMessage?.Invoke(this, new DebugMessage("Save data address found at: 0x" + saveAddr.ToString("X")));
                    _context = new(_targetGame, saveAddr, _processMemory.Read(saveAddr, _targetGame.Layout.SaveSize));
                    Gen4PkmnParser partyParser = new();
                    List<Pokemon> party = partyParser.ParseParty(_context);
                    Debug.WriteLine(party.Count);
                    OnMessage?.Invoke(this, new DebugMessage("First pkmn: " + party[0].Species.ToString()));
                    OnMessage?.Invoke(this, new DebugMessage("Ability: " + party[0].Ability.ToString()));
                    OnMessage?.Invoke(this, new DebugMessage("Moves: " + party[0].MoveSet.ToString()));
                    _initialized = true;
                }
            }
            return;
        }

        protected bool ShouldStop()
        {
            lock (_locker)
            {
                return Stopped;
            }
        }

        protected override void Dispose(bool disposing)
        {
            lock (_locker)
            {
                Stopped = true;
            }
            _thread.Join();
            base.Dispose(disposing);
        }
    }
}
