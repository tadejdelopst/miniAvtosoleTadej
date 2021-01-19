namespace miniProjekt___Avtosole {
    partial class Prijava {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.PrijavaBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prijavaEmailTxtBox = new System.Windows.Forms.TextBox();
            this.prijavaPassTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.prijavaRegBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PrijavaBtn
            // 
            this.PrijavaBtn.Location = new System.Drawing.Point(128, 132);
            this.PrijavaBtn.Name = "PrijavaBtn";
            this.PrijavaBtn.Size = new System.Drawing.Size(133, 57);
            this.PrijavaBtn.TabIndex = 0;
            this.PrijavaBtn.Text = "PRIJAVA";
            this.PrijavaBtn.UseVisualStyleBackColor = true;
            this.PrijavaBtn.Click += new System.EventHandler(this.PrijavaBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // prijavaEmailTxtBox
            // 
            this.prijavaEmailTxtBox.Location = new System.Drawing.Point(159, 60);
            this.prijavaEmailTxtBox.Name = "prijavaEmailTxtBox";
            this.prijavaEmailTxtBox.Size = new System.Drawing.Size(147, 22);
            this.prijavaEmailTxtBox.TabIndex = 3;
            // 
            // prijavaPassTxtBox
            // 
            this.prijavaPassTxtBox.Location = new System.Drawing.Point(159, 94);
            this.prijavaPassTxtBox.Name = "prijavaPassTxtBox";
            this.prijavaPassTxtBox.Size = new System.Drawing.Size(147, 22);
            this.prijavaPassTxtBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Še niste prijavljeni?";
            // 
            // prijavaRegBtn
            // 
            this.prijavaRegBtn.Location = new System.Drawing.Point(196, 213);
            this.prijavaRegBtn.Name = "prijavaRegBtn";
            this.prijavaRegBtn.Size = new System.Drawing.Size(110, 31);
            this.prijavaRegBtn.TabIndex = 6;
            this.prijavaRegBtn.Text = "Registracija";
            this.prijavaRegBtn.UseVisualStyleBackColor = true;
            this.prijavaRegBtn.Click += new System.EventHandler(this.prijavaRegBtn_Click);
            // 
            // Prijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 326);
            this.Controls.Add(this.prijavaRegBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.prijavaPassTxtBox);
            this.Controls.Add(this.prijavaEmailTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrijavaBtn);
            this.Name = "Prijava";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrijavaBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox prijavaEmailTxtBox;
        private System.Windows.Forms.TextBox prijavaPassTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button prijavaRegBtn;
    }
}

