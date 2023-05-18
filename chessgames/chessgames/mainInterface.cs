using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessgames
{
    public partial class mainInterface : Form
    {
        public mainInterface()
        {
            InitializeComponent();
        }
        private infoUser user;
        private string linkAvatar;
        public static mainInterface showInter = null;
        private string parentDirectory;
        public mainInterface(infoUser user) : this()
        {
            parentDirectory = Directory.GetParent(Application.StartupPath)?.Parent?.FullName + "\\Images";
            this.user = user;
            lbUserName.Text = user.userName;
            lbScore.Text = user.point.ToString();
            if (user.linkAvatar == "")
                user.linkAvatar = "defaultAvatar.jpg";
            ptboxAvatar.Image = Image.FromFile($"{parentDirectory}\\" + user.linkAvatar);
            ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            showInter = this;
        }

        private void btnContainInfoUser_Click(object sender, EventArgs e)
        {
            //ẩn giao diện chính đi
            this.Hide();
            FormInfoUser info = new FormInfoUser(user);
            info.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //tiến hành đóng form lại
            this.Close();

            login.showFormAgain.Show();
        }

        private void btnRank_Click(object sender, EventArgs e)
        {

        }

        private void btnMakeFriend_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnListFriend_Click(object sender, EventArgs e)
        {

        }

        private void btnSendIcon_Click(object sender, EventArgs e)
        {

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {

        }

        private void mainInterface_Load(object sender, EventArgs e)
        {
            lbUserName.Text = user.userName;
            lbScore.Text = user.point.ToString();
            if (user.linkAvatar == "")
                user.linkAvatar = "defaultAvatar.jpg";
            ptboxAvatar.Image = Image.FromFile($"{parentDirectory}\\" + user.linkAvatar);
            ptboxAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
