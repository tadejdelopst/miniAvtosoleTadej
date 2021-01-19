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
    public partial class AvtosolaPage : Form {
        Avtosola sola = new Avtosola();
        List<Kraj> krajceki = new List<Kraj>();
        string connect = baza.connect();
        public AvtosolaPage(Avtosola neki) {
            InitializeComponent();
            sola = neki;
        }

        private void AvtosolaPage_Load(object sender, EventArgs e) {
            MessageBox.Show(sola.Email);
        }
    }
}
