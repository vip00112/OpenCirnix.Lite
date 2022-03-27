using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static OpenCirnix.Lite.MemoryEditor;
using static OpenCirnix.Lite.States;

namespace OpenCirnix.Lite
{
    public static class CheckMemberAction
    {
        private static readonly Timer Timer;
        private static readonly HangWatchdog Worker;
        private static int MaxCount;

        public static bool IsRunning;

        static CheckMemberAction()
        {
            Worker = new HangWatchdog(0, 0, 0);
            Worker.Condition = () => IsRunning && MaxCount <= PlayerCount;
            Worker.Actions += Actions;

            Timer = new Timer(state => Worker.Check());
        }

        public static void RunWorkerAsync(int maxCount)
        {
            if (IsRunning || maxCount == 0) return;

            Timer.Change(0, 500);
            MaxCount = maxCount;
            IsRunning = true;
            Worker.Check();
        }

        public static void CancelAsync()
        {
            if (!IsRunning) return;

            Worker.Reset();
            Timer.Change(Timeout.Infinite, Timeout.Infinite);
            IsRunning = false;
            MaxCount = 0;
        }

        private static void Actions()
        {
            try
            {
                ChatAction.SendMsg(true, $"[ 인원 알림 ] : {MaxCount}명 이상이 되었습니다.");
                CancelAsync();
                SoundUtil.Play(Properties.Resources.Max);
            }
            catch { }
        }
    }
}
