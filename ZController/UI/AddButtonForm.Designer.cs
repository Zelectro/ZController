namespace ZController
{
    partial class AddButtonForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddButtonForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.textTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.onKeyDownTB = new System.Windows.Forms.TextBox();
            this.onKeyUpTB = new System.Windows.Forms.TextBox();
            this.hotKeyTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Текст кнопки:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Символ при нажатии:";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(113, 133);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 5;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // textTB
            // 
            this.textTB.Location = new System.Drawing.Point(97, 25);
            this.textTB.MaxLength = 10;
            this.textTB.Name = "textTB";
            this.textTB.Size = new System.Drawing.Size(91, 20);
            this.textTB.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Символ при отпускании:";
            // 
            // onKeyDownTB
            // 
            this.onKeyDownTB.Location = new System.Drawing.Point(149, 81);
            this.onKeyDownTB.MaxLength = 1;
            this.onKeyDownTB.Name = "onKeyDownTB";
            this.onKeyDownTB.Size = new System.Drawing.Size(24, 20);
            this.onKeyDownTB.TabIndex = 3;
            this.onKeyDownTB.Validating += new System.ComponentModel.CancelEventHandler(this.onKeyDownTB_Validating);
            // 
            // onKeyUpTB
            // 
            this.onKeyUpTB.Location = new System.Drawing.Point(149, 107);
            this.onKeyUpTB.MaxLength = 1;
            this.onKeyUpTB.Name = "onKeyUpTB";
            this.onKeyUpTB.Size = new System.Drawing.Size(24, 20);
            this.onKeyUpTB.TabIndex = 4;
            this.onKeyUpTB.Validating += new System.ComponentModel.CancelEventHandler(this.onKeyUpTB_Validating);
            // 
            // hotKeyTB
            // 
            this.hotKeyTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hotKeyTB.Location = new System.Drawing.Point(149, 54);
            this.hotKeyTB.MaxLength = 1;
            this.hotKeyTB.Name = "hotKeyTB";
            this.hotKeyTB.Size = new System.Drawing.Size(24, 20);
            this.hotKeyTB.TabIndex = 2;
            this.hotKeyTB.Validating += new System.ComponentModel.CancelEventHandler(this.hotKeyTB_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Клавиша клавиатуры:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddButtonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 172);
            this.Controls.Add(this.hotKeyTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.onKeyUpTB);
            this.Controls.Add(this.onKeyDownTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textTB);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddButtonForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Добавить кнопку";
            this.Shown += new System.EventHandler(this.AddButtonForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox textTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox onKeyDownTB;
        private System.Windows.Forms.TextBox onKeyUpTB;
        private System.Windows.Forms.TextBox hotKeyTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}