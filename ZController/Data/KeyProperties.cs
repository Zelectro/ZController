using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ZController.Data
{
    public class KeyProperties
    {
        public KeyProperties()
        {
        }

        public KeyProperties(KeyProperties inp)
        {
            this.Text = inp.Text;
            this.HotKey = inp.HotKey;
            this.OnKeyDownSymbol = inp.OnKeyDownSymbol;
            this.OnKeyUpSymbol = inp.OnKeyUpSymbol;
            this.Location = new Point(inp.Location.X, inp.Location.Y);
        }

        public string Text { get; set; }
        public string HotKey { get; set; }
        public string OnKeyDownSymbol { get; set; }
        public string OnKeyUpSymbol { get; set; }
        public Point Location { get; set; }
    }
}
