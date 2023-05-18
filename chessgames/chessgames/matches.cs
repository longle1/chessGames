using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgames
{
    public class matches
    {
        public string _id { get; set; }
        public List<matchPlayer> players { get; set; }
        public string status { get; set; }
        public int count { get; set; }
        public int betPoints { get; set; }
    }
}
