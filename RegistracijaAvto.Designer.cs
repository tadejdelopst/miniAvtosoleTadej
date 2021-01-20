
namespace miniProjekt___Avtosole {
    partial class RegistracijaAvto {
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
            this.label7 = new System.Windows.Forms.Label();
            this.regTelTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.regImeTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.regEmailTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.regKrajiCombobox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.regRegistracijaBtn = new System.Windows.Forms.Button();
            this.odjavaBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 17);
            this.label7.TabIndex = 19;
            this.label7.Text = "Obvezni Podatki:";
            // 
            // regTelTextbox
            // 
            this.regTelTextbox.Location = new System.Drawing.Point(394, 73);
            this.regTelTextbox.Name = "regTelTextbox";
            this.regTelTextbox.Size = new System.Drawing.Size(100, 22);
            this.regTelTextbox.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(328, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Telefon:";
            // 
            // regImeTextbox
            // 
            this.regImeTextbox.Location = new System.Drawing.Point(133, 103);
            this.regImeTextbox.Name = "regImeTextbox";
            this.regImeTextbox.Size = new System.Drawing.Size(100, 22);
            this.regImeTextbox.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ime:";
            // 
            // regEmailTextbox
            // 
            this.regEmailTextbox.Location = new System.Drawing.Point(133, 75);
            this.regEmailTextbox.Name = "regEmailTextbox";
            this.regEmailTextbox.Size = new System.Drawing.Size(100, 22);
            this.regEmailTextbox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Email:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(348, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Neobvezni Podatki:";
            // 
            // regKrajiCombobox
            // 
            this.regKrajiCombobox.FormattingEnabled = true;
            this.regKrajiCombobox.Location = new System.Drawing.Point(100, 131);
            this.regKrajiCombobox.Name = "regKrajiCombobox";
            this.regKrajiCombobox.Size = new System.Drawing.Size(152, 24);
            this.regKrajiCombobox.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Kraj:";
            // 
            // regRegistracijaBtn
            // 
            this.regRegistracijaBtn.Location = new System.Drawing.Point(358, 117);
            this.regRegistracijaBtn.Name = "regRegistracijaBtn";
            this.regRegistracijaBtn.Size = new System.Drawing.Size(120, 50);
            this.regRegistracijaBtn.TabIndex = 23;
            this.regRegistracijaBtn.Text = "Registracija";
            this.regRegistracijaBtn.UseVisualStyleBackColor = true;
            this.regRegistracijaBtn.Click += new System.EventHandler(this.regRegistracijaBtn_Click);
            // 
            // odjavaBtn
            // 
            this.odjavaBtn.Location = new System.Drawing.Point(493, 117);
            this.odjavaBtn.Name = "odjavaBtn";
            this.odjavaBtn.Size = new System.Drawing.Size(112, 50);
            this.odjavaBtn.TabIndex = 24;
            this.odjavaBtn.Text = "Prekliči";
            this.odjavaBtn.UseVisualStyleBackColor = true;
            this.odjavaBtn.Click += new System.EventHandler(this.odjavaBtn_Click);
            // 
            // RegistracijaAvto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 223);
            this.Controls.Add(this.odjavaBtn);
            this.Controls.Add(this.regRegistracijaBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.regKrajiCombobox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.regTelTextbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.regImeTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.regEmailTextbox);
            this.Controls.Add(this.label1);
            this.Name = "RegistracijaAvto";
            this.Text = "RegistracijaAvto";
            this.Load += new System.EventHandler(this.RegistracijaAvto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox regTelTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox regImeTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox regEmailTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox regKrajiCombobox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button regRegistracijaBtn;
        private System.Windows.Forms.Button odjavaBtn;
    }
}