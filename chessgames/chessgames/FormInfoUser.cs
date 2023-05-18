using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessgames
{
    public partial class FormInfoUser : Form
    {
        public FormInfoUser()
        {
            InitializeComponent();
        }
        private string preUserame;
        private string preEmail;
        private string preLinkAvatar;
        private infoUser user;
        private void FormInfoUser_Load(object sender, EventArgs e)
        {
            txtDefeats.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtID.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtWins.Enabled = true;
        }
        public FormInfoUser(infoUser user) : this()
        {
            this.user = user;

            //hien thi hinh anh len giao dien
            ptboxAvatar.Image = Image.FromFile(user.linkAvatar);
            ptboxAvatar.BackgroundImageLayout = ImageLayout.Stretch;

            txtDefeats.Text = user.numberOfLosses.ToString();
            txtWins.Text = user.numberOfWins.ToString();
            txtUsername.Text = user.userName;
            txtEmail.Text = user.gmail;
            txtID.Text = user.id;

            //lưu lại thông tin trước đó
            preEmail = user.gmail;
            preLinkAvatar = user.linkAvatar;
            preUserame = user.userName;
        }

        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            txtUsername.ReadOnly = false;
            txtEmail.ReadOnly = false;

            //đưa user lên api để kiểm tra API có tồn tại hay không
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {

        }
    }
}
