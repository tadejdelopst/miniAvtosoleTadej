using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Configuration;

namespace miniProjekt___Avtosole {
    public partial class Prijava : Form {
        string connect = baza.connect();
        public Prijava() {
            InitializeComponent();
        }

        private void gumb_Click(object sender, EventArgs e) {

        }

        private void prijavaRegBtn_Click(object sender, EventArgs e) {
            RegistracijaU novaReg = new RegistracijaU();
            novaReg.Show();
            this.Hide();
        }

        private void PrijavaBtn_Click(object sender, EventArgs e) {

                using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT prijavauporabnika('"+  prijavaEmailTxtBox.Text +"', '"+  prijavaPassTxtBox.Text +"')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    if (reader.GetString(0) == "USPESNO") {
                        MessageBox.Show("Prijava uspela!");
                    } else {
                        MessageBox.Show("Prijava Neuspesna!");
                    }
                }

                con.Close();
            }
        }
    }
}
