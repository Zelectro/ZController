using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ZController.Data
{
    public class CustomizationItem
    {
        public List<KeyProperties> KeyPropsList { get; set; }
        public int SelectedSpeedIndex { get; set; }
        public string ComValue { get; set; }
        public Size FormSize { get; set; }
        public PilotSymbolData PilotData { get; set; }
    }
}
