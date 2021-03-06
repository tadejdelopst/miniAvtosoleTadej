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
using System.Configuration;
using System.Security.Cryptography;

namespace miniProjekt___Avtosole {
    public partial class UporabnikPage : Form {
        Uporabnik neki = new Uporabnik();
        List<Kraj> krajceki = new List<Kraj>();

        string hash = "f0xle@rn";

        public UporabnikPage(Uporabnik uporabnik) {
            InitializeComponent();
            neki = uporabnik;
        }
        string connect = baza.connect();

        private void urejanjeUserBtn_Click(object sender, EventArgs e) {
            urediPodatkePanel.Enabled = true;
            urejanjeUserBtn.Enabled = false;
        }

        private void updateKrajiList() {
            krajceki.Clear();
            userPgKrajiCombobox.Items.Clear();

            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM vsiKrajiIzpis()", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    userPgKrajiCombobox.Items.Add(reader.GetString(1) + " " + reader.GetString(2));

                    Kraj hm = new Kraj(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                    krajceki.Add(hm);
                }
                con.Close();
            }
        }

        private void UporabnikPage_Load(object sender, EventArgs e) {
            userPgEmailTextbox.Text = neki.Email;
            userPgNaslovTextbox.Text = neki.Naslov;
            userPgStarostTextbox.Text = Convert.ToString(neki.Starost);
            userPgTelefonTextbox.Text = neki.Telefon;
            geslo1Textbox.Text = dekriptiraj(neki.Pass);

            updateKrajiList();

            for (int i = 0; i < krajceki.Count; i++)
            {
                if (krajceki[i].ID == neki.Kraj_ID) {
                    userPgKrajTextbox.Text = krajceki[i].Ime + ", " + krajceki[i].Posta;
                }
            }
        }

