namespace ZController
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.modeBtn = new System.Windows.Forms.Button();
            this.addBtnBtn = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.pilotSymbolBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.portCB = new System.Windows.Forms.ComboBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.sentLbl = new System.Windows.Forms.Label();
            this.sentDescrLbl = new System.Windows.Forms.Label();
            this.speedCB = new System.Windows.Forms.ComboBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.speedLbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genSketchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controllerPanel = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.pilotLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.controllerPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // modeBtn
            // 
            this.modeBtn.Location = new System.Drawing.Point(12, 27);
            this.modeBtn.Name = "modeBtn";
            this.modeBtn.Size = new System.Drawing.Size(54, 49);
            this.modeBtn.TabIndex = 1;
            this.modeBtn.UseVisualStyleBackColor = true;
            this.modeBtn.Click += new System.EventHandler(this.modeBtn_Click);
            // 
            // addBtnBtn
            // 
            this.addBtnBtn.Location = new System.Drawing.Point(82, 27);
            this.addBtnBtn.Name = "addBtnBtn";
            this.addBtnBtn.Size = new System.Drawing.Size(54, 49);
            this.addBtnBtn.TabIndex = 2;
            this.addBtnBtn.UseVisualStyleBackColor = true;
            this.addBtnBtn.Visible = false;
            this.addBtnBtn.Click += new System.EventHandler(this.addBtnBtn_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.pilotSymbolBtn);
            this.mainPanel.Controls.Add(this.clearBtn);
            this.mainPanel.Controls.Add(this.addBtnBtn);
            this.mainPanel.Controls.Add(this.portCB);
            this.mainPanel.Controls.Add(this.portLabel);
            this.mainPanel.Controls.Add(this.sentLbl);
            this.mainPanel.Controls.Add(this.sentDescrLbl);
            this.mainPanel.Controls.Add(this.speedCB);
            this.mainPanel.Controls.Add(this.connectBtn);
            this.mainPanel.Controls.Add(this.speedLbl);
            this.mainPanel.Controls.Add(this.modeBtn);
            this.mainPanel.Controls.Add(this.menuStrip1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(464, 89);
            this.mainPanel.TabIndex = 2;
            // 
            // pilotSymbolBtn
            // 
            this.pilotSymbolBtn.Location = new System.Drawing.Point(223, 27);
            this.pilotSymbolBtn.Name = "pilotSymbolBtn";
            this.pilotSymbolBtn.Size = new System.Drawing.Size(54, 49);
            this.pilotSymbolBtn.TabIndex = 4;
            this.pilotSymbolBtn.UseVisualStyleBackColor = true;
            this.pilotSymbolBtn.Click += new System.EventHandler(this.pilotSymbolBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(152, 27);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(54, 49);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // portCB
            // 
            this.portCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portCB.FormattingEnabled = true;
            this.portCB.Location = new System.Drawing.Point(294, 29);
            this.portCB.Name = "portCB";
            this.portCB.Size = new System.Drawing.Size(64, 21);
            this.portCB.TabIndex = 3;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(253, 32);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(35, 13);
            this.portLabel.TabIndex = 8;
            this.portLabel.Text = "Порт:";
            // 
            // sentLbl
            // 
            this.sentLbl.AutoSize = true;
            this.sentLbl.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sentLbl.Location = new System.Drawing.Point(283, 53);
            this.sentLbl.Name = "sentLbl";
            this.sentLbl.Size = new System.Drawing.Size(62, 23);
            this.sentLbl.TabIndex = 6;
            this.sentLbl.Text = "<нет>";
            // 
            // sentDescrLbl
            // 
            this.sentDescrLbl.AutoSize = true;
            this.sentDescrLbl.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sentDescrLbl.Location = new System.Drawing.Point(154, 53);
            this.sentDescrLbl.Name = "sentDescrLbl";
            this.sentDescrLbl.Size = new System.Drawing.Size(123, 23);
            this.sentDescrLbl.TabIndex = 5;
            this.sentDescrLbl.Text = "Отправлено:";
            // 
            // speedCB
            // 
            this.speedCB.FormattingEnabled = true;
            this.speedCB.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.speedCB.Location = new System.Drawing.Point(192, 29);
            this.speedCB.Name = "speedCB";
            this.speedCB.Size = new System.Drawing.Size(55, 21);
            this.speedCB.TabIndex = 2;
            this.speedCB.Text = "9600";
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(374, 29);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(86, 23);
            this.connectBtn.TabIndex = 4;
            this.connectBtn.Text = "Подключить";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // speedLbl
            // 
            this.speedLbl.AutoSize = true;
            this.speedLbl.Location = new System.Drawing.Point(91, 32);
            this.speedLbl.Name = "speedLbl";
            this.speedLbl.Size = new System.Drawing.Size(95, 13);
            this.speedLbl.TabIndex = 2;
            this.speedLbl.Text = "Cкорость (бит/с):";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(464, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToFileToolStripMenuItem,
            this.loadFromFileToolStripMenuItem,
            this.genSketchToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.menuToolStripMenuItem.Text = "Меню";
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.saveToFileToolStripMenuItem.Text = "Сохранить настройки в файл";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // loadFromFileToolStripMenuItem
            // 
            this.loadFromFileToolStripMenuItem.Name = "loadFromFileToolStripMenuItem";
            this.loadFromFileToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.loadFromFileToolStripMenuItem.Text = "Загрузить настройки из файла";
            this.loadFromFileToolStripMenuItem.Click += new System.EventHandler(this.loadFromFileToolStripMenuItem_Click);
            // 
            // genSketchToolStripMenuItem
            // 
            this.genSketchToolStripMenuItem.Name = "genSketchToolStripMenuItem";
            this.genSketchToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.genSketchToolStripMenuItem.Text = "Сгенерировать скетч";
            this.genSketchToolStripMenuItem.Click += new System.EventHandler(this.genSketchToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpLinkToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.helpToolStripMenuItem.Text = "Справка";
            // 
            // helpLinkToolStripMenuItem
            // 
            this.helpLinkToolStripMenuItem.Name = "helpLinkToolStripMenuItem";
            this.helpLinkToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.helpLinkToolStripMenuItem.Text = "Руководство";
            this.helpLinkToolStripMenuItem.Click += new System.EventHandler(this.helpLinkToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // controllerPanel
            // 
            this.controllerPanel.Controls.Add(this.statusStrip);
            this.controllerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controllerPanel.Location = new System.Drawing.Point(0, 89);
            this.controllerPanel.Name = "controllerPanel";
            this.controllerPanel.Size = new System.Drawing.Size(464, 274);
            this.controllerPanel.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pilotLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 252);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(464, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // pilotLabel
            // 
            this.pilotLabel.Name = "pilotLabel";
            this.pilotLabel.Size = new System.Drawing.Size(194, 17);
            this.pilotLabel.Text = "Отправка контрольного символа ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 363);
            this.Controls.Add(this.controllerPanel);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(480, 200);
            this.Name = "MainForm";
            this.Text = "Zelectro Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.controllerPanel.ResumeLayout(false);
            this.controllerPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button modeBtn;
        private System.Windows.Forms.Button addBtnBtn;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel controllerPanel;
        private System.Windows.Forms.Label speedLbl;
        private System.Windows.Forms.ComboBox speedCB;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Label sentLbl;
        private System.Windows.Forms.Label sentDescrLbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox portCB;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel pilotLabel;
        private System.Windows.Forms.Button pilotSymbolBtn;
        private System.Windows.Forms.ToolStripMenuItem genSketchToolStripMenuItem;


    }
}

