using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZController.Data
{
    public class PilotSymbolData
    {
        public PilotSymbolData() { }
        public PilotSymbolData(PilotSymbolData data)
        {
            this.Enabled = data.Enabled;
            this.Symbol = data.Symbol;
            this.Interval = data.Interval;
        }
        public bool Enabled { get; set; }
        public string Symbol { get; set; }

        private int interval = 100;
        public int Interval 
        { 
            get
            {
                return interval;
            }
            set
            {
                interval = value;
            }
        }
    }
}