        private string dekriptiraj(string geslo) {
            byte[] data = Convert.FromBase64String(geslo);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }) {
                    ICryptoTransform transform = tripleDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    string vrni = UTF8Encoding.UTF8.GetString(results);
                    return vrni;
                }
            }
        }

        private void prekliciUrediUserBtn_Click(object sender, EventArgs e) {
            userPgEmailTextbox.Text = neki.Email;
            userPgNaslovTextbox.Text = neki.Naslov;
            userPgStarostTextbox.Text = Convert.ToString(neki.Starost);
            userPgTelefonTextbox.Text = neki.Telefon;
            urediPodatkePanel.Enabled = false;
            urejanjeUserBtn.Enabled = true;

            updateKrajiList();

            for (int i = 0; i < krajceki.Count; i++) {
                if (krajceki[i].ID == neki.Kraj_ID) {
                    userPgKrajTextbox.Text = krajceki[i].Ime + ", " + krajceki[i].Posta;
                }
            }
        }

        private void urediUserBtn_Click(object sender, EventArgs e) {
            int idKraja = krajceki[userPgKrajiCombobox.SelectedIndex].ID;
            MessageBox.Show(neki.Pass);
            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT urediUporabnika('"+neki.ID+"', '"+userPgEmailTextbox.Text+"', '"+neki.Pass+ "', '" + userPgNaslovTextbox.Text + "', '" + userPgStarostTextbox.Text + "', '" + userPgTelefonTextbox.Text + "', '" + idKraja + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    if (reader.GetString(0) == "USPESNO") {
                        MessageBox.Show("Urejevanje uspelo");
                    } else {
                        MessageBox.Show("Neuspesno, Napaka!");
                    }
                }
                con.Close();
                UporabnikNastavi();

                userPgEmailTextbox.Text = neki.Email;
                userPgNaslovTextbox.Text = neki.Naslov;
                userPgStarostTextbox.Text = Convert.ToString(neki.Starost);
                userPgTelefonTextbox.Text = neki.Telefon;
                urediPodatkePanel.Enabled = false;
                urejanjeUserBtn.Enabled = true;

                updateKrajiList();

                for (int i = 0; i < krajceki.Count; i++) {
                    if (krajceki[i].ID == neki.Kraj_ID) {
                        userPgKrajTextbox.Text = krajceki[i].Ime + ", " + krajceki[i].Posta;
                    }
                }
            }
        }

        public void UporabnikNastavi() {
            using (NpgsqlConnection conS = new NpgsqlConnection(connect)) {
                conS.Open();

                NpgsqlCommand comS = new NpgsqlCommand("SELECT * FROM uporabnikpodatki('" + userPgEmailTextbox.Text + "')", conS);
                NpgsqlDataReader readerS = comS.ExecuteReader();
                while (readerS.Read()) {
                    neki.ID = readerS.GetInt32(0);
                    neki.Email = readerS.GetString(1);
                    neki.Pass = readerS.GetString(2);
                    neki.Starost = readerS.GetInt32(3);
                    neki.Naslov = readerS.GetString(4);
                    neki.Telefon = readerS.GetString(5);
                    neki.Kraj_ID = readerS.GetInt32(6);
                }
                conS.Close();
            }
        }



        private void userPgEditPassBtn_Click(object sender, EventArgs e) {
            editPassPanel.Enabled = true;
            userPgEditPassBtn.Enabled = false;
            geslo1Textbox.Text = dekriptiraj(neki.Pass);
        }

        private void cancelEditPassBtn_Click(object sender, EventArgs e) {
            geslo1Textbox.Clear();
            geslo2Textbox.Clear();
            editPassPanel.Enabled = false;
            userPgEditPassBtn.Enabled = true;
        }

        private string kriptiraj(string geslo) {
            byte[] data = UTF8Encoding.UTF8.GetBytes(geslo);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 }) {
                    ICryptoTransform transform = tripleDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    string vrni = Convert.ToBase64String(results, 0, results.Length);
                    return vrni;
                }
            }
        }

        private void ZamenjajGesloBtn_Click(object sender, EventArgs e) {
            if (geslo1Textbox.Text == geslo2Textbox.Text) {
                int idKraja = neki.Kraj_ID;

                using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                    con.Open();

                    NpgsqlCommand com = new NpgsqlCommand("SELECT urediUporabnika('" + neki.ID + "', '" + userPgEmailTextbox.Text + "', '" + kriptiraj(geslo2Textbox.Text) + "', '" + userPgNaslovTextbox.Text + "', '" + userPgStarostTextbox.Text + "', '" + userPgTelefonTextbox.Text + "', '" + idKraja + "')", con);
                    NpgsqlDataReader reader = com.ExecuteReader();
                    while (reader.Read()) {
                        if (reader.GetString(0) == "USPESNO") {
                            MessageBox.Show("Geslo posodobljeno!");
                        } else {
                            MessageBox.Show("Neuspesna zamenjava, Napaka!");
                        }
                    }
                    con.Close();
                    UporabnikNastavi();

                    userPgEmailTextbox.Text = neki.Email;
                    userPgNaslovTextbox.Text = neki.Naslov;
                    userPgStarostTextbox.Text = Convert.ToString(neki.Starost);
                    userPgTelefonTextbox.Text = neki.Telefon;
                    urediPodatkePanel.Enabled = false;
                    urejanjeUserBtn.Enabled = true;

                    updateKrajiList();

                    for (int i = 0; i < krajceki.Count; i++) {
                        if (krajceki[i].ID == neki.Kraj_ID) {
                            userPgKrajTextbox.Text = krajceki[i].Ime + ", " + krajceki[i].Posta;
                        }
                    }
                }
                geslo1Textbox.Clear();
                geslo2Textbox.Clear();
                userPgEditPassBtn.Enabled = true;
                geslo1Textbox.Text = neki.Pass;
                editPassPanel.Enabled = false;
            }
        }

        private void odjavaBtn_Click(object sender, EventArgs e) {
            Prijava prijava = new Prijava();
            prijava.Show();
            this.Hide();
        }

        private void geslo2Textbox_TextChanged(object sender, EventArgs e) {

        }

        private void deleteUserBtn_Click(object sender, EventArgs e) {
            int idU = neki.ID;
            using (NpgsqlConnection conS = new NpgsqlConnection(connect)) {
                conS.Open();

                NpgsqlCommand comS = new NpgsqlCommand("SELECT izbrisiUporabnika('"+idU+"')", conS);
                NpgsqlDataReader readerS = comS.ExecuteReader();
                while (readerS.Read()) {
                    if(readerS.GetString(0) == "USPESNO") {
                        MessageBox.Show("Uporabnik je bil izbrisan");
                        Prijava prijava = new Prijava();
                        prijava.Show();
                        this.Hide();
                    }
                }
                conS.Close();
            }
        }

        private void editPassPanel_Paint(object sender, PaintEventArgs e) {

        }
    }
}
