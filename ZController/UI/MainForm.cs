using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using ZController.Data;
using ZController.Controlls;
using ZController.Helpers;
using ZController.Resources;

namespace ZController
{
    public partial class MainForm : Form
    {
        #region Members
        private Dictionary<string, ControllerBtn> hotkeyDict = 
            new Dictionary<string, ControllerBtn>();
        private List<string> usedSymbolsList = new List<string>();
        private bool isEditMode = false;
        private bool isConnected = false;
        private string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" +
                    Properties.Settings.Default.AppDataFolderName + "\\";
        private Point clickLoc = new Point();
        private Timer comUpdateTimer = new Timer();
        private Timer pilotSymTimer = new Timer();
        private static int newBtnPadding = 5;
        private string[] lastPorts;
        private SerialPort comPort = new SerialPort();
        private PilotSymbolData pilotSymData = new PilotSymbolData();
        private const string statusTextOn = "Контрольный символ '{0}' отправляется каждые {1}(мс)";
        private const string statusTextOff = "Контрольный символ '{0}' будет отправлятся каждые {1}(мс)";
        #endregion

        public MainForm()
        {
            InitializeComponent();
            InitApp();
            SetModeSettings();
            this.KeyPreview = true;
        }

        private void InitApp()
        {
            addBtnBtn.Image = Resources.Images.AddBtnImg;
            clearBtn.Image = Resources.Images.ClearBtnImg;
            pilotSymbolBtn.Image = Resources.Images.PilotBtnImg;
            pilotSymTimer.Tick += new EventHandler(pilotTimer_Tick);
            UpdateComPortsCB();
            if (Directory.Exists(appDataDir))
            {
                isEditMode = !TryLoadLayout();
            }
            else
            {
                isEditMode = true;
                this.speedCB.SelectedIndex = 5;
                Directory.CreateDirectory(appDataDir);
            }
            pilotLabel.Text =
                String.Format(statusTextOff, pilotSymData.Symbol, pilotSymData.Interval);
            InitComTimer();
        }

        private void InitComTimer()
        {
            comUpdateTimer.Tick += new EventHandler(comTimer_Tick);
            comUpdateTimer.Interval = (1000) * (1);
            comUpdateTimer.Enabled = true;
            comUpdateTimer.Start();
        }

        private void StartPilotTimer()
        {
            if (pilotSymData.Interval < 100)
            {
                pilotSymData.Interval = 100;
            }
            pilotSymTimer.Interval = pilotSymData.Interval;
            pilotSymTimer.Enabled = true;
            pilotSymTimer.Start();
        }

        private void pilotTimer_Tick(object sender, EventArgs e)
        {
            if (pilotSymData.Enabled)
            {
                try
                {
                    comPort.Write(pilotSymData.Symbol);
                }
                catch
                {
                    AbortPort();
                    MessageBox.Show(Resources.ErrorMessages.PORT_WRITE, "Ошибка");
                }
            }
        }

        private void UpdateComPortsCB()
        {
            string[] ar = SerialPort.GetPortNames().ToArray();
            if (ar == null)
            {
                portCB.Items.Clear();
                return;
            }

            bool areEqual = false;
            if (lastPorts != null)
            {
                areEqual = ar.SequenceEqual(lastPorts);
            }

            if (!areEqual)
            {
                string val = String.Empty;
                if (portCB.SelectedItem != null)
                {
                    val = portCB.SelectedItem.ToString();
                }
                portCB.Items.Clear();
                portCB.Items.AddRange(ar);
                if (!String.IsNullOrEmpty(val))
                {
                    if (ar.Contains(val))
                    {
                        portCB.SelectedItem = val;
                    }
                }
                if (ar.Length > 0)
                {
                    portCB.SelectedIndex = 0;
                }
                lastPorts = ar;
            }
        }

        private bool TryLoadLayout()
        {
            return TryLoadLayout(appDataDir + String.Format(Properties.Settings.Default.DefLayoutFileName,
                Assembly.GetExecutingAssembly().GetName().Version.ToString()));
        }

