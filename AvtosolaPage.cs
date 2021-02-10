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
using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;


namespace miniProjekt___Avtosole {

    public partial class AvtosolaPage : Form {

        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;


        Avtosola sola = new Avtosola();
        List<Kraj> krajceki = new List<Kraj>();
        List<Izpit> izpiti = new List<Izpit>();
        List<Instruktor> instruktorji = new List<Instruktor>();
        string connect = baza.connect();

        public AvtosolaPage(Avtosola neki) {
            InitializeComponent();
            sola = neki;
        }

        private void AvtosolaPage_Load(object sender, EventArgs e) {
            label8.Enabled = false;
            label9.Enabled = false;
            excIzvozTextbox.Enabled = true;
            minStarostIzpitTxt.Enabled = false;
            tipIzpitaTxt.Enabled = false;
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
            izpitiPanel.Enabled = false;
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

            int idKraja = krajceki[urediKrajCombobox.SelectedIndex].ID;
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
            urediKrajCombobox.Items.Clear();

            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM vsiKrajiIzpis()", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    urediKrajCombobox.Items.Add(reader.GetString(1) + " " + reader.GetString(2));

                    Kraj hm = new Kraj(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                    krajceki.Add(hm);
                }
                con.Close();
            }
        }
        private void updateKrajiListInstruktorji() {
            krajceki.Clear();
            instruktorKrajCombobox.Items.Clear();

            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM vsiKrajiIzpis()", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    instruktorKrajCombobox.Items.Add(reader.GetString(1) + " " + reader.GetString(2));

                    Kraj hm = new Kraj(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                    krajceki.Add(hm);
                }
                con.Close();
            }
        }

        private void updateIzpitiList() {
            izpiti.Clear();
            urediIzpitiCombobox.Items.Clear();

            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM vseAvtosoleIzpitiIzpis ('" + sola.ID + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    urediIzpitiCombobox.Items.Add(reader.GetString(1) + " " + reader.GetInt32(2));

                    //string _tip, int _id, int _starostMin, int _avtosolaID
                    Izpit hm = new Izpit(reader.GetString(1), reader.GetInt32(0), reader.GetInt32(2), reader.GetInt32(3));

                    izpiti.Add(hm);
                }
                con.Close();
            }
        }

        private void updateInstruktorjiList() {
            instruktorji.Clear();
            urediINstruktorCombobox.Items.Clear();

            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM instruktorjipodatkiid('" + sola.ID + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    urediINstruktorCombobox.Items.Add(reader.GetString(1) + " " + reader.GetString(2));

                    Instruktor hm = new Instruktor(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6));

                    instruktorji.Add(hm);
                }
                con.Close();
            }
        }

        private void izpitiBtn_Click(object sender, EventArgs e) {
            urediIzpitiCombobox.SelectedIndex = -1;
            urediIzpitiCombobox.Text = "";
            izpitiPanel.Enabled = true;
            dodajIzpitBtn.Enabled = true;
            deleteIzpitBtn.Enabled = false;
            dodajIzpitBtn.Visible = true;
            urediPanel.Enabled = false;
            instruktorjiPanel.Enabled = false;
            izpitiBtn.Enabled = false;
            updateIzpitiList();
        }

        private void instruktorjiBtn_Click(object sender, EventArgs e) {
            updateInstruktorjiList();
            urediINstruktorCombobox.SelectedIndex = -1;
            urediINstruktorCombobox.Text = "";
            urediInstruktorjiBtn.Visible = false;
            dodajInstruktorjaBtn.Visible = true;
            instruktorjiPanel.Enabled = true;
            urediPanel.Enabled = false;
            izpitiPanel.Enabled = false;
            ime.Enabled = false;
            priimek.Enabled = false;
            email.Enabled = false;
            tel.Enabled = false;
            kraj.Enabled = false;
            kraj1.Enabled = false;
            instruktorImeTxt.Enabled = false;
            instruktorPriimekTxt.Enabled = false;
            instruktorEmailTxt.Enabled = false;
            instruktorTelefonTxt.Enabled = false;
            instruktorKrajTxt.Enabled = false;
            instruktorKrajCombobox.Enabled = false;
        }

        private void prekliciIzpitiBtn_Click(object sender, EventArgs e) {
            izpitiPanel.Enabled = false;
            izpitiBtn.Enabled = true;
            updateIzpitiList();
            dodajIzpitBtn.Visible = false;
            urediIzpitBtn.Visible = false;
            label8.Enabled = false;
            label9.Enabled = false;
            minStarostIzpitTxt.Enabled = false;
            tipIzpitaTxt.Enabled = false;
            urediIzpitiCombobox.SelectedIndex = -1;
            urediIzpitiCombobox.Text = "";
            minStarostIzpitTxt.Clear();
            tipIzpitaTxt.Clear();
        }

        private void prekliciInstruktorjiBtn_Click(object sender, EventArgs e) {
            instruktorjiPanel.Enabled = false;
            instruktorjiBtn.Enabled = true;
        }

        private void urediIzpitiCombobox_SelectedIndexChanged(object sender, EventArgs e) {
            label8.Enabled = true;
            label9.Enabled = true;
            deleteIzpitBtn.Enabled = true;
            minStarostIzpitTxt.Enabled = true;
            tipIzpitaTxt.Enabled = true;
            int idIzpita = urediIzpitiCombobox.SelectedIndex;
            minStarostIzpitTxt.Text = Convert.ToString(izpiti[idIzpita].Starost_Min);
            dodajIzpitBtn.Visible = false;
            tipIzpitaTxt.Text = izpiti[idIzpita].Tip;
            urediIzpitBtn.Visible = true;
        }

        private void urediIzpitBtn_Click(object sender, EventArgs e) {
            int idIzpita = urediIzpitiCombobox.SelectedIndex;
            int avtosolaID = izpiti[idIzpita].Avtosola_ID;
            int idI = izpiti[idIzpita].ID;

            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT urediIzpit ('" + idI + "', '" + tipIzpitaTxt.Text + "', '" + Convert.ToInt32(minStarostIzpitTxt.Text) + "')", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    if (reader.GetString(0) == "USPESNO") {
                        MessageBox.Show("Urejevanje uspelo");
                    } else {
                        MessageBox.Show("Neuspesno, Napaka!");
                    }
                }
                con.Close();

                updateIzpitiList();

                izpitiPanel.Enabled = false;
                izpitiBtn.Enabled = true;
                urediIzpitiCombobox.SelectedIndex = -1;
                urediIzpitiCombobox.Text = "";
                label8.Enabled = false;
                label9.Enabled = false;
                minStarostIzpitTxt.Enabled = false;
                tipIzpitaTxt.Enabled = false;
                minStarostIzpitTxt.Clear();
                tipIzpitaTxt.Clear();
            }
        }

        private void dodajIzpitBtn_Click(object sender, EventArgs e) {
            DodajIzpit novIzpit = new DodajIzpit(sola.ID);
            novIzpit.Show();
            this.Hide();
        }

        private void urediINstruktorCombobox_SelectedIndexChanged(object sender, EventArgs e) {
            updateKrajiListInstruktorji();
            int IdInstruktorja = urediINstruktorCombobox.SelectedIndex;
            dodajInstruktorjaBtn.Visible = false; ;
            urediInstruktorjiBtn.Visible = true;
            ime.Enabled = true;
            priimek.Enabled = true;
            email.Enabled = true;
            tel.Enabled = true;
            kraj.Enabled = true;
            kraj1.Enabled = true;
            instruktorImeTxt.Enabled = true;
            instruktorPriimekTxt.Enabled = true;
            instruktorEmailTxt.Enabled = true;
            instruktorTelefonTxt.Enabled = true;
            instruktorKrajTxt.Enabled = true;
            instruktorKrajCombobox.Enabled = true;

            instruktorImeTxt.Text = instruktorji[IdInstruktorja].Ime;
            instruktorPriimekTxt.Text = instruktorji[IdInstruktorja].Priimek;
            instruktorEmailTxt.Text = instruktorji[IdInstruktorja].Email;
            instruktorTelefonTxt.Text = instruktorji[IdInstruktorja].Telefon;

            updateKrajiList();

            for (int i = 0; i < krajceki.Count; i++) {
                if (instruktorji[IdInstruktorja].Kraj_ID == krajceki[i].ID) {
                    instruktorKrajTxt.Text = krajceki[i].Ime + ", " + krajceki[i].Posta;
                }
            }
        }

        private void urediInstruktorjiBtn_Click(object sender, EventArgs e) {
            int idI = urediINstruktorCombobox.SelectedIndex;
            excIzvozTextbox.Enabled = true;
            int idnstruktorja = instruktorji[idI].ID;

            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand com = new NpgsqlCommand("SELECT urediInstruktorja('" + idnstruktorja + "', '" + instruktorImeTxt.Text + "','" + instruktorPriimekTxt.Text + "','" + instruktorEmailTxt.Text + "','" + instruktorTelefonTxt.Text + "','" + Convert.ToInt32(instruktorKrajCombobox.SelectedIndex + 1) + "') ", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    if (reader.GetString(0) == "USPESNO") {
                        MessageBox.Show("Urejevanje uspelo");
                    } else {
                        MessageBox.Show("Neuspesno, Napaka!");
                    }
                }
                con.Close();
                instruktorjiPanel.Enabled = false;
                instruktorjiBtn.Enabled = true;

                updateInstruktorjiList();
                urediINstruktorCombobox.SelectedIndex = -1;
                urediINstruktorCombobox.Text = "";
                urediInstruktorjiBtn.Visible = false;
                dodajInstruktorjaBtn.Visible = true;
                urediPanel.Enabled = false;
                izpitiPanel.Enabled = false;
                ime.Enabled = false;
                priimek.Enabled = false;
                email.Enabled = false;
                tel.Enabled = false;
                kraj.Enabled = false;
                kraj1.Enabled = false;
                instruktorImeTxt.Enabled = false;
                instruktorPriimekTxt.Enabled = false;
                instruktorEmailTxt.Enabled = false;
                instruktorTelefonTxt.Enabled = false;
                instruktorKrajTxt.Enabled = false;
                instruktorKrajCombobox.Enabled = false;

                instruktorImeTxt.Clear();
                instruktorPriimekTxt.Clear();
                instruktorEmailTxt.Clear();
                instruktorTelefonTxt.Clear();
                instruktorKrajTxt.Clear();
                instruktorKrajCombobox.Text = "";
                instruktorKrajCombobox.SelectedIndex = -1;
            }
        }

        private void dodajInstruktorjaBtn_Click(object sender, EventArgs e) {
            DodajInstruktorja page = new DodajInstruktorja(sola.ID);
            page.Show();
            this.Hide();
        }

        private void odjavaBtn_Click(object sender, EventArgs e) {
            Prijava prijava = new Prijava();
            prijava.Show();
            this.Hide();
        }

        private void izpitiPanel_Paint(object sender, PaintEventArgs e) {

        }

        private void deleteIzpitBtn_Click(object sender, EventArgs e) {
            int idI = izpiti[urediIzpitiCombobox.SelectedIndex].ID;
            using (NpgsqlConnection conS = new NpgsqlConnection(connect)) {
                conS.Open();

                NpgsqlCommand comS = new NpgsqlCommand("SELECT izbrisiIzbit('" + idI + "')", conS);
                NpgsqlDataReader readerS = comS.ExecuteReader();
                while (readerS.Read()) {
                    if (readerS.GetString(0) == "USPESNO") {
                        MessageBox.Show("Izpit je bil izbrisan");
                        updateIzpitiList();

                        izpitiPanel.Enabled = false;
                        izpitiBtn.Enabled = true;
                        urediIzpitiCombobox.SelectedIndex = -1;
                        urediIzpitiCombobox.Text = "";
                        label8.Enabled = false;
                        label9.Enabled = false;
                        minStarostIzpitTxt.Enabled = false;
                        tipIzpitaTxt.Enabled = false;
                        minStarostIzpitTxt.Clear();
                        tipIzpitaTxt.Clear();
                    }
                }
                conS.Close();
            }
        }

        private void deleteInstruktorBtn_Click(object sender, EventArgs e) {
            int idI = instruktorji[urediINstruktorCombobox.SelectedIndex].ID;
            using (NpgsqlConnection conS = new NpgsqlConnection(connect)) {
                conS.Open();

                NpgsqlCommand comS = new NpgsqlCommand("SELECT izbrisiInstruktor('" + idI + "')", conS);
                NpgsqlDataReader readerS = comS.ExecuteReader();
                while (readerS.Read()) {
                    if (readerS.GetString(0) == "USPESNO") {
                        MessageBox.Show("Inštruktor je bil izbrisan");
                        instruktorjiPanel.Enabled = false;
                        instruktorjiBtn.Enabled = true;

                        updateInstruktorjiList();
                        urediINstruktorCombobox.SelectedIndex = -1;
                        urediINstruktorCombobox.Text = "";
                        urediInstruktorjiBtn.Visible = false;
                        dodajInstruktorjaBtn.Visible = true;
                        urediPanel.Enabled = false;
                        izpitiPanel.Enabled = false;
                        ime.Enabled = false;
                        priimek.Enabled = false;
                        email.Enabled = false;
                        tel.Enabled = false;
                        kraj.Enabled = false;
                        kraj1.Enabled = false;
                        instruktorImeTxt.Enabled = false;
                        instruktorPriimekTxt.Enabled = false;
                        instruktorEmailTxt.Enabled = false;
                        instruktorTelefonTxt.Enabled = false;
                        instruktorKrajTxt.Enabled = false;
                        instruktorKrajCombobox.Enabled = false;

                        instruktorImeTxt.Clear();
                        instruktorPriimekTxt.Clear();
                        instruktorEmailTxt.Clear();
                        instruktorTelefonTxt.Clear();
                        instruktorKrajTxt.Clear();
                        instruktorKrajCombobox.Text = "";
                        instruktorKrajCombobox.SelectedIndex = -1;
                    }
                }
                conS.Close();
            }
        }

        private void deleteAvtosolaBtn_Click(object sender, EventArgs e) {
            int idA = sola.ID;
            using (NpgsqlConnection conS = new NpgsqlConnection(connect)) {
                conS.Open();

                NpgsqlCommand comS = new NpgsqlCommand("SELECT izbrisiAvtosolo('" + idA + "')", conS);
                NpgsqlDataReader readerS = comS.ExecuteReader();
                while (readerS.Read()) {
                    if (readerS.GetString(0) == "USPESNO") {
                        MessageBox.Show("Avtosola je bila izbrisana");
                        Prijava prijava = new Prijava();
                        prijava.Show();
                        this.Hide();
                    }
                }
                conS.Close();
            }
        }

        private void tipIzpitaTxt_TextChanged(object sender, EventArgs e) {

        }

        private void excelBtn_Click(object sender, EventArgs e) {
            oXL = new Excel.Application();
            oWB = (Excel.Workbook)oXL.Workbooks.Add();
            oSheet = (Excel._Worksheet)oWB.ActiveSheet;

            oSheet.Cells[1, 1] = "Ime";
            oSheet.Cells[1, 2] = "Priimek";
            oSheet.Cells[1, 3] = "Email";
            oSheet.Cells[1, 4] = "Telefon";

            oSheet.get_Range("A1", "F1").Font.Bold = true;
            oSheet.get_Range("A1", "F1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            int naprej1 = 2;

            using (NpgsqlConnection con = new NpgsqlConnection(connect)) {
                con.Open();

                NpgsqlCommand aha = new NpgsqlCommand("SELECT * FROM instruktorjipodatkiid('" + sola.ID + "')", con);
                NpgsqlDataReader pff = aha.ExecuteReader();
                while (pff.Read()) {
                    oSheet.Cells[naprej1, 1] = pff.GetString(1);
                    oSheet.Cells[naprej1, 2] = pff.GetString(2);
                    oSheet.Cells[naprej1, 3] = pff.GetString(3);
                    oSheet.Cells[naprej1, 4] = pff.GetString(4);
                    naprej1++;
                }

                con.Close();

                con.Open();
            }
            oWB.Application.ActiveWorkbook.SaveAs(@"D:\Namizje\" + excIzvozTextbox.Text + ".xlsx");
            excIzvozTextbox.Enabled = false;
            excIzvozTextbox.Clear();
            excelBtn.Enabled = false;
        }

        private void excIzvozTextbox_TextChanged(object sender, EventArgs e) {
            excelBtn.Enabled = true;
        }
    }
}
