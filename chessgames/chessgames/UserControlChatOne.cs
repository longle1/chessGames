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
    public partial class UserControlChatOne : UserControl
    {
        public UserControlChatOne()
        {
            InitializeComponent();
            rtbContentChatOne.ReadOnly = true;
            pnlContainIconsChatOne.Hide();
        }
        List<Button> buttonListIcons = new List<Button>();
        public TextBox TextBox
        {
            get { return txtSendMsgChatOne; }
        }
        public RichTextBox richTextBox
        {
            get { return rtbContentChatOne; }
        }
        public Panel containsIcon
        {
            get { return pnlContainIconsChatOne; }
        }
        public List<Button> listIcons
        {
            get { return buttonListIcons; }
            set { buttonListIcons = value; }
        }
        public event EventHandler <EventArgs> btnSendMsgChatOne_click;
        public event EventHandler <EventArgs> btnSendIconChatOne_click;
        public event EventHandler<EventArgs> btnCloseForm_click;
        private void btnSendMsgChatOne_Click(object sender, EventArgs e)
        {
            btnSendMsgChatOne_click?.Invoke(this, e);
        }

        private void btnSendIconChatOne_Click(object sender, EventArgs e)
        {
            btnSendIconChatOne_click?.Invoke(this, e);
        }
        
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            btnCloseForm_click?.Invoke(this, e);
        }
    }
}
