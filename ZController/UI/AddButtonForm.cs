using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ZController.Data;

namespace ZController
{
    public partial class AddButtonForm : Form
    {
        private string enCharOrDigit = @"^[A-Za-z0-9]+$";
        private Regex enCharOrDigitRegex;
        private List<String> existingHotKeysList;
        private string curHotKey = String.Empty;
        private KeyProperties props = new KeyProperties();
        private KeyProperties bufProps = new KeyProperties();
        private bool isForEdit = false;
        private Point loc;
        private PilotSymbolData pilotSymData = new PilotSymbolData();
        public KeyProperties KeyProps
        {
            get
            {
                return props;
            }
        }

        public bool AddClicked = false;

        public AddButtonForm()
        {
            InitializeComponent();
        }

        public AddButtonForm(PilotSymbolData pilotData, List<string> existingHotKeys, Point location)
            : this(pilotData, existingHotKeys, new KeyProperties(), location) { }

        public AddButtonForm(PilotSymbolData pilotData, 
            List<string> existingHotKeys, KeyProperties props, Point location, bool forEdit = false)
        {
            this.pilotSymData = pilotData;
            this.existingHotKeysList = existingHotKeys;
            this.bufProps = new KeyProperties(props);
            this.props = props;
            this.isForEdit = forEdit;
            curHotKey = props.HotKey;
            InitializeComponent();
            loc = location;
            if (forEdit)
            {
                addBtn.Text = "Изменить";
                this.Text = "Изменить кнопку";
            }
            Bind();
            enCharOrDigitRegex = new Regex(enCharOrDigit);
        }

        private void Bind()
        {
            this.textTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", bufProps, "Text", true));
            this.hotKeyTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", bufProps, "HotKey", true));
            this.onKeyDownTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", bufProps, "OnKeyDownSymbol", true));
            this.onKeyUpTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", bufProps, "OnKeyUpSymbol", true));
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string validationMess = DoValidate();
            if (String.IsNullOrEmpty(validationMess))
            {
                AddClicked = true;
                this.props = bufProps;
                this.Close();
            }
            else
            {
                MessageBox.Show("Форма содержит некорректные данные: \n" + validationMess, "Некорректный ввод");
            }
        }

        private void hotKeyTB_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(hotKeyTB.Text) &&
                    !enCharOrDigitRegex.IsMatch(hotKeyTB.Text))
            {
                errorProvider1.SetError(hotKeyTB,
                    "Используйте цифру или символ латинского алфавита в качестве хоткея");
            }
            else if (curHotKey != hotKeyTB.Text && 
                existingHotKeysList != null && existingHotKeysList.Contains(hotKeyTB.Text))
            {
                errorProvider1.SetError(hotKeyTB,
                    "Используйте уникальную клавишу в качестве хоткея");
            }
            else
            {
                errorProvider1.SetError(hotKeyTB, String.Empty);
            }
        }

        private void onKeyDownTB_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(onKeyDownTB.Text) &&
                    !enCharOrDigitRegex.IsMatch(onKeyDownTB.Text))
            {
                errorProvider1.SetError(onKeyDownTB,
                    "Используйте цифру или символ латинского алфавита в качестве символа при нажатии");
            }
            else if (pilotSymData != null && pilotSymData.Enabled && pilotSymData.Symbol == onKeyDownTB.Text)
            {
                errorProvider1.SetError(onKeyDownTB,
                    "Указанный символ при нажатии уже используется в качестве контрольного");
            }
            else
            {
                errorProvider1.SetError(onKeyDownTB, String.Empty);
            }
        }

        private void onKeyUpTB_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(onKeyUpTB.Text) &&
                !enCharOrDigitRegex.IsMatch(onKeyUpTB.Text))
            {
                errorProvider1.SetError(onKeyUpTB,
                    "Используйте цифру или символ латинского алфавита в качестве символа при отпускании");
            }
            else if (pilotSymData != null && pilotSymData.Enabled && pilotSymData.Symbol == onKeyUpTB.Text)
            {
                errorProvider1.SetError(onKeyUpTB,
                    "Указанный символ при отпускании уже используется в качестве контрольного");
            }
            else
            {
                errorProvider1.SetError(onKeyUpTB, String.Empty);
            }
        }

        private string DoValidate()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Control c in errorProvider1.ContainerControl.Controls)
            {
                if (errorProvider1.GetError(c) != "")
                {
                    sb.AppendLine("-" + errorProvider1.GetError(c));
                }
            }
            return sb.ToString();
        }

        private void AddButtonForm_Shown(object sender, EventArgs e)
        {
            this.Location = loc;
        }
    }
}
