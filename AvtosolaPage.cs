﻿using System;
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
    public partial class AvtosolaPage : Form {
        Avtosola sola = new Avtosola();
        List<Kraj> krajceki = new List<Kraj>();
        string connect = baza.connect();
        public AvtosolaPage(Avtosola neki) {
            InitializeComponent();
            sola = neki;
        }

        private void AvtosolaPage_Load(object sender, EventArgs e) {
            avtoEmailTxt.Text = sola.Email;
            avtoImeTxt.Text = sola.Ime;
            avtoTelTxt.Text = sola.Telefon;

            updateKrajiList();

            for (int i = 0; i < krajceki.Count; i++) {
                if (krajceki[i].ID == sola.Kraj_ID) {
                    urediKrajTxt.Text = krajceki[i].Ime + ", " + krajceki[i].Posta;
                }
            }
        }

        private void urediPodatkeBtn_Click(object sender, EventArgs e) {
            urediPanel.Enabled = true;
            urediPodatkeBtn.Enabled = false;
            }

        public void AvtosolakNastavi() {
            using (NpgsqlConnection conS = new NpgsqlConnection(connect)) {
                conS.Open();

                NpgsqlCommand comS = new NpgsqlCommand("SELECT * FROM avtosolapodatki('" + avtoEmailTxt.Text + "')", conS);
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

        private void preklicUrediBtn_Click(object sender, EventArgs e) {
            urediPanel.Enabled = false;
            urediPodatkeBtn.Enabled = true;
            avtoEmailTxt.Text = sola.Email;
            avtoImeTxt.Text = sola.Ime;
            avtoTelTxt.Text = sola.Telefon;

            updateKrajiList();

            for (int i = 0; i < krajceki.Count; i++) {
                if (krajceki[i].ID == sola.Kraj_ID) {
                    urediKrajTxt.Text = krajceki[i].Ime + ", " + krajceki[i].Posta;
                }
            }
        }

        private void urediAvtosolaBtn_Click(object sender, EventArgs e) {
            urediPanel.Enabled = false;
            urediPodatkeBtn.Enabled = true;

            int idKraja = krajceki[urediKrajiCombobox.SelectedIndex].ID;
            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT urediAvtosolo('" + sola.ID + "', '" + avtoEmailTxt.Text + "', '" + avtoImeTxt.Text + "', '" + avtoTelTxt.Text + "', '" + idKraja + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    if (reader.GetString(0) == "USPESNO") {
                        MessageBox.Show("Urejevanje uspelo");
                    } else {
                        MessageBox.Show("Neuspesno, Napaka!");
                    }
                }
                con.Close();

                AvtosolakNastavi();

                avtoEmailTxt.Text = sola.Email;
                avtoImeTxt.Text = sola.Ime;
                avtoTelTxt.Text = sola.Telefon;

                updateKrajiList();

                for (int i = 0; i < krajceki.Count; i++) {
                    if (krajceki[i].ID == sola.Kraj_ID) {
                        urediKrajTxt.Text = krajceki[i].Ime + ", " + krajceki[i].Posta;
                    }
                }
            }
        }

        private void updateKrajiList() {
            krajceki.Clear();
            urediKrajiCombobox.Items.Clear();

            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM vsiKrajiIzpis()", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    urediKrajiCombobox.Items.Add(reader.GetString(1) + " " + reader.GetString(2));

                    Kraj hm = new Kraj(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                    krajceki.Add(hm);
                }
                con.Close();
            }
        }
    }
}
