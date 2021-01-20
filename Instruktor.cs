using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniProjekt___Avtosole {
    class Instruktor {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int Kraj_ID { get; set; }
        public int Avtosola_ID { get; set; }

        public Instruktor() : this(0) { }
        public Instruktor(int _id) : this(_id, "") { }
        public Instruktor(int _id, string _ime) : this(_id, _ime, "") { }
        public Instruktor(int _id, string _ime, string _priimek) : this(_id, _ime, _priimek, "") { }
        public Instruktor(int _id, string _ime, string _priimek, string _email) : this(_id, _ime, _priimek, _email, "") { }
        public Instruktor(int _id, string _ime, string _priimek, string _email, string _telefon) : this(_id, _ime, _priimek, _email, _telefon, 0) { }
        public Instruktor(int _id, string _ime, string _priimek, string _email, string _telefon,int _krajID) : this(_id, _ime, _priimek, _email, _telefon, _krajID, 0) { }
        public Instruktor(int _id, string _ime, string _priimek, string _email, string _telefon,int _krajID, int _avtosolaID) {
            this.ID = _id;
            this.Ime = _ime;
            this.Priimek = _priimek;
            this.Email = _email;
            this.Telefon = _telefon;
            this.Kraj_ID = _krajID;
            this.Avtosola_ID = _avtosolaID;
        }

    }
}
