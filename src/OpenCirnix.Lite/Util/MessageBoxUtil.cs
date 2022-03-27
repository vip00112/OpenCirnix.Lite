using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCirnix.Lite
{
    public static class MessageBoxUtil
    {
        public static void Info(string msg)
        {
            Show(msg, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(string msg)
        {
            Show(msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(string msg)
        {
            var result = Show(msg, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result == DialogResult.OK;
        }

        private static DialogResult Show(string msg, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            var result = MessageBox.Show(msg, "OpenCirnix.Lite", buttons, icon);
            return result;
        }
    }
}
