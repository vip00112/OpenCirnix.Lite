using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OpenCirnix.Lite.MemoryEditor;

namespace OpenCirnix.Lite
{
    public static class ActionHandler
    {
        public static bool SetGameDelay(int delay)
        {
            if (delay < 0 || delay > 550)
            {
                ChatAction.SendMsg(true, "[Error] game delay have to between 0 to 550.");
                return false;
            }

            ChatAction.SendMsg(true, $"Apply game delay :{(States.IsHostPlayer ? " [Host]" : string.Empty)} {delay} ms.");
            if (States.IsInGame) GameDelayAction.GameDelay = delay;
            return true;
        }

        public static void SetStartSpeed()
        {
            ChatAction.SendMsg(true, $"Apply speed starter.");
            StartDelayAction.StartDelay = 0.01f;
        }

        public static bool ToggleAutoRG()
        {
            if (AutoRGAction.IsRunning)
            {
                ChatAction.SendMsg(true, "Free auto rg");
                AutoRGAction.CancelAsync();
                return false;
            }

            ChatAction.SendMsg(true, "Apply auto rg.");
            AutoRGAction.RunWorkerAsync();
            return true;
        }

        public static async void MemoryOptimize()
        {
            int ResultDelay;

            ResultDelay = 5;
            ChatAction.SendMsg(true, "Start memory optimize.");

            if (await TrimProcessMemory(ResultDelay))
            {
                long ChangedMemory = MemoryValue[0] - MemoryValue[2];
                if (ChangedMemory < 0)
                {
                    ChatAction.SendMsg(true, $"Memory optimize result : {ConvertSize(MemoryValue[0])} + {ConvertSize(-ChangedMemory)} = {ConvertSize(MemoryValue[2])}.");
                }
                else
                {
                    ChatAction.SendMsg(true, $"Memory optimize result : {ConvertSize(MemoryValue[0])} - {ConvertSize(ChangedMemory)} = {ConvertSize(MemoryValue[2])}.");
                }
            }
        }

        private static string ConvertSize(double size)
        {
            bool reversed = false;
            string result;
            if (size < 0)
            {
                reversed = true;
                size *= -1;
            }
            if (size >= 1000000) result = $"{Math.Round(size / 1048576.0, 1)} MB";
            else if (size >= 1000) result = $"{Math.Round(size / 1024.0, 1)} KB";
            else result = $"{Math.Round(size)} bytes";

            if (reversed) result = '-' + result;

            return result;
        }
    }
}