using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCirnix.Lite
{
    public partial class BanListRegisterDialog : Form
    {
        public BanListRegisterDialog()
        {
            InitializeComponent();
        }

        public User BanedUser { get; set; }

        private void button_register_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBoxUtil.Error("이름을 입력 하세요.");
                return;
            }

            string ip = textBox_ip.Text;
            if (!IPAddress.TryParse(ip, out IPAddress address))
            {
                MessageBoxUtil.Error("아이피 형식에 맞게 입력하세요.\r\nex) 192.168.0.1");
                return;
            }

            BanedUser = new User()
            {
                Name = name,
                Ip = ip,
                Reason = textBox_reason.Text,
            };
            DialogResult = DialogResult.OK;
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBoxUtil.Error("이름을 입력 하세요.");
                return;
            }

            string ip = textBox_ip.Text;
            if (!IPAddress.TryParse(ip, out IPAddress address))
            {
                MessageBoxUtil.Error("아이피 형식에 맞게 입력하세요.\r\nex) 192.168.0.1");
                return;
            }

            var user = new User()
            {
                Name = name,
                Ip = ip,
                Reason = textBox_reason.Text,
            };
            ActionHandler.DeleteBanList(user);

            BanedUser = null;
            DialogResult = DialogResult.OK;
        }

        public void LoadUser(User user)
        {
            if (user == null) return;

            textBox_name.Text = user.Name;
            textBox_ip.Text = user.Ip;
            textBox_reason.Text = user.Reason;
        }
    }
}
