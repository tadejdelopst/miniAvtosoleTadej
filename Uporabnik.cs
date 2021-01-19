using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniProjekt___Avtosole {
    public class Uporabnik {
        public string Email { get; set; }
        public string Pass { get; set; }
        public int Starost { get; set; }
        public string Naslov { get; set; }
        public string Telefon { get; set; }
        public int Kraj_ID { get; set; }
        public int ID { get; set; }

        public Uporabnik() : this("") {

        }
        public Uporabnik(string _email) : this(_email, "") {

        }
        public Uporabnik(string _email, string _pass) : this(_email, _pass, 0) {

        }
        public Uporabnik(string _email, string _pass, int _starost) : this(_email, _pass, _starost, "") {

        }
        public Uporabnik(string _email, string _pass, int _starost, string _naslov) : this(_email, _pass, _starost, _naslov, "") {

        }
        public Uporabnik(string _email, string _pass, int _starost, string _naslov, string _telefon) : this(_email, _pass, _starost, _naslov, _telefon, 0) {

        }
        public Uporabnik(string _email, string _pass, int _starost, string _naslov, string _telefon, int _kraj_ID) : this(_email, _pass, _starost, _naslov, _telefon, _kraj_ID, 0) {
        }
        public Uporabnik(string _email, string _pass, int _starost, string _naslov, string _telefon, int _kraj_ID, int _id) {
            this.Email = _email;
            this.Pass = _pass;
            this.Starost = _starost;
            this.Naslov = _naslov;
            this.Telefon = _telefon;
            this.Kraj_ID = _kraj_ID;
            this.ID = _id;
        }

    }
}
