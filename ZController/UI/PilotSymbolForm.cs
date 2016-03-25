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

namespace ZController.UI
{
    public partial class PilotSymbolForm : Form
    {
        private string enCharOrDigit = @"^[A-Za-z0-9]+$";
        private Regex enCharOrDigitRegex;
        private PilotSymbolData data = new PilotSymbolData();
        private PilotSymbolData bufData = new PilotSymbolData();
        private Point loc;
        private List<string> existingSymbols;
        private string curPilotSym;
        public PilotSymbolData Data
        {
            get
            {
                return data;
            }
        }

        public PilotSymbolForm()
        {
            InitializeComponent();
        }

        public PilotSymbolForm(List<string> existingSymbols, PilotSymbolData data, Point location)
        {
            curPilotSym = data.Symbol;
            this.existingSymbols = existingSymbols;
            enCharOrDigitRegex = new Regex(enCharOrDigit);
            bufData = new PilotSymbolData(data);
            this.data = data;
            InitializeComponent();
            loc = location;
            Bind();
            SetEnabled();
        }

        private void Bind()
        {
            this.pilotSymbolTB.DataBindings.Add(new System.Windows.Forms.Binding("Text", bufData, "Symbol", true));
            this.intervalPilotEd.DataBindings.Add(new System.Windows.Forms.Binding("Text", bufData, "Interval", true));
            this.enablePilotChckB.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bufData, "Enabled", true));
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string validationMess = DoValidate();
            if (String.IsNullOrEmpty(validationMess))
            {
                this.data = bufData;
                this.Close();
            }
            else
            {
                MessageBox.Show("Форма содержит некорректные данные: \n" + validationMess, "Некорректный ввод");
            }
        }

        private string DoValidate()
        {
            pilotSymbolTB_Validating(null, null);
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

        private void PilotSymbolForm_Shown(object sender, EventArgs e)
        {
            this.Location = loc;
        }

        private void pilotSymbolTB_Validating(object sender, CancelEventArgs e)
        {
            if (bufData.Enabled)
            {
                if (String.IsNullOrEmpty(pilotSymbolTB.Text))
                {
                    errorProvider1.SetError(pilotSymbolTB,
                        "Не назначен контрольный символ");
                }
                else if (!enCharOrDigitRegex.IsMatch(pilotSymbolTB.Text))
                {
                    errorProvider1.SetError(pilotSymbolTB,
                        "Используйте цифру или символ латинского алфавита в качестве контрольного символа");
                }
                else if (curPilotSym != pilotSymbolTB.Text &&
                existingSymbols != null && existingSymbols.Contains(pilotSymbolTB.Text))
                {
                    errorProvider1.SetError(pilotSymbolTB,
                        "Используйте уникальную клавишу в качестве контрольного символа");
                }
                else
                {
                    errorProvider1.SetError(pilotSymbolTB, String.Empty);
                }
            }
        }

        private void enablePilotChckB_CheckedChanged(object sender, EventArgs e)
        {
            SetEnabled();
        }

        private void SetEnabled()
        {
            pilotSymbolTB.Enabled = intervalPilotEd.Enabled = enablePilotChckB.Checked;
        }
    }
}
