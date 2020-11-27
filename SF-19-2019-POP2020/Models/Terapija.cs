using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF19_2019_POP2020.Models
{
    [Serializable]
    public class Terapija
    {
        private string _sifra;

        public string Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
        }

        private string _opis;

        public string opis
        {
            get { return _opis; }
            set { _opis = value; }
        }

        private string _sifraLekara;

        public string SifraLekara
        {
            get { return _sifraLekara; }
            set { _sifraLekara = value; }
        }

        private string _sifraPacijenta;

        public string SifraPacijenta
        {
            get { return _sifraPacijenta; }
            set { _sifraPacijenta = value; }
        }


        private bool _aktivan;

        public bool Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
        }


        public string terapijaUFajl()
        {
            return Sifra + ";" + opis + ";" + SifraLekara + ";" + SifraPacijenta + ";" + Aktivan;
        }




    }
}
