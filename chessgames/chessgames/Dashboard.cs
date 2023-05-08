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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnChessGame1_Click(object sender, EventArgs e)
        {
            Form1 admin = new Form1("Longle123", 1000, true, true, 0);
            admin.Show();
        }

        private void btnChessGame2_Click(object sender, EventArgs e)
        {
            Form1 player = new Form1("Ducngu123", 2000, false, false, 1);
            player.Show();
        }
    }
}
