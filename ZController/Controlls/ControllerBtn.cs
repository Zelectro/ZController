using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZController.Data;

namespace ZController.Controlls
{
    public partial class ControllerBtn : Button
    {
        public bool WasPressed { get; set; }

        private KeyProperties keyProps = new KeyProperties();
        public KeyProperties KeyProps
        {
            get
            {
                return keyProps;
            }
            set
            {
                keyProps = value;
            }
        }

        public ControllerBtn()
        {
            InitializeComponent();
        }

        public ControllerBtn(KeyProperties keyProps)
        {
            this.keyProps = keyProps;
            InitializeComponent();
        }
    }
}
