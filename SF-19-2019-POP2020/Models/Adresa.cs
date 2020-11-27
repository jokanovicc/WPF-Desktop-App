using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_19_2019_POP2020.Models
{
    [Serializable]
    public class Adresa
    {
        private string _sifraAdrese;

        public string SifraAdrese
        {
            get { return _sifraAdrese; }
            set { _sifraAdrese = value; }
        }

        private string _ulica;

        public string Ulica
        {
            get { return _ulica; }
            set { _ulica = value; }
        }

        private string _broj;

        public string Broj
        {
            get { return _broj; }
            set { _broj = value; }
        }

        private string _drzava;

        public string Drzava
        {
            get { return _drzava; }
            set { _drzava = value; }
        }

        private string _grad;

        public string Grad
        {
            get { return _grad; }
            set { _grad = value; }
        }

        private bool _aktivan;
        public bool Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
        }


        public override string ToString()
        {
            return "Ulica " + Ulica + " broj " + Broj + "Grad " + Grad + " Drzava " + Drzava;
        }

        public string AdresaUFajl()
        {
            return SifraAdrese + ";" + Ulica + ";" + Broj + ";" + Drzava + ";" + Grad + ";" + Aktivan;

        }

    }
}
