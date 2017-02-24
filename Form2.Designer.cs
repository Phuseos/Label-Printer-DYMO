namespace WindowsFormsApplication2
{
    partial class Form2
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
            this.txtToshLabel = new System.Windows.Forms.TextBox();
            this.lblCountText = new System.Windows.Forms.Label();
            this.btnPrintLabel = new System.Windows.Forms.Button();
            this.btnSaveLabel = new System.Windows.Forms.Button();
            this.btnPrintFromFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtToshLabel
            // 
            this.txtToshLabel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtToshLabel.Location = new System.Drawing.Point(32, 29);
            this.txtToshLabel.Margin = new System.Windows.Forms.Padding(3, 1, 3, 5);
            this.txtToshLabel.MaxLength = 260;
            this.txtToshLabel.Multiline = true;
            this.txtToshLabel.Name = "txtToshLabel";
            this.txtToshLabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtToshLabel.Size = new System.Drawing.Size(439, 361);
            this.txtToshLabel.TabIndex = 0;
            this.txtToshLabel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToshLabel_KeyPress);
            // 
            // lblCountText
            // 
            this.lblCountText.AutoSize = true;
            this.lblCountText.Location = new System.Drawing.Point(29, 13);
            this.lblCountText.Name = "lblCountText";
            this.lblCountText.Size = new System.Drawing.Size(143, 13);
            this.lblCountText.TabIndex = 1;
            this.lblCountText.Text = "0 out of 260 characters used";
            // 
            // btnPrintLabel
            // 
            this.btnPrintLabel.Location = new System.Drawing.Point(327, 396);
            this.btnPrintLabel.Name = "btnPrintLabel";
            this.btnPrintLabel.Size = new System.Drawing.Size(144, 23);
            this.btnPrintLabel.TabIndex = 2;
            this.btnPrintLabel.Text = "Print label";
            this.btnPrintLabel.UseVisualStyleBackColor = true;
            this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
            // 
            // btnSaveLabel
            // 
            this.btnSaveLabel.Location = new System.Drawing.Point(327, 424);
            this.btnSaveLabel.Name = "btnSaveLabel";
            this.btnSaveLabel.Size = new System.Drawing.Size(144, 23);
            this.btnSaveLabel.TabIndex = 3;
            this.btnSaveLabel.Text = "Save label";
            this.btnSaveLabel.UseVisualStyleBackColor = true;
            this.btnSaveLabel.Click += new System.EventHandler(this.btnSaveLabel_Click);
            // 
            // btnPrintFromFile
            // 
            this.btnPrintFromFile.Location = new System.Drawing.Point(32, 396);
            this.btnPrintFromFile.Name = "btnPrintFromFile";
            this.btnPrintFromFile.Size = new System.Drawing.Size(140, 23);
            this.btnPrintFromFile.TabIndex = 4;
            this.btnPrintFromFile.Text = "Read text from file";
            this.btnPrintFromFile.UseVisualStyleBackColor = true;
            this.btnPrintFromFile.Click += new System.EventHandler(this.btnPrintFromFile_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 459);
            this.Controls.Add(this.btnPrintFromFile);
            this.Controls.Add(this.btnSaveLabel);
            this.Controls.Add(this.btnPrintLabel);
            this.Controls.Add(this.lblCountText);
            this.Controls.Add(this.txtToshLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtToshLabel;
        private System.Windows.Forms.Label lblCountText;
        private System.Windows.Forms.Button btnPrintLabel;
        private System.Windows.Forms.Button btnSaveLabel;
        private System.Windows.Forms.Button btnPrintFromFile;
    }
}