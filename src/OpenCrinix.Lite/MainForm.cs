﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OpenCirnix.Lite.MemoryEditor;

namespace OpenCirnix.Lite
{
    public partial class MainForm : Form
    {
        private bool _initializedWarcraft;
        private bool _waitGameStart;
        private bool _waitLobby;
        private BackgroundWorker _bw;

        public MainForm()
        {
            InitializeComponent();
        }

        #region Control Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            _bw = new BackgroundWorker();
            _bw.DoWork += bw_DoWork;
            _bw.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _bw.RunWorkerAsync();
        }

        private void button_gameDelay_Click(object sender, EventArgs e)
        {
            int delay = (int) numericUpDown_delay.Value;
            SetGameDelay(delay);
        }

        private void button_autoRG_Click(object sender, EventArgs e)
        {
            ToggleAutoRG();
        }

        private void button_speedStarter_Click(object sender, EventArgs e)
        {
            SetSpeedStarter();
        }

        private void button_memory_Click(object sender, EventArgs e)
        {
            StartMemoryOptimize();
        }
        #endregion

        #region Private Method
        private async void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (await ProcessCheck()) return;

                string message = ChatAction.GetMessage();
                if (string.IsNullOrEmpty(message)) return;

                ChatCommand(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            await Task.Delay(200);
            _bw.RunWorkerAsync();
        }   

        private async Task<bool> ProcessCheck()
        {
            if (GameModule.InitWarcraft3Info() != WarcraftState.OK || !GameModule.WarcraftCheck())
            {
                _initializedWarcraft = false;
                AutoRGAction.CancelAsync();

                await Task.Delay(800);
                return true;
            }

            if (!_initializedWarcraft)
            {
                WriteLog("Found warcraft 3 process.");
                _initializedWarcraft = true;
                await Task.Delay(2000);

                Warcraft3Info.Refresh();
                GameModule.GetOffset();

                ChatAction.SendMsg(true, " * Start cirnix lite. * ");
                await Task.Delay(500);

                ActionHandler.SetStartSpeed();
                WriteLog("Apply speed starter.");
            }

            StatusCheck();

            return false;
        }

        private async void StatusCheck()
        {
            if (_waitGameStart)
            {
                if (!ChatAction.GetSelectedReceiveStatus()) return;

                _waitGameStart = false;
                AutoRGAction.CancelAsync();
            }
            else
            {
                if (!_waitLobby && States.CurrentMusicState == MusicState.BattleNet)
                {
                    _waitLobby = true;
                    Warcraft3Info.Refresh();
                }

                if (!_waitLobby || GameDelayAction.GameDelay != 100) return;

                _waitLobby = false;
                _waitGameStart = true;

                AutoRGAction.CancelAsync();
                await Task.Delay(500);
                ActionHandler.SetGameDelay(550);
            }
        }

        private void ChatCommand(string message)
        {
            switch (message[0])
            {
                case '!':
                    States.UserState = CommandTag.Default;
                    return;
                case '-':
                    States.UserState = CommandTag.Chat;
                    return;
            }

            if (States.UserState == CommandTag.None) return;
            if (message[0] != '\0') return;

            string[] args;
            try
            {
                args = message.Substring(1, message.Length - 1).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                States.UserState = CommandTag.None;
                return;
            }
            if (args == null || args.Length == 0) return;

            string command = args[0];
            if (string.IsNullOrWhiteSpace(command)) return;

            command = command.ToLower();
            if (command == "dr" || command == "ㅇㄱ")
            {
                int delay = 50;
                if (args.Length >= 2)
                {
                    int.TryParse(args[1], out delay);
                }
                SetGameDelay(delay);
            }
            else if (command == "rg" || command == "ㄱㅎ")
            {
                ToggleAutoRG();
            }
            else if (command == "ss" || command == "ㄴㄴ")
            {
                SetSpeedStarter();
            }
            else if (command == "mm" || command == "ㅡㅡ")
            {
                StartMemoryOptimize();
            }
            States.UserState = CommandTag.None;
        }

        private void WriteLog(string log)
        {
            if (richTextBox_log.InvokeRequired)
            {
                Invoke((MethodInvoker) delegate () { WriteLog(log); });
            }
            else
            {
                richTextBox_log.AppendText(log + "\r\n");
            }
        }

        private void SetGameDelay(int delay)
        {
            if (ActionHandler.SetGameDelay(delay))
            {
                WriteLog($"Apply game delay : {delay}ms.");
            }
        }

        private void ToggleAutoRG()
        {
            var result = ActionHandler.ToggleAutoRG();
            if (result) WriteLog("Apply auto rg.");
            else WriteLog("Free auto rg.");
        }

        private void SetSpeedStarter()
        {
            ActionHandler.SetStartSpeed();
            WriteLog("Apply speed starter.");
        }

        private void StartMemoryOptimize()
        {
            ActionHandler.MemoryOptimize();
            WriteLog("Start memory optimize.");
        }
        #endregion
    }
}
