namespace ZController.UI
{
    partial class SketchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SketchForm));
            this.sketchField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sketchField
            // 
            this.sketchField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sketchField.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sketchField.Location = new System.Drawing.Point(0, 0);
            this.sketchField.Multiline = true;
            this.sketchField.Name = "sketchField";
            this.sketchField.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sketchField.Size = new System.Drawing.Size(658, 520);
            this.sketchField.TabIndex = 0;
            this.sketchField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sketchField_KeyDown);
            this.sketchField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.sketchField_KeyUp);
            // 
            // SketchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 520);
            this.Controls.Add(this.sketchField);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SketchForm";
            this.Text = "Скетч";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sketchField;
    }
}