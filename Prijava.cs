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
using System.Security.Cryptography;

namespace miniProjekt___Avtosole {
    public partial class Prijava : Form {

        string hash = "f0xle@rn";
        string connect = baza.connect();
        Uporabnik user = new Uporabnik();
        Avtosola sola = new Avtosola();
        int check = 0;
        int check2 = 0;

        public Prijava() {
            InitializeComponent();
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

                NpgsqlCommand com = new NpgsqlCommand("SELECT prijavauporabnika('"+  prijavaEmailTxtBox.Text +"', '"+  kriptiraj(prijavaPassTxtBox.Text) +"')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    if (reader.GetString(0) == "USPESNO") {
                        check = 1;
                    } else if (reader.GetString(0) == "NEUSPESNO") {
                        MessageBox.Show("Prijava Neuspesna!");
                        prijavaEmailTxtBox.Clear();
                        prijavaPassTxtBox.Clear();
                    }
                }
                con.Close();
            }
                if(check == 1) {
                UporabnikNastavi();
                MessageBox.Show("Prijava uspela!");
                UporabnikPage uporanbikPage = new UporabnikPage(user);
                uporanbikPage.Show();
                this.Hide();
            }
        }

        private void uporabnikBtn_Click(object sender, EventArgs e) {
            prijavaPanel.Visible = true;
            prekliciBtn.Enabled = true;
            prekliciBtn.Visible = true;
            avtosolaBtn.Enabled = false;
            uporabnikBtn.Enabled = false;
            prijavaAvtoPanel.Enabled = false;
            prijavaAvtoPanel.Visible = false;
        }

        private void prekliciBtn_Click(object sender, EventArgs e) {
            prekliciBtn.Enabled = false;
            prekliciBtn.Visible = false;
            avtosolaBtn.Enabled = true;
            uporabnikBtn.Enabled = true;
            prijavaPanel.Visible = false;
            prijavaAvtoPanel.Visible = false;
        }

        private void avtosolaBtn_Click(object sender, EventArgs e) {
            avtosolaBtn.Enabled = false;
            prekliciBtn.Enabled = true;
            prekliciBtn.Visible = true;
            uporabnikBtn.Enabled = false;
            prijavaPanel.Enabled = false;
            prijavaAvtoPanel.Enabled = true;
            prijavaAvtoPanel.Visible = true;
            prijavaPanel.Visible = false;
            prijavaPassTxtBox.Visible = false;
        }

        private void registracijaAvtoBtn_Click(object sender, EventArgs e) {
            RegistracijaAvto novaReg = new RegistracijaAvto();
            novaReg.Show();
            this.Hide();
        }

        private void prijavaAvtoBtn_Click(object sender, EventArgs e) {
            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT prijavaAvtosole('" + prijavaAvtoEmailTextbox.Text + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    if (reader.GetString(0) == "USPESNO") {
                        check2 = 1;
                    } else if (reader.GetString(0) == "NEUSPESNO") {
                        MessageBox.Show("Prijava Neuspesna!");
                        prijavaAvtoEmailTextbox.Clear();
                    }
                }
                con.Close();
            }
            if (check2 == 1) {
                AvtosolakNastavi();
                MessageBox.Show("Prijava uspela!");
                AvtosolaPage avtosolaPage = new AvtosolaPage(sola);
                avtosolaPage.Show();
                this.Hide();
            }
        }

        public void AvtosolakNastavi() {
            using (NpgsqlConnection conS = new NpgsqlConnection(connect)) {
                conS.Open();

                NpgsqlCommand comS = new NpgsqlCommand("SELECT * FROM avtosolapodatki('" + prijavaAvtoEmailTextbox.Text + "')", conS);
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

        private void Prijava_Load(object sender, EventArgs e) {

        }

        private void regAvtoIzpitBtn_Click(object sender, EventArgs e) {
            RegAvtoIzpit regAvtoIzpit = new RegAvtoIzpit();
            regAvtoIzpit.Show();
            this.Hide();
        }
    }
}
