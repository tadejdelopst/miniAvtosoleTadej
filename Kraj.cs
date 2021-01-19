using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniProjekt___Avtosole {
    public class Kraj {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Posta { get; set; }

        public Kraj() : this(0) {}
        public Kraj(int _id) : this(_id, "") {}
        public Kraj(int _id, string _ime) : this(_id, _ime, "") {}
        public Kraj(int _id, string _ime, string _posta) {
            this.ID = _id;
            this.Ime = _ime;
            this.Posta = _posta;
        }
    }
}
