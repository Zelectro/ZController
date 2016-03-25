using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZController.UI
{
    public partial class SketchForm : Form
    {
        bool keyPressed = false;

        public SketchForm()
        {
            InitializeComponent();
        }

        public SketchForm(string sketch)
        {
            InitializeComponent();
            sketchField.Text = sketch;
        }

        private void sketchField_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox != null && txtBox.Multiline == true && e.Control == true && e.KeyCode == Keys.A && !keyPressed)
            {
                keyPressed = true;
                txtBox.SelectAll();
            }
        }

        private void sketchField_KeyUp(object sender, KeyEventArgs e)
        {
            keyPressed = false;
        }
    }
}
