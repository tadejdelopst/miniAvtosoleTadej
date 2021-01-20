
namespace miniProjekt___Avtosole {
    partial class DodajInstruktorja {
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
            this.instruktorTelefonTxt = new System.Windows.Forms.TextBox();
            this.tel = new System.Windows.Forms.Label();
            this.instruktorImeTxt = new System.Windows.Forms.TextBox();
            this.kraj1 = new System.Windows.Forms.Label();
            this.instruktorEmailTxt = new System.Windows.Forms.TextBox();
            this.instruktorKrajCombobox = new System.Windows.Forms.ComboBox();
            this.ime = new System.Windows.Forms.Label();
            this.instruktorPriimekTxt = new System.Windows.Forms.TextBox();
            this.priimek = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.Label();
            this.dodajGaBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // instruktorTelefonTxt
            // 
            this.instruktorTelefonTxt.Location = new System.Drawing.Point(108, 115);
            this.instruktorTelefonTxt.Name = "instruktorTelefonTxt";
            this.instruktorTelefonTxt.Size = new System.Drawing.Size(147, 22);
            this.instruktorTelefonTxt.TabIndex = 48;
            // 
            // tel
            // 
            this.tel.AutoSize = true;
            this.tel.Location = new System.Drawing.Point(38, 118);
            this.tel.Name = "tel";
            this.tel.Size = new System.Drawing.Size(60, 17);
            this.tel.TabIndex = 49;
            this.tel.Text = "Telefon:";
            // 
            // instruktorImeTxt
            // 
            this.instruktorImeTxt.Location = new System.Drawing.Point(108, 29);
            this.instruktorImeTxt.Name = "instruktorImeTxt";
            this.instruktorImeTxt.Size = new System.Drawing.Size(147, 22);
            this.instruktorImeTxt.TabIndex = 42;
            // 
            // kraj1
            // 
            this.kraj1.AutoSize = true;
            this.kraj1.Location = new System.Drawing.Point(68, 146);
            this.kraj1.Name = "kraj1";
            this.kraj1.Size = new System.Drawing.Size(37, 17);
            this.kraj1.TabIndex = 41;
            this.kraj1.Text = "Kraj:";
            // 
            // instruktorEmailTxt
            // 
            this.instruktorEmailTxt.Location = new System.Drawing.Point(108, 85);
            this.instruktorEmailTxt.Name = "instruktorEmailTxt";
            this.instruktorEmailTxt.Size = new System.Drawing.Size(147, 22);
            this.instruktorEmailTxt.TabIndex = 46;
            // 
            // instruktorKrajCombobox
            // 
            this.instruktorKrajCombobox.FormattingEnabled = true;
            this.instruktorKrajCombobox.Location = new System.Drawing.Point(108, 143);
            this.instruktorKrajCombobox.Name = "instruktorKrajCombobox";
            this.instruktorKrajCombobox.Size = new System.Drawing.Size(152, 24);
            this.instruktorKrajCombobox.TabIndex = 40;
            // 
            // ime
            // 
            this.ime.AutoSize = true;
            this.ime.Location = new System.Drawing.Point(68, 34);
            this.ime.Name = "ime";
            this.ime.Size = new System.Drawing.Size(34, 17);
            this.ime.TabIndex = 43;
            this.ime.Text = "Ime:";
            // 
            // instruktorPriimekTxt
            // 
            this.instruktorPriimekTxt.Location = new System.Drawing.Point(108, 59);
            this.instruktorPriimekTxt.Name = "instruktorPriimekTxt";
            this.instruktorPriimekTxt.Size = new System.Drawing.Size(147, 22);
            this.instruktorPriimekTxt.TabIndex = 44;
            // 
            // priimek
            // 
            this.priimek.AutoSize = true;
            this.priimek.Location = new System.Drawing.Point(45, 62);
            this.priimek.Name = "priimek";
            this.priimek.Size = new System.Drawing.Size(58, 17);
            this.priimek.TabIndex = 45;
            this.priimek.Text = "Priimek:";
            // 
            // email
            // 
            this.email.AutoSize = true;
            this.email.Location = new System.Drawing.Point(56, 90);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(46, 17);
            this.email.TabIndex = 47;
            this.email.Text = "Email:";
            // 
            // dodajGaBtn
            // 
            this.dodajGaBtn.Location = new System.Drawing.Point(86, 188);
            this.dodajGaBtn.Name = "dodajGaBtn";
            this.dodajGaBtn.Size = new System.Drawing.Size(118, 43);
            this.dodajGaBtn.TabIndex = 50;
            this.dodajGaBtn.Text = "Dodaj";
            this.dodajGaBtn.UseVisualStyleBackColor = true;
            this.dodajGaBtn.Click += new System.EventHandler(this.dodajGaBtn_Click);
            // 
            // DodajInstruktorja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 330);
            this.Controls.Add(this.dodajGaBtn);
            this.Controls.Add(this.instruktorTelefonTxt);
            this.Controls.Add(this.tel);
            this.Controls.Add(this.instruktorImeTxt);
            this.Controls.Add(this.kraj1);
            this.Controls.Add(this.instruktorEmailTxt);
            this.Controls.Add(this.instruktorKrajCombobox);
            this.Controls.Add(this.ime);
            this.Controls.Add(this.instruktorPriimekTxt);
            this.Controls.Add(this.priimek);
            this.Controls.Add(this.email);
            this.Name = "DodajInstruktorja";
            this.Text = "DodajInstruktorja";
            this.Load += new System.EventHandler(this.DodajInstruktorja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox instruktorTelefonTxt;
        private System.Windows.Forms.Label tel;
        private System.Windows.Forms.TextBox instruktorImeTxt;
        private System.Windows.Forms.Label kraj1;
        private System.Windows.Forms.TextBox instruktorEmailTxt;
        private System.Windows.Forms.ComboBox instruktorKrajCombobox;
        private System.Windows.Forms.Label ime;
        private System.Windows.Forms.TextBox instruktorPriimekTxt;
        private System.Windows.Forms.Label priimek;
        private System.Windows.Forms.Label email;
        private System.Windows.Forms.Button dodajGaBtn;
    }
}