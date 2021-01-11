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
    public partial class Form1 : Form {
        string connect = baza.connect();
        public Form1() {
            InitializeComponent();
        }

        private void gumb_Click(object sender, EventArgs e) {
            gumb.Text = "Evoga!";
            gumb.Text = "Evoga2!";
        }
    }
}
