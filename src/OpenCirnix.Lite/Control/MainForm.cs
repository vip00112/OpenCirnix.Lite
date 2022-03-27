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
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            // 설정 로드
            LoadSetting();

            // 워크 감지 시작
            _bw.RunWorkerAsync();

            var needUpdate = await CheckVersionAndUpdate();
            if (needUpdate)
            {
                Application.Exit();
                return;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActionHandler.StopKeyMapping();

            // 설정 저장
            SaveSetting();
        }

        private void textBox_path_Click(object sender, EventArgs e)
        {
            SelectPath();
        }

        private void checkBox_window_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_path.Text))
            {
                SelectPath();
            }

            string path = textBox_path.Text;
            if (string.IsNullOrWhiteSpace(path)) return;
        }

        private void checkBox_viewSpeed_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_path.Text))
            {
                SelectPath();
            }

            string path = textBox_path.Text;
            if (string.IsNullOrWhiteSpace(path)) return;

            WriteMixFile();

            if (GameModule.InitWarcraft3Info() == WarcraftState.OK || GameModule.WarcraftCheck())
            {
                MessageBoxUtil.Info("워크래프트를 재시작해야 적용 됩니다.");
            }
        }

        private void checkBox_viewManaBar_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_path.Text))
            {
                SelectPath();
            }

            string path = textBox_path.Text;
            if (string.IsNullOrWhiteSpace(path)) return;

            WriteMixFile();

            if (GameModule.InitWarcraft3Info() == WarcraftState.OK || GameModule.WarcraftCheck())
            {
                MessageBoxUtil.Info("워크래프트를 재시작해야 적용 됩니다.");
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_path.Text))
            {
                SelectPath();
            }

            string path = textBox_path.Text;
            if (string.IsNullOrWhiteSpace(path)) return;

            WriteMixFile();

            bool isWindow = checkBox_window.Checked;
            try
            {
                var pi = new ProcessStartInfo();
                pi.FileName = path;
                if (isWindow) pi.Arguments = "-window";

                Process.Start(pi);
            }
            catch (Exception ex)
            {
                MessageBoxUtil.Error(ex.Message);
            }
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

        private void button_checkMember_Click(object sender, EventArgs e)
        {
            int maxCount = (int) numericUpDown_maxCount.Value;
            CheckMember(maxCount);
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
            string type = button_mappingSetting.Tag as string;
            if (type == "EDITMODE")
            {
                button_mappingSetting.Tag = null;
                button_mappingSetting.Text = "키 맵핑 편집";

                KeyMappingAction.IsModifyMode = false;
                ActionHandler.StartKeyMapping();
                groupBox_mapping.Enabled = false;
                checkBox_mapping.Enabled = true;
            }
            else
            {
                button_mappingSetting.Tag = "EDITMODE";
                button_mappingSetting.Text = "키 맵핑 저장";

                KeyMappingAction.IsModifyMode = true;
                ActionHandler.StopKeyMapping();
                groupBox_mapping.Enabled = true;
                checkBox_mapping.Enabled = false;
            }
        }

        private void checkBox_mapping_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_mapping.Checked)
            {
                Height = 520;
                button_mappingSetting.Enabled = true;
                ActionHandler.StartKeyMapping();
                WriteLog("[ 키 맵핑 후킹 ] 시작.");
            }
            else
            {
                Height = 335;
                button_mappingSetting.Enabled = false;
                ActionHandler.StopKeyMapping();
                WriteLog("[ 키 맵핑 후킹 ] 종료.");
            }
        }

        private void textBox_press_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            if (!ValidateKey(e.KeyCode)) return;

            string mappingControlName = textBox.Name.Replace("press", "mapping");
            if (e.KeyCode == Keys.Escape)
            {
                if (textBox.Tag != null)
                {
                    var press = (Keys) textBox.Tag;
                    RemoveKeyMapping(press);
                }

                textBox.Text = null;
                textBox.Tag = null;
                ClearKeyMapControl(mappingControlName);
                return;
            }

            if (KeyMappingAction.HasMapping(e.KeyCode))
            {
                MessageBoxUtil.Error("이미 지정된 키 맵핑 입니다.");
                return;
            }

            if (textBox.Tag != null)
            {
                var press = (Keys) textBox.Tag;
                RemoveKeyMapping(press);
            }

            textBox.Tag = e.KeyCode;
            textBox.Text = KeyMapping.GetKeyString(e.KeyCode);
            ClearKeyMapControl(mappingControlName);
        }

        private void textBox_mapping_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            if (!ValidateKey(e.KeyCode)) return;

            string pressControlName = textBox.Name.Replace("mapping", "press");
            if (e.KeyCode == Keys.Escape)
            {
                textBox.Text = null;
                textBox.Tag = null;

                ClearKeyMapControl(pressControlName);
                return;
            }

            textBox.Tag = e.KeyCode;
            textBox.Text = KeyMapping.GetKeyString(e.KeyCode);

            var pressControl = Controls.Find(pressControlName, true).OfType<TextBox>().FirstOrDefault();
            if (pressControl != null && pressControl.Tag != null)
            {
                var press = (Keys) pressControl.Tag;
                AddKeyMapping(press, e.KeyCode);
            }
        }
        #endregion

        #region Private Method
        private void LoadSetting()
        {
            var setting = Setting.Load();
            if (setting == null) return;

            textBox_path.Text = setting.Path;

            checkBox_window.Checked = setting.IsWindowMode;
            checkBox_viewSpeed.Checked = setting.IsViewSpeed;
            checkBox_viewManaBar.Checked = setting.IsViewManaBer;

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

            checkBox_mapping.Checked = setting.IsUseKeyMapping;
            if (checkBox_mapping.Checked)
            {
                ActionHandler.StartKeyMapping();
                WriteLog("[ 키 맵핑 후킹 ] 시작.");
            }
        }

        private void SaveSetting()
        {
            var setting = new Setting()
            {
                IsWindowMode = checkBox_window.Checked,
                IsViewSpeed = checkBox_viewSpeed.Checked,
                IsViewManaBer = checkBox_viewManaBar.Checked,
                Path = textBox_path.Text,
                IsUseKeyMapping = checkBox_mapping.Checked,
                KeyMappings = KeyMappingAction.GetMappings(),
            };
            Setting.Save(setting);
        }

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
                CheckMemberAction.CancelAsync();

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

        private void StatusCheck()
        {
            if (_waitGameStart)
            {
                if (!ChatAction.GetSelectedReceiveStatus()) return;

                _waitGameStart = false;
                AutoRGAction.CancelAsync();
                CheckMemberAction.CancelAsync();
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
                CheckMemberAction.CancelAsync();
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
            if (command == "max" || command == "ㅡㅁㅌ")
            {
                int maxCount = 0;
                if (args.Length >= 2)
                {
                    int.TryParse(args[1], out maxCount);
                }
                CheckMember(maxCount);
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
                WriteLog($"[ 게임 딜레이 ] 적용 : {delay} ms.");
            }
        }

        private void ToggleAutoRG()
        {
            if (GameModule.InitWarcraft3Info() != WarcraftState.OK || !GameModule.WarcraftCheck()) return;

            var result = ActionHandler.ToggleAutoRG();
            if (result) WriteLog("[ 자동 새로고침 ] 적용.");
            else WriteLog("[ 자동 새로고침 ] 해제.");
        }

        private void CheckMember(int maxCount)
        {
            if (GameModule.InitWarcraft3Info() != WarcraftState.OK || !GameModule.WarcraftCheck()) return;

            var result = ActionHandler.CheckMember(maxCount);
            if (result) WriteLog($"[ 인원 알림 ] 적용 : {maxCount}명 이상.");
            else WriteLog("[ 인원 알림 ] 해제.");
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

        private void SelectPath()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "워크래프트 실행파일 선택";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (ofd.ShowDialog() != DialogResult.OK) return;

                textBox_path.Text = ofd.FileName;
            }
        }

        private void WriteMixFile()
        {
            if (string.IsNullOrWhiteSpace(textBox_path.Text)) return;

            var sb = new StringBuilder();
            sb.AppendLine("[Cirnix]");
            sb.AppendLine($"Mana Bar={(checkBox_viewManaBar.Checked ? 1 : 0)}");
            sb.AppendLine($"Show AS & MS in Number={(checkBox_viewSpeed.Checked ? 1 : 0)}");

            string dirPath = Path.GetDirectoryName(textBox_path.Text);
            string iniFilePath = Path.Combine(dirPath, "Cirnix.ini");
            File.WriteAllText(iniFilePath, sb.ToString());

            string mixFilePath = Path.Combine(dirPath, "Cirnix.mix");
            if (!File.Exists(mixFilePath))
            {
                File.WriteAllBytes(mixFilePath, Properties.Resources.Cirnix);
            }
        }

        private bool ValidateKey(Keys key)
        {
            var keyName = key.ToString().ToLower();
            var ignores = new string[] { "shift", "control", "alt", "menu", "mode", "apps" };
            foreach (var ignore in ignores)
            {
                if (keyName.Contains(ignore)) return false;
            }

            return true;
        }

        private void ClearKeyMapControl(string name)
        {
            var control = Controls.Find(name, true).OfType<TextBox>().FirstOrDefault();
            if (control == null) return;

            if (name.Contains("press") && control.Tag != null)
            {
                var press = (Keys) control.Tag;
                RemoveKeyMapping(press);
            }

            control.Text = null;
            control.Tag = null;
        }

        private void AddKeyMapping(Keys press, Keys mapping)
        {
            KeyMappingAction.AddMapping(press, mapping);
            WriteLog($"[ 키 맵핑 ] 적용 : {KeyMapping.GetKeyString(press)} → {KeyMapping.GetKeyString(mapping)}.");
        }

        private void RemoveKeyMapping(Keys press)
        {
            if (KeyMappingAction.RemoveMapping(press))
            {
                WriteLog($"[ 키 맵핑 ] 해제 : {KeyMapping.GetKeyString(press)}.");
            }
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

                if (!MessageBoxUtil.Confirm("Find new version.\r\nAre you download new version ?")) return false;

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
