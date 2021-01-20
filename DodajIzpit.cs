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

namespace miniProjekt___Avtosole {
    public partial class DodajIzpit : Form {
        string connect = baza.connect();
        int avtosolaID;
        int check = 0;
        Avtosola sola = new Avtosola();

        public DodajIzpit(int idA) {
            InitializeComponent();
            avtosolaID = idA;
        }

        private void DodajIzpit_Load(object sender, EventArgs e) {

        }

        private void dodajIzpitBtn_Click(object sender, EventArgs e) {
            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT dodajIzpit ('"+avtosolaID+"', '"+tipIzpitaTxt.Text+"', '"+Convert.ToInt32(minStarostIzpitTxt.Text)+"')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    if (reader.GetString(0) == "USPESNO") {
                        MessageBox.Show("Dodajanje Uspelo!");
                        check = 1;
                    } else if (reader.GetString(0) == "NEUSPESNO") {
                        MessageBox.Show("Dodajanje Neuspelo!");
                        tipIzpitaTxt.Clear();
                        minStarostIzpitTxt.Clear();
                    }
                }
                con.Close();
                if (check == 1) {
                    AvtosolakNastavi();
                    AvtosolaPage avto = new AvtosolaPage(sola);
                    this.Hide();
                    avto.Show();
                }
            }
        }

        public void AvtosolakNastavi() {
            using (NpgsqlConnection conS = new NpgsqlConnection(connect)) {
                conS.Open();

                NpgsqlCommand comS = new NpgsqlCommand("SELECT * FROM avtosolapodatkiid ('"+avtosolaID+"')", conS);
                NpgsqlDataReader readerS = comS.ExecuteReader();
                while (readerS.Read()) {
                    sola.ID = readerS.GetInt32(0);
                    sola.Kraj_ID = readerS.GetInt32(4);
                    sola.Ime = readerS.GetString(1);
                    sola.Email = readerS.GetString(2);
                    sola.Telefon = readerS.GetString(3);
                }
                conS.Close();
            }
        }
    }
}
