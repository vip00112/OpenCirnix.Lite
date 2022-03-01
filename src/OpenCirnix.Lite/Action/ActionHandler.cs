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
                ChatAction.SendMsg(true, "[Error] !dr 0 ~ 500.");
                return false;
            }

            ChatAction.SendMsg(true, $"[ 게임 딜레이 ] 적용 :{(States.IsHostPlayer ? " [Host]" : string.Empty)} {delay} ms.");
            if (States.IsInGame) GameDelayAction.GameDelay = delay;
            return true;
        }

        public static void SetStartSpeed()
        {
            ChatAction.SendMsg(true, $"[ 빠른 게임시작 ] 적용.");
            StartDelayAction.StartDelay = 0.01f;
        }

        public static bool ToggleAutoRG()
        {
            if (AutoRGAction.IsRunning)
            {
                ChatAction.SendMsg(true, $"[ 자동 새로고침 ] 적용.");
                AutoRGAction.CancelAsync();
                return false;
            }

            ChatAction.SendMsg(true, $"[ 자동 새로고침 ] 해제.");
            AutoRGAction.RunWorkerAsync();
            return true;
        }

        public static async void MemoryOptimize()
        {
            int ResultDelay;

            ResultDelay = 5;
            ChatAction.SendMsg(true, "[ 메모리 정리 ] 시작.");

            if (await TrimProcessMemory(ResultDelay))
            {
                long ChangedMemory = MemoryValue[0] - MemoryValue[2];
                if (ChangedMemory < 0)
                {
                    ChatAction.SendMsg(true, $"[ 메모리 정리 ] 결과 : {ConvertSize(MemoryValue[0])} + {ConvertSize(-ChangedMemory)} = {ConvertSize(MemoryValue[2])}.");
                }
                else
                {
                    ChatAction.SendMsg(true, $"[ 메모리 정리 ] 결과 : {ConvertSize(MemoryValue[0])} - {ConvertSize(ChangedMemory)} = {ConvertSize(MemoryValue[2])}.");
                }
            }
        }

        public static void StartKeyMapping()
        {
            KeyMappingAction.StartHook();
        }

        public static void StopKeyMapping()
        {
            KeyMappingAction.EndHook();
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