        private bool TryLoadLayout(string filePath)
        {
            bool res = true;
            if (File.Exists(filePath))
            {
                try
                {
                    CustomizationItem ci = SerializationHelper.ReadFromXmlFile<CustomizationItem>(filePath);
                    if (ci.KeyPropsList == null || ci.KeyPropsList.Count == 0)
                    {
                        res = false;
                    }
                    else
                    {
                        foreach (KeyProperties btn in ci.KeyPropsList)
                        {
                            AddNewBtn(btn, true);
                        }
                    }
                    this.pilotSymData = ci.PilotData;
                    //this.usedSymbolsList.Add(ci.PilotData.Symbol);
                    this.ClientSize = ci.FormSize;
                    speedCB.SelectedIndex = ci.SelectedSpeedIndex;

                    if (!String.IsNullOrEmpty(ci.ComValue))
                    {
                        if (portCB.Items.Contains(ci.ComValue))
                        {
                            portCB.SelectedItem = ci.ComValue;
                        }
                    }
                }
                catch
                {
                    res = false;
                    MessageBox.Show(filePath == appDataDir + String.Format(Properties.Settings.Default.DefLayoutFileName,
                        Assembly.GetExecutingAssembly().GetName().Version.ToString()) ?
                        ErrorMessages.LAYOUT_DEF_LOAD : ErrorMessages.LAYOUT_LOAD, "Ошибка");
                }
            }
            else
            {
                res = false;
            }
            return res;
        }

        private void AddNewBtn(KeyProperties keyProperties, bool layoutLoad = false)
        {
            ControllerBtn newBtn = new ControllerBtn(keyProperties);
            if (!layoutLoad)
            {
                keyProperties.Location = new System.Drawing.Point(newBtnPadding += 5, newBtnPadding += 5);
            }
            newBtn.Text = keyProperties.Text;
            newBtn.Location = keyProperties.Location;
            newBtn.Size = new System.Drawing.Size(25, 25);
            newBtn.TabStop = false;
            newBtn.UseVisualStyleBackColor = true;
            ContextMenuStrip cms = new System.Windows.Forms.ContextMenuStrip();
            cms.Items.Add("Удалить");
            cms.ItemClicked += cms_ItemClicked;
            cms.Opening += cms_Opening;
            newBtn.ContextMenuStrip = cms;
            newBtn.AutoSize = true;
            newBtn.MouseDown += ControllerButtonMouseDownHandler;
            newBtn.MouseUp += ControllerButtonMouseUpHandler;
            newBtn.MouseMove += ControllerBtnMouseMoveHandler;
            if (!String.IsNullOrWhiteSpace(keyProperties.HotKey))
            {
                hotkeyDict.Add(keyProperties.HotKey, newBtn);
                usedSymbolsList.Add(keyProperties.OnKeyDownSymbol);
                usedSymbolsList.Add(keyProperties.OnKeyUpSymbol);
            }
            this.controllerPanel.Controls.Add(newBtn);
        }

        private void EditBtn(KeyProperties keyProperties, ControllerBtn btn)
        {
            if (hotkeyDict.ContainsValue(btn))
            {
                var item = hotkeyDict.First(kvp => kvp.Value == btn);
                hotkeyDict.Remove(item.Key);
            }
            usedSymbolsList.Remove(btn.KeyProps.OnKeyDownSymbol);
            usedSymbolsList.Remove(btn.KeyProps.OnKeyUpSymbol);
            usedSymbolsList.Add(keyProperties.OnKeyDownSymbol);
            usedSymbolsList.Add(keyProperties.OnKeyUpSymbol);
            if (!String.IsNullOrWhiteSpace(keyProperties.HotKey))
            {
                hotkeyDict.Add(keyProperties.HotKey, btn);
            }

            btn.Text = keyProperties.Text;
            btn.KeyProps = keyProperties;
        }

        private void SetModeSettings()
        {
            addBtnBtn.Visible = clearBtn.Visible = pilotSymbolBtn.Visible = isEditMode;
            sentLbl.Visible = sentDescrLbl.Visible = !isEditMode;
            speedLbl.Visible = speedCB.Visible = connectBtn.Visible = !isEditMode;
            portLabel.Visible = portCB.Visible = !isEditMode;
            statusStrip.Visible = pilotSymData.Enabled && !isEditMode;
            if (isEditMode)
            {
                this.controllerPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                modeBtn.Image = Resources.Images.RunBtnImg;
            }
            else
            {
                modeBtn.Image = Resources.Images.SettingsBtnImg;
                this.controllerPanel.BackColor = this.BackColor;
            }
        }

