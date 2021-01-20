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
    public partial class RegistracijaU : Form {
        public RegistracijaU() {
            InitializeComponent();
        }
        List<Kraj> kraji = new List<Kraj>();
        string connect = baza.connect();

        private void regRegistracijaBtn_Click(object sender, EventArgs e) {
            int idKraja = kraji[regKrajiCombobox.SelectedIndex].ID;

            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT registracijauporabnika('"+ regEmailTextbox.Text + "','" + regPassTextbox.Text + "','"+ regNaslovTextbox.Text + "', '" + Convert.ToInt32(regStarTextbox.Text) + "','" + regTelTextbox.Text + "', '" + idKraja + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    if (reader.GetString(0) == "USPESNO") {
                        MessageBox.Show("Registracija uspela!");
                        Prijava prijava = new Prijava();
                        prijava.Show();
                        this.Hide();
                    } else {
                        MessageBox.Show("Uporabnik s tem emailom že obstaja!");
                    }
                }
                con.Close();
            }
        }

        private void RegistracijaU_Load(object sender, EventArgs e) {
            updateKrajiList();   
        }

        private void updateKrajiList() {
            kraji.Clear();
            regKrajiCombobox.Items.Clear();

            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM vsiKrajiIzpis()", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    regKrajiCombobox.Items.Add(reader.GetString(1) + " " + reader.GetString(2));

                    Kraj hm = new Kraj(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                    kraji.Add(hm);
                }
                con.Close();
            }
        }

        private void prekkliciBtn_Click(object sender, EventArgs e) {
            Prijava prijava = new Prijava();
            prijava.Show();
            this.Hide();
        }
    }
}
