namespace WindowsFormsApplication2
{
    partial class Form1
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
            this.printBtn = new System.Windows.Forms.Button();
            this.btnPrintToshiba = new System.Windows.Forms.Button();
            this.txtIntro_NonEnable = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(372, 179);
            this.printBtn.Margin = new System.Windows.Forms.Padding(2);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(193, 69);
            this.printBtn.TabIndex = 1;
            this.printBtn.Text = "DYMO Open Label File";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // btnPrintToshiba
            // 
            this.btnPrintToshiba.Location = new System.Drawing.Point(372, 287);
            this.btnPrintToshiba.Name = "btnPrintToshiba";
            this.btnPrintToshiba.Size = new System.Drawing.Size(193, 71);
            this.btnPrintToshiba.TabIndex = 4;
            this.btnPrintToshiba.Text = "Toshiba Make / Print Label (Opens in a new window)";
            this.btnPrintToshiba.UseVisualStyleBackColor = true;
            this.btnPrintToshiba.Click += new System.EventHandler(this.btnPrintToshiba_Click);
            // 
            // txtIntro_NonEnable
            // 
            this.txtIntro_NonEnable.BackColor = System.Drawing.Color.White;
            this.txtIntro_NonEnable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIntro_NonEnable.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtIntro_NonEnable.Enabled = false;
            this.txtIntro_NonEnable.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIntro_NonEnable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtIntro_NonEnable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtIntro_NonEnable.Location = new System.Drawing.Point(0, 70);
            this.txtIntro_NonEnable.Name = "txtIntro_NonEnable";
            this.txtIntro_NonEnable.Size = new System.Drawing.Size(958, 41);
            this.txtIntro_NonEnable.TabIndex = 5;
            this.txtIntro_NonEnable.Text = "Welcome to the LabelPrinter, press one the buttons below to begin.";
            this.txtIntro_NonEnable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(958, 571);
            this.Controls.Add(this.txtIntro_NonEnable);
            this.Controls.Add(this.btnPrintToshiba);
            this.Controls.Add(this.printBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.Button btnPrintToshiba;
        private System.Windows.Forms.TextBox txtIntro_NonEnable;
    }
}

