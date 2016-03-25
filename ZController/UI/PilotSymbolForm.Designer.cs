namespace ZController.UI
{
    partial class PilotSymbolForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PilotSymbolForm));
            this.enablePilotChckB = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.pilotSymbolTB = new System.Windows.Forms.TextBox();
            this.intervalPilotEd = new System.Windows.Forms.NumericUpDown();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.intervalPilotEd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // enablePilotChckB
            // 
            this.enablePilotChckB.AutoSize = true;
            this.enablePilotChckB.Location = new System.Drawing.Point(12, 12);
            this.enablePilotChckB.Name = "enablePilotChckB";
            this.enablePilotChckB.Size = new System.Drawing.Size(210, 17);
            this.enablePilotChckB.TabIndex = 0;
            this.enablePilotChckB.Text = "Использовать контрольный символ";
            this.enablePilotChckB.UseVisualStyleBackColor = true;
            this.enablePilotChckB.CheckedChanged += new System.EventHandler(this.enablePilotChckB_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Контрольный символ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Интервал между отправками (мс):";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(137, 96);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // pilotSymbolTB
            // 
            this.pilotSymbolTB.Location = new System.Drawing.Point(200, 46);
            this.pilotSymbolTB.MaxLength = 1;
            this.pilotSymbolTB.Name = "pilotSymbolTB";
            this.pilotSymbolTB.Size = new System.Drawing.Size(34, 20);
            this.pilotSymbolTB.TabIndex = 1;
            this.pilotSymbolTB.Validating += new System.ComponentModel.CancelEventHandler(this.pilotSymbolTB_Validating);
            // 
            // intervalPilotEd
            // 
            this.intervalPilotEd.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.intervalPilotEd.Location = new System.Drawing.Point(200, 67);
            this.intervalPilotEd.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.intervalPilotEd.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.intervalPilotEd.Name = "intervalPilotEd";
            this.intervalPilotEd.Size = new System.Drawing.Size(76, 20);
            this.intervalPilotEd.TabIndex = 2;
            this.intervalPilotEd.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PilotSymbolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 131);
            this.Controls.Add(this.intervalPilotEd);
            this.Controls.Add(this.pilotSymbolTB);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enablePilotChckB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PilotSymbolForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Настройки контрольного символа";
            this.Shown += new System.EventHandler(this.PilotSymbolForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.intervalPilotEd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox enablePilotChckB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox pilotSymbolTB;
        private System.Windows.Forms.NumericUpDown intervalPilotEd;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}