using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

        #region Constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Control Event
        private void MainForm_Load(object sender, EventArgs e)
        {
            _bw = new BackgroundWorker();
            _bw.DoWork += bw_DoWork;
            _bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            // 업데이트 tmp 파일 삭제
            var di = new DirectoryInfo(Application.StartupPath);
            var fis = di.GetFiles("*.update.tmp");
            foreach (var fi in fis)
            {
                string filePath = fi.FullName.Replace(".update.tmp", "");
                fi.CopyTo(filePath, true);
                fi.Delete();
            }

            // 세이브 파일 로드
            var setting = Setting.Load();
            if (setting != null)
            {
                int idx = 1;
                foreach (var mapping in setting.KeyMappings)
                {
                    string pressName = $"textBox_press{idx}";
                    var pressControl = Controls.Find(pressName, true).OfType<TextBox>().FirstOrDefault();
                    if (pressControl == null) continue;

                    string mappingName = $"textBox_mapping{idx}";
                    var mappingControl = Controls.Find(mappingName, true).OfType<TextBox>().FirstOrDefault();
                    if (mappingControl == null) continue;

                    pressControl.Tag = mapping.Press;
                    pressControl.Text = KeyMapping.GetKeyString(mapping.Press);
                    mappingControl.Tag = mapping.Mapping;
                    mappingControl.Text = KeyMapping.GetKeyString(mapping.Mapping);
                    AddKeyMapping(mapping.Press, mapping.Mapping);

                    idx++;
                }
            }
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            _bw.RunWorkerAsync();

            var needUpdate = await CheckVersionAndUpdate();
            if (needUpdate) Application.Exit();
            else ActionHandler.StartKeyMapping();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActionHandler.StopKeyMapping();

            var setting = new Setting()
            {
                KeyMappings = KeyMappingAction.GetMappings(),
            };
            Setting.Save(setting);
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

        private void button_mappingSetting_Click(object sender, EventArgs e)
        {
            KeyMappingAction.IsModifyMode = true;
            ActionHandler.StopKeyMapping();

            groupBox_mapping.Enabled = true;
            button_mappingSave.Enabled = true;
            button_mappingSetting.Enabled = false;
        }

        private void button_mappingSave_Click(object sender, EventArgs e)
        {
            KeyMappingAction.IsModifyMode = false;
            ActionHandler.StartKeyMapping();

            groupBox_mapping.Enabled = false;
            button_mappingSave.Enabled = false;
            button_mappingSetting.Enabled = true;
        }

        private void textBox_press_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            if (!ValidateKey(e.KeyCode)) return;

            if (e.KeyCode == Keys.Escape)
            {
                if (textBox.Tag != null)
                {
                    var press = (Keys) textBox.Tag;
                    RemoveKeyMapping(press);

                    textBox.Text = null;
                    textBox.Tag = null;
                }

                var mappingControl = Controls.Find(textBox.Name.Replace("press", "mapping"), true)
                                             .OfType<TextBox>()
                                             .FirstOrDefault();
                if (mappingControl != null)
                {
                    mappingControl.Text = null;
                    mappingControl.Tag = null;
                }
                return;
            }

            if (KeyMappingAction.HasMapping(e.KeyCode))
            {
                string msg = "이미 지정된 키 맵핑 입니다.";
                MessageBox.Show(msg, "OpenCirnix.Lite", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            if (textBox.Tag != null)
            {
                var press = (Keys) textBox.Tag;
                RemoveKeyMapping(press);
            }

            textBox.Tag = e.KeyCode;
            textBox.Text = KeyMapping.GetKeyString(e.KeyCode);
        }

        private void textBox_mapping_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            if (!ValidateKey(e.KeyCode)) return;

            var pressControl = Controls.Find(textBox.Name.Replace("mapping", "press"), true)
                                       .OfType<TextBox>()
                                       .FirstOrDefault();
            if (e.KeyCode == Keys.Escape)
            {
                textBox.Text = null;
                textBox.Tag = null;

                if (pressControl != null)
                {
                    if (pressControl.Tag != null)
                    {
                        var press = (Keys) pressControl.Tag;
                        RemoveKeyMapping(press);
                    }

                    pressControl.Text = null;
                    pressControl.Tag = null;
                }
                return;
            }

            textBox.Tag = e.KeyCode;
            textBox.Text = KeyMapping.GetKeyString(e.KeyCode);

            if (pressControl != null && pressControl.Tag != null)
            {
                var press = (Keys) pressControl.Tag;
                AddKeyMapping(press, e.KeyCode);
            }
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
                WriteLog("실행중인 워크래프트 3 발견.");
                _initializedWarcraft = true;
                await Task.Delay(2000);

                Warcraft3Info.Refresh();
                GameModule.GetOffset();

                ChatAction.SendMsg(true, " * 치르닉스 라이트 시작. * ");
                await Task.Delay(500);

                ActionHandler.SetStartSpeed();
                WriteLog("[ 빠른 게임시작 ] 적용.");
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
                richTextBox_log.SelectionStart = richTextBox_log.Text.Length;
                richTextBox_log.ScrollToCaret();
            }
        }

        private void SetGameDelay(int delay)
        {
            if (ActionHandler.SetGameDelay(delay))
            {
                WriteLog($"[ 게임 딜레이 ] 적용 {delay} ms.");
            }
        }

        private void ToggleAutoRG()
        {
            var result = ActionHandler.ToggleAutoRG();
            if (result) WriteLog("[ 자동 새로고침 ] 적용.");
            else WriteLog("[ 자동 새로고침 ] 해제.");
        }

        private void SetSpeedStarter()
        {
            ActionHandler.SetStartSpeed();
            WriteLog("[ 빠른 게임시작 ] 적용.");
        }

        private void StartMemoryOptimize()
        {
            ActionHandler.MemoryOptimize();
            WriteLog("[ 메모리 정리 ] 시작.");
        }

        private bool ValidateKey(Keys key)
        {
            var keyName = key.ToString().ToLower();
            var ignores = new string[] { "capital", "shift", "control", "alt", "menu", "mode", "apps" };
            foreach (var ignore in ignores)
            {
                if (keyName.Contains(ignore)) return false;
            }

            return true;
        }

        private void AddKeyMapping(Keys press, Keys mapping)
        {
            KeyMappingAction.AddMapping(press, mapping);
            WriteLog($"[ 키 맵핑 ] 적용 : {KeyMapping.GetKeyString(press)} → {KeyMapping.GetKeyString(mapping)}.");
        }

        private void RemoveKeyMapping(Keys press)
        {
            KeyMappingAction.RemoveMapping(press);
            WriteLog($"[ 키 맵핑 ] 해제 : {KeyMapping.GetKeyString(press)}.");
        }

        public static async Task<bool> CheckVersionAndUpdate()
        {
            var task = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(2000);
                var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
                var releaseVersion = GithubUtil.GetLatestVersion("vip00112", "OpenCirnix.Lite");
                if (currentVersion >= releaseVersion) return null;

                return GithubUtil.GetDownloadUrlForLatestAsset("vip00112", "OpenCirnix.Lite", "OpenCirnix.Lite*.zip");
            });

            var needUpdate = await task.ContinueWith((result) =>
            {
                string filePath = Path.Combine(Application.StartupPath, "GTAutoUpdate.exe");
                if (!File.Exists(filePath)) return false;

                string url = result.Result;
                if (string.IsNullOrWhiteSpace(url)) return false;

                int idx = url.LastIndexOf("/");
                if (idx == -1) return false;

                string fileName = url.Substring(idx + 1);
                string savePath = Path.Combine(Application.StartupPath, fileName);

                string msg = "Find new version.\r\nAre you download ner version ?";
                var dr = MessageBox.Show(msg, "OpenCirnix.Lite", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK) return false;

                var proc = new Process();
                proc.StartInfo.FileName = filePath;
                proc.StartInfo.Arguments = string.Format("\"{0}\" \"{1}\"", url, savePath);
                proc.Start();
                return true;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            return needUpdate;
        }
        #endregion
    }
}
