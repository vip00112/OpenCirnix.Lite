using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenCirnix.Lite
{
    public partial class BanListForm : Form
    {
        public BanListForm()
        {
            InitializeComponent();
        }

        private void BanListForm_Load(object sender, EventArgs e)
        {
            LoadBanedUsers();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            LoadBanedUsers();
            LoadCurrentUsers(true);
        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var listView = sender as ListView;
            if (listView == null) return;

            if (listView.SelectedItems.Count == 0) return;

            var item = listView.SelectedItems[0];
            var user = item.Tag as User;

            ShowRegisterDialog(user);
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            ShowRegisterDialog(null);
        }

        private void menuItem_check_Click(object sender, EventArgs e)
        {
            if (listView_current.SelectedItems.Count == 0) return;

            var item = listView_current.SelectedItems[0];
            var user = item.Tag as User;
            if (user == null) return;

            ActionHandler.CheckBanListTargetUser(user.Name);
        }

        private void ShowRegisterDialog(User user)
        {
            using (var dialog = new BanListRegisterDialog())
            {
                dialog.LoadUser(user);
                if (dialog.ShowDialog() != DialogResult.OK) return;

                var banedUser = dialog.BanedUser;
                if (banedUser != null) ActionHandler.UpdateBanList(banedUser);

                LoadBanedUsers();
                LoadCurrentUsers(false);
            }
        }

        private void LoadBanedUsers()
        {
            listView_baned.Items.Clear();

            var banedUsers = UserListAction.BanedUsers.ToList();
            foreach (var user in banedUsers)
            {
                var li = new ListViewItem(user.Name);
                li.SubItems.Add(user.Ip);
                li.SubItems.Add(user.Reason);
                li.Tag = user;
                listView_baned.Items.Add(li);
            }
        }

        private async void LoadCurrentUsers(bool isShowMsg)
        {
            listView_current.Items.Clear();

            var users = ActionHandler.GetUsers();
            var banedUsers = UserListAction.BanedUsers.ToList();
            var findBanedUsers = new List<User>();
            foreach (var user in users)
            {
                string name = user.Name;
                string reason = null;

                var baned = banedUsers.FirstOrDefault(o => o.IsMatch(user.Name, user.Ip));
                if (baned != null)
                {
                    name = $"[!!] {name}";
                    reason = baned.Reason;
                    findBanedUsers.Add(baned);
                }

                var li = new ListViewItem(name);
                li.SubItems.Add(user.Ip);
                li.SubItems.Add(reason);
                li.Tag = user;
                listView_current.Items.Add(li);
            }

            if (isShowMsg)
            {
                foreach (var user in findBanedUsers)
                {
                    ChatAction.SendMsg(true, $"[ 발견 ] {user.Name} ({user.Ip}) : {user.Reason}");
                    await Task.Delay(300);
                }
            }
        }
    }
}
