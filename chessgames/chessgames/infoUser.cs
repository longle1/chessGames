using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessgames
{
    internal class infoUser
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string gmail { get; set; }
        public string linkAvatar { get; set; }
        public int point { get; set; }
        public int numberOfWins { get; set; }
        public int numberOfLosses { get; set; }
        public List<listFriends> lists { get; set; }
        public List<match> matches { get; set; }
    }
}
