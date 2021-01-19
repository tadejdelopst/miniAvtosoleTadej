using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniProjekt___Avtosole {
    public class Avtosola {
        public int ID { get; set; }
        public int Kraj_ID { get; set; }
        public string Email { get; set; }
        public string Ime { get; set; }
        public string Telefon { get; set; }

        public Avtosola() : this(0) {}
        public Avtosola(int _id) : this(_id, 0) {}
        public Avtosola(int _id, int kraj_id) : this(_id, kraj_id, "") {}
        public Avtosola(int _id, int kraj_id, string _email) : this(_id, kraj_id, _email, "") {}
        public Avtosola(int _id, int kraj_id, string _email, string _ime) : this(_id, kraj_id, _email, _ime, "") {}
        public Avtosola(int _id, int kraj_id, string _email, string _ime, string _telefon) {
            this.ID = _id;
            this.Kraj_ID = kraj_id;
            this.Email = _email;
            this.Ime = _ime;
            this.Telefon = _telefon;
        }
    }
}
