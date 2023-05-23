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
    public partial class demo : Form
    {
        public demo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login lg = new login();
            lg.Show();
        }
    }
}
