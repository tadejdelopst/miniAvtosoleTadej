
namespace miniProjekt___Avtosole {
    partial class DodajIzpit {
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
            this.dodajIzpitBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tipIzpitaTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.minStarostIzpitTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // dodajIzpitBtn
            // 
            this.dodajIzpitBtn.Location = new System.Drawing.Point(93, 105);
            this.dodajIzpitBtn.Name = "dodajIzpitBtn";
            this.dodajIzpitBtn.Size = new System.Drawing.Size(110, 40);
            this.dodajIzpitBtn.TabIndex = 45;
            this.dodajIzpitBtn.Text = "Dodaj";
            this.dodajIzpitBtn.UseVisualStyleBackColor = true;
            this.dodajIzpitBtn.Click += new System.EventHandler(this.dodajIzpitBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(90, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "Tip:";
            // 
            // tipIzpitaTxt
            // 
            this.tipIzpitaTxt.Location = new System.Drawing.Point(128, 36);
            this.tipIzpitaTxt.Name = "tipIzpitaTxt";
            this.tipIzpitaTxt.Size = new System.Drawing.Size(100, 22);
            this.tipIzpitaTxt.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 43;
            this.label9.Text = "Min Starost:";
            // 
            // minStarostIzpitTxt
            // 
            this.minStarostIzpitTxt.Location = new System.Drawing.Point(128, 64);
            this.minStarostIzpitTxt.Name = "minStarostIzpitTxt";
            this.minStarostIzpitTxt.Size = new System.Drawing.Size(100, 22);
            this.minStarostIzpitTxt.TabIndex = 44;
            // 
            // DodajIzpit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 204);
            this.Controls.Add(this.dodajIzpitBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tipIzpitaTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.minStarostIzpitTxt);
            this.Name = "DodajIzpit";
            this.Text = "DodajIzpit";
            this.Load += new System.EventHandler(this.DodajIzpit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dodajIzpitBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tipIzpitaTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox minStarostIzpitTxt;
    }
}