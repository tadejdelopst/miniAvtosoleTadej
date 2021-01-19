
namespace miniProjekt___Avtosole {
    partial class AvtosolaPage {
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
            this.label6 = new System.Windows.Forms.Label();
            this.urediKrajiCombobox = new System.Windows.Forms.ComboBox();
            this.avtoTelTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.avtoImeTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.avtoEmailTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.urediPanel = new System.Windows.Forms.Panel();
            this.urediAvtosolaBtn = new System.Windows.Forms.Button();
            this.urediPodatkeBtn = new System.Windows.Forms.Button();
            this.preklicUrediBtn = new System.Windows.Forms.Button();
            this.urediKrajTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.urediPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "Kraj:";
            // 
            // urediKrajiCombobox
            // 
            this.urediKrajiCombobox.FormattingEnabled = true;
            this.urediKrajiCombobox.Location = new System.Drawing.Point(98, 139);
            this.urediKrajiCombobox.Name = "urediKrajiCombobox";
            this.urediKrajiCombobox.Size = new System.Drawing.Size(152, 24);
            this.urediKrajiCombobox.TabIndex = 29;
            // 
            // avtoTelTxt
            // 
            this.avtoTelTxt.Location = new System.Drawing.Point(112, 83);
            this.avtoTelTxt.Name = "avtoTelTxt";
            this.avtoTelTxt.Size = new System.Drawing.Size(100, 22);
            this.avtoTelTxt.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Telefon:";
            // 
            // avtoImeTxt
            // 
            this.avtoImeTxt.Location = new System.Drawing.Point(112, 55);
            this.avtoImeTxt.Name = "avtoImeTxt";
            this.avtoImeTxt.Size = new System.Drawing.Size(100, 22);
            this.avtoImeTxt.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ime:";
            // 
            // avtoEmailTxt
            // 
            this.avtoEmailTxt.Location = new System.Drawing.Point(112, 27);
            this.avtoEmailTxt.Name = "avtoEmailTxt";
            this.avtoEmailTxt.Size = new System.Drawing.Size(100, 22);
            this.avtoEmailTxt.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Email:";
            // 
            // urediPanel
            // 
            this.urediPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.urediPanel.Controls.Add(this.urediKrajTxt);
            this.urediPanel.Controls.Add(this.label3);
            this.urediPanel.Controls.Add(this.preklicUrediBtn);
            this.urediPanel.Controls.Add(this.urediAvtosolaBtn);
            this.urediPanel.Controls.Add(this.label1);
            this.urediPanel.Controls.Add(this.label6);
            this.urediPanel.Controls.Add(this.avtoEmailTxt);
            this.urediPanel.Controls.Add(this.urediKrajiCombobox);
            this.urediPanel.Controls.Add(this.label2);
            this.urediPanel.Controls.Add(this.avtoTelTxt);
            this.urediPanel.Controls.Add(this.avtoImeTxt);
            this.urediPanel.Controls.Add(this.label5);
            this.urediPanel.Enabled = false;
            this.urediPanel.Location = new System.Drawing.Point(32, 96);
            this.urediPanel.Name = "urediPanel";
            this.urediPanel.Size = new System.Drawing.Size(269, 271);
            this.urediPanel.TabIndex = 31;
            // 
            // urediAvtosolaBtn
            // 
            this.urediAvtosolaBtn.Location = new System.Drawing.Point(24, 193);
            this.urediAvtosolaBtn.Name = "urediAvtosolaBtn";
            this.urediAvtosolaBtn.Size = new System.Drawing.Size(110, 40);
            this.urediAvtosolaBtn.TabIndex = 31;
            this.urediAvtosolaBtn.Text = "Uredi";
            this.urediAvtosolaBtn.UseVisualStyleBackColor = true;
            this.urediAvtosolaBtn.Click += new System.EventHandler(this.urediAvtosolaBtn_Click);
            // 
            // urediPodatkeBtn
            // 
            this.urediPodatkeBtn.Location = new System.Drawing.Point(107, 50);
            this.urediPodatkeBtn.Name = "urediPodatkeBtn";
            this.urediPodatkeBtn.Size = new System.Drawing.Size(110, 40);
            this.urediPodatkeBtn.TabIndex = 32;
            this.urediPodatkeBtn.Text = "Uredi Podatke";
            this.urediPodatkeBtn.UseVisualStyleBackColor = true;
            this.urediPodatkeBtn.Click += new System.EventHandler(this.urediPodatkeBtn_Click);
            // 
            // preklicUrediBtn
            // 
            this.preklicUrediBtn.Location = new System.Drawing.Point(140, 193);
            this.preklicUrediBtn.Name = "preklicUrediBtn";
            this.preklicUrediBtn.Size = new System.Drawing.Size(110, 40);
            this.preklicUrediBtn.TabIndex = 32;
            this.preklicUrediBtn.Text = "Prekliči";
            this.preklicUrediBtn.UseVisualStyleBackColor = true;
            this.preklicUrediBtn.Click += new System.EventHandler(this.preklicUrediBtn_Click);
            // 
            // urediKrajTxt
            // 
            this.urediKrajTxt.Location = new System.Drawing.Point(112, 111);
            this.urediKrajTxt.Name = "urediKrajTxt";
            this.urediKrajTxt.Size = new System.Drawing.Size(100, 22);
            this.urediKrajTxt.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Kraj:";
            // 
            // AvtosolaPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.urediPodatkeBtn);
            this.Controls.Add(this.urediPanel);
            this.Name = "AvtosolaPage";
            this.Text = "AvtosolaPage";
            this.Load += new System.EventHandler(this.AvtosolaPage_Load);
            this.urediPanel.ResumeLayout(false);
            this.urediPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox urediKrajiCombobox;
        private System.Windows.Forms.TextBox avtoTelTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox avtoImeTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox avtoEmailTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel urediPanel;
        private System.Windows.Forms.Button urediAvtosolaBtn;
        private System.Windows.Forms.Button urediPodatkeBtn;
        private System.Windows.Forms.Button preklicUrediBtn;
        private System.Windows.Forms.TextBox urediKrajTxt;
        private System.Windows.Forms.Label label3;
    }
}