        private void SetConnectMode()
        {
            pilotSymbolBtn.Enabled = modeBtn.Enabled = speedCB.Enabled = portCB.Enabled = 
                loadFromFileToolStripMenuItem.Enabled = !isConnected;
            if (isConnected)
            {
                connectBtn.Text = "Отключить";
                pilotLabel.Text =
                    String.Format(statusTextOn, pilotSymData.Symbol, pilotSymData.Interval);
            }
            else
            {
                connectBtn.Text = "Подключить";
                sentLbl.Text = "<нет>";
                pilotLabel.Text =
                    String.Format(statusTextOff, pilotSymData.Symbol, pilotSymData.Interval);
            }
        }

        private void SaveLayout()
        {
            SaveLayout(appDataDir + String.Format(Properties.Settings.Default.DefLayoutFileName,
                Assembly.GetExecutingAssembly().GetName().Version.ToString()));
        }

        private void SaveLayout(string filePath)
        {
            try
            {
                List<KeyProperties> btnsList = new List<KeyProperties>();
                foreach (Control c in controllerPanel.Controls)
                {
                    ControllerBtn btn = c as ControllerBtn;
                    if (btn != null)
                    {
                        KeyProperties prop = btn.KeyProps;
                        prop.Location = btn.Location;
                        btnsList.Add(prop);
                    }
                }
                CustomizationItem ci = new CustomizationItem();
                ci.KeyPropsList = btnsList;
                ci.FormSize = this.ClientSize;
                ci.SelectedSpeedIndex = speedCB.SelectedIndex;
                ci.PilotData = this.pilotSymData;
                if (portCB.SelectedItem != null)
                {
                    ci.ComValue = portCB.SelectedItem.ToString();
                }
                SerializationHelper.WriteToXmlFile(filePath, ci);
            }
            catch
            {
                MessageBox.Show(ErrorMessages.LAYOUT_SAVE, "Ошибка");
            }
        }

        private void addBtnBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            AddButtonForm form = new AddButtonForm(pilotSymData,
                                    new List<string>(hotkeyDict.Keys.AsEnumerable()), 
                                    new Point(btn.Location.X + controllerPanel.Location.X + this.Location.X,
                                    btn.Location.Y + controllerPanel.Location.Y + this.Location.Y));
            form.ShowDialog(this);
            if (form.AddClicked)
            {
                AddNewBtn(form.KeyProps);
            }
        }

