using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF19_2019_POP2020.Models
{
    [Serializable]
    public class DomZdravlja
    {
        private string _sifra;

        public string Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
        }

        private string _naziv;

        public string Naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }

        private string _sifraAdrese;

        public string SifraAdrese
        {
            get { return _sifraAdrese; }
            set { _sifraAdrese = value; }
        }


        private bool _aktivan;

        public bool Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
        }


        public string domZdravljaUFajl()
        {
            return Sifra + ";" + Naziv + ";" + SifraAdrese + ";" + Aktivan;
        }


    }
}
