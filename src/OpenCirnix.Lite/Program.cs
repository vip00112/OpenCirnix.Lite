using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCirnix.Lite
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
#else
            // 관리자권한으로 재실행
            if (!IsAdministrator())
            {
                try
                {
                    var pi = new ProcessStartInfo();
                    pi.UseShellExecute = true;
                    pi.FileName = Application.ExecutablePath;
                    pi.WorkingDirectory = Environment.CurrentDirectory;
                    pi.Verb = "runas";
                    Process.Start(pi);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "OpenCirnix.Lite", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                return;
            }

            bool createdNew;
            var mutex = new Mutex(true, "OpenCirnix.Lite", out createdNew);
            if (!createdNew) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            mutex.ReleaseMutex();
#endif
        }

        private static bool IsAdministrator()
        {
            var wi = WindowsIdentity.GetCurrent();
            if (wi == null) return false;

            var wp = new WindowsPrincipal(wi);
            return wp.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
