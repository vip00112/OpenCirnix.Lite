using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static OpenCirnix.Lite.MemoryEditor;

namespace OpenCirnix.Lite
{
    public static class ActionHandler
    {
        public static bool SetGameDelay(int delay)
        {
            if (delay < 5 || delay > 550)
            {
                ChatAction.SendMsg(true, "[Error] !dr 5 ~ 550.");
                return false;
            }

            if (States.IsInGame)
            {
                ChatAction.SendMsg(true, $"[ 게임 딜레이 ] 적용 :{(States.IsHostPlayer ? " [Host]" : string.Empty)} {delay} ms.");
                GameDelayAction.GameDelay = delay;
                return true;
            }
            return false;
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
                ChatAction.SendMsg(true, $"[ 자동 새로고침 ] 해제.");
                AutoRGAction.CancelAsync();
                return false;
            }

            ChatAction.SendMsg(true, $"[ 자동 새로고침 ] 적용.");
            AutoRGAction.RunWorkerAsync();
            return true;
        }

        public static bool CheckMember(int maxCount)
        {
            if (CheckMemberAction.IsRunning)
            {
                ChatAction.SendMsg(true, $"[ 인원 알림 ] 해제.");
                CheckMemberAction.CancelAsync();
                return false;
            }

            ChatAction.SendMsg(true, $"[ 인원 알림 ] 적용 : {maxCount}명 이상.");
            CheckMemberAction.RunWorkerAsync(maxCount);
            return true;
        }

        public static async void MemoryOptimize()
        {
            if (await TrimProcessMemory(0))
            {
                long changedMemory = MemoryValue[0] - MemoryValue[2];
                string result = (changedMemory < 0) ? "증가" : "정리";
                ChatAction.SendMsg(true, $"[ 메모리 정리 ] : {ConvertSize(changedMemory)} {result} ({ConvertSize(MemoryValue[0])} -> {ConvertSize(MemoryValue[2])}).");
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

        public static List<User> GetUsers()
        {
            return UserListAction.FindUserList();
        }

        public static void UpdateBanList(User user)
        {
            if (user == null) return;

            var banedUsers = UserListAction.BanedUsers.ToList();
            var baned = banedUsers.FirstOrDefault(o => o.IsMatch(user.Name, user.Ip));
            if (baned != null)
            {
                if (user.Ip != User.AnyIp) baned.Ip = user.Ip;
                if (!string.IsNullOrWhiteSpace(user.Reason)) baned.Reason = user.Reason;
            }
            else
            {
                UserListAction.BanedUsers.Add(user);
            }
        }

        public static void DeleteBanList(User user)
        {
            if (user == null) return;

            var banedUsers = UserListAction.BanedUsers.ToList();
            var baned = banedUsers.FirstOrDefault(o => o.IsMatch(user.Name, user.Ip));
            if (baned != null)
            {
                UserListAction.BanedUsers.Remove(baned);
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