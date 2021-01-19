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
        Uporabnik user = new Uporabnik();
        int check = 0;

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

        public void UporabnikNastavi() {
            using (NpgsqlConnection conS = new NpgsqlConnection(connect)) {
                conS.Open();

                NpgsqlCommand comS = new NpgsqlCommand("SELECT * FROM uporabnikpodatki('" + prijavaEmailTxtBox.Text + "')", conS);
                NpgsqlDataReader readerS = comS.ExecuteReader();
                while (readerS.Read()) {
                    user.ID = readerS.GetInt32(0);
                    user.Email = readerS.GetString(1);
                    user.Pass = readerS.GetString(2);
                    user.Starost = readerS.GetInt32(3);
                    user.Naslov = readerS.GetString(4);
                    user.Telefon = readerS.GetString(5);
                    user.Kraj_ID = readerS.GetInt32(6);
                }
                conS.Close();
            }
        }

        private void PrijavaBtn_Click(object sender, EventArgs e) {

                using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT prijavauporabnika('"+  prijavaEmailTxtBox.Text +"', '"+  prijavaPassTxtBox.Text +"')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    if (reader.GetString(0) == "USPESNO") {
                        check = 1;
                    } else {
                        MessageBox.Show("Prijava Neuspesna!");
                    }
                }
                con.Close();
            }
                if(check == 1) {
                UporabnikNastavi();
                MessageBox.Show(user.Pass);
                MessageBox.Show("Prijava uspela!");
                UporabnikPage uporanbikPage = new UporabnikPage(user);
                uporanbikPage.Show();
                this.Hide();
            }
        }
    }
}
