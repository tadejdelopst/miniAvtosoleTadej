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
    public partial class RegAvtoIzpit : Form {
        string connect = baza.connect();
        List<Kraj> kraji = new List<Kraj>();

        public RegAvtoIzpit() {
            InitializeComponent();
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

        private void label5_Click(object sender, EventArgs e) {

        }

        private void dodajIzpitBtn_Click(object sender, EventArgs e) {
            int idK = kraji[regKrajiCombobox.SelectedIndex].ID;
            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT dodajDveTabeli ('"+regEmailTextbox.Text+"', '"+regImeTextbox.Text+"', '"+idK+"', '"+regTelTextbox.Text+"', '"+tipIzpitaTxt.Text+"', '"+Convert.ToInt32(minStarostIzpitTxt.Text) +"' )", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    if (reader.GetString(0) == "USPESNO") {
                        MessageBox.Show("Registracija avtosole + dodan izpit Uspelo!");
                        Prijava prijava = new Prijava();
                        prijava.Show();
                        this.Hide();
                    } else if (reader.GetString(0) == "NEUSPESNO") {
                        MessageBox.Show("Registracija avtosole + dodajanje izpita Neuspelo!");
                        tipIzpitaTxt.Clear();
                        minStarostIzpitTxt.Clear();
                    }
                }
                con.Close();
            }
        }

        private void preklicBtn_Click(object sender, EventArgs e) {
            Prijava prijava = new Prijava();
            prijava.Show();
            this.Hide();
        }

        private void RegAvtoIzpit_Load(object sender, EventArgs e) {
            updateKrajiList();
        }
    }
}