        private void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ControllerBtn btn = (sender as ContextMenuStrip).SourceControl as ControllerBtn;
            if (btn.KeyProps.HotKey != null && hotkeyDict.ContainsKey(btn.KeyProps.HotKey))
            {
                hotkeyDict.Remove(btn.KeyProps.HotKey);
                usedSymbolsList.Remove(btn.KeyProps.OnKeyDownSymbol);
                usedSymbolsList.Remove(btn.KeyProps.OnKeyUpSymbol);
            }
            this.controllerPanel.Controls.Remove(btn);
        }

        private void cms_Opening(object sender, CancelEventArgs e)
        {
            if (!isEditMode)
            {
                e.Cancel = true;
            }
        }

        private void modeBtn_Click(object sender, EventArgs e)
        {
            isEditMode = !isEditMode;
            SetModeSettings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isConnected)
            {
                AbortPort();
                comUpdateTimer.Stop();
            }
            SaveLayout();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isEditMode)
            {
                if (hotkeyDict.ContainsKey(e.KeyCode.ToString()) && !hotkeyDict[e.KeyCode.ToString()].WasPressed)
                {
                    hotkeyDict[e.KeyCode.ToString()].WasPressed = true;
                    ControllerButtonMouseDownHandler(hotkeyDict[e.KeyCode.ToString()],
                        new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                }
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (!isEditMode)
            {
                if (hotkeyDict.ContainsKey(e.KeyCode.ToString()))
                {
                    hotkeyDict[e.KeyCode.ToString()].WasPressed = false;
                    ControllerButtonMouseUpHandler(hotkeyDict[e.KeyCode.ToString()],
                        new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                }
            }
        }

        private void ControllerBtnMouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (isEditMode)
            {
                ControllerBtn button = (ControllerBtn)sender;
                if (e.Button == MouseButtons.Left)
                {
                    if (button.Left + e.X - clickLoc.X > 0 &&
                        button.Left + e.X - clickLoc.X + button.Width < controllerPanel.Width)
                    {
                        button.Left += e.X - clickLoc.X;
                    }
                    if (button.Top + e.Y - clickLoc.Y > 0 &&
                        button.Top + e.Y - clickLoc.Y + button.Height < controllerPanel.Height)
                    {
                        button.Top += e.Y - clickLoc.Y;
                    }
                }
            }
        }

        private void ControllerButtonMouseDownHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isEditMode)
                {
                    clickLoc = e.Location;
                    if (e.Clicks >= 2)
                    {
                        ControllerBtn btn = sender as ControllerBtn;
                        AddButtonForm form = 
                            new AddButtonForm(pilotSymData,
                                new List<string>(hotkeyDict.Keys.AsEnumerable()), btn.KeyProps,
                                new Point(e.X + btn.Location.X + controllerPanel.Location.X + this.Location.X,
                                    e.Y + btn.Location.Y + controllerPanel.Location.Y + this.Location.Y), true);
                        form.ShowDialog(this);
                        EditBtn(form.KeyProps, btn);
                    }
                }
                else if (isConnected)
                {
                    ControllerBtn btn = sender as ControllerBtn;
                    if (btn.KeyProps.OnKeyDownSymbol != null)
                    {
                        try
                        {
                            comPort.Write(btn.KeyProps.OnKeyDownSymbol);
                            sentLbl.Text = btn.KeyProps.OnKeyDownSymbol;
                        }
                        catch
                        {
                            AbortPort();
                            MessageBox.Show(Resources.ErrorMessages.PORT_WRITE, "Ошибка");
                        }
                    }
                }
            }
        }



        private void ControllerButtonMouseUpHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !isEditMode && isConnected)
            {
                ControllerBtn btn = sender as ControllerBtn;
                if (btn.KeyProps.OnKeyUpSymbol != null)
                {
                    try
                    {
                        comPort.Write(btn.KeyProps.OnKeyUpSymbol);
                        sentLbl.Text = btn.KeyProps.OnKeyUpSymbol;
                    }
                    catch
                    {
                        AbortPort();
                        MessageBox.Show(Resources.ErrorMessages.PORT_WRITE, "Ошибка");
                    }
                }
            }
        }

        private void AbortPort()
        {
            try
            {
                isConnected = false;
                SetConnectMode();
                pilotSymTimer.Stop();
                comPort.Close();
            }
            catch { }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.AboutBox box = new UI.AboutBox();
            box.Show();
        }

        private void helpLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Settings.Default.ManualPage);
        }

        private void comTimer_Tick(object sender, EventArgs e)
        {
            UpdateComPortsCB();
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isConnected)
                {
                    AbortPort();
                    comPort.PortName = portCB.Text;
                    comPort.Open();
                    if (pilotSymData.Enabled)
                    {
                        StartPilotTimer();
                    }
                }
                else
                {
                    pilotSymTimer.Stop();
                    comPort.Close();
                }
                isConnected = !isConnected;
                SetConnectMode();
            }
            catch
            {
                MessageBox.Show(Resources.ErrorMessages.PORT_CONNECT, "Ошибка");
            }
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveLayout(saveFileDialog1.FileName);
            }
        }

        private void loadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dg = new OpenFileDialog();
            dg.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            if (dg.ShowDialog() == DialogResult.OK)
            {
                isEditMode = false;
                ClearAll();
                TryLoadLayout(dg.FileName);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            newBtnPadding = 5;
            SetModeSettings();
            controllerPanel.Controls.Clear();
            hotkeyDict.Clear();
            usedSymbolsList.Clear();
        }

        private void pilotSymbolBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            UI.PilotSymbolForm form = new UI.PilotSymbolForm(usedSymbolsList, 
                pilotSymData, new Point(btn.Location.X + controllerPanel.Location.X + this.Location.X,
                btn.Location.Y + controllerPanel.Location.Y + this.Location.Y));
            form.ShowDialog(this);
            pilotSymData = form.Data;
            statusStrip.Visible = !isEditMode && pilotSymData.Enabled;
            pilotLabel.Text =
               String.Format(statusTextOff, pilotSymData.Symbol, pilotSymData.Interval);
        }

        private void genSketchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.SketchForm form =
                new UI.SketchForm(SketchGenerationHelper.GenerateSketch(pilotSymData, speedCB.Text, usedSymbolsList));
            form.Show(this);
        }
    }
}
