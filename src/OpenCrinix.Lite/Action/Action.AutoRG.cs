using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static OpenCirnix.Lite.MemoryEditor;

namespace OpenCirnix.Lite
{
    public static class AutoRGAction
    {
        private static readonly Timer Timer;
        private static readonly HangWatchdog Worker;

        public static bool IsRunning;

        static AutoRGAction()
        {
            Worker = new HangWatchdog(0, 0, 10);
            Worker.Condition = () => IsRunning;
            Worker.Actions += Actions;

            Timer = new Timer(state => Worker.Check());
        }

        public static void RunWorkerAsync()
        {
            if (IsRunning) return;

            Timer.Change(0, 1000);
            IsRunning = true;
            Actions();
        }

        public static void CancelAsync()
        {
            if (!IsRunning) return;

            Worker.Reset();
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
            IsRunning = false;
        }

        private static void Actions()
        {
            ChatAction.SendMsg(false, "/rg");
        }
    }
}
