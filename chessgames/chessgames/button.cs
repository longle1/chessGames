using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessgames
{
    internal class button
    {
        public int buttonHeight = 35;
        public int buttonWidth = 35;
        public int numberOfPiece = 0;
        public Button createButton(Button oldButton, Panel pnl, Image img, string text, bool whiteTurn)
        {
            Button btn = new Button()
            {
                Width = buttonHeight,
                Height = buttonWidth,
                Location = new Point(oldButton.Location.X + oldButton.Width + 5, oldButton.Location.Y),
                BackgroundImageLayout = ImageLayout.Stretch
            };
            
            btn.Padding = new Padding(30, 3, 3, 3);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.BackgroundImage = img;
            btn.Text = text;
            btn.TabIndex = whiteTurn == true ? 1 : 0;   //tương đương với quân trắng là 0 và quân đen là 1
            pnl.Controls.Add(btn);
            return btn;
        }
    }
}
