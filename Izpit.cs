using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniProjekt___Avtosole {
    public class Izpit {
        public string Tip { get; set; }
        public int ID { get; set; }
        public int Starost_Min { get; set; }
        public int Avtosola_ID { get; set; }

        public Izpit() : this("") { }
        public Izpit(string _tip) : this(_tip, 0) { }
        public Izpit(string _tip, int _id) : this(_tip, _id, 0) { }
        public Izpit(string _tip, int _id, int _starostMin) : this(_tip, _id, _starostMin, 0) { }
        public Izpit(string _tip, int _id, int _starostMin, int _avtosolaID) {
            this.Tip = _tip;
            this.ID = _id;
            this.Starost_Min = _starostMin;
            this.Avtosola_ID = _avtosolaID;
        }
    }
}
