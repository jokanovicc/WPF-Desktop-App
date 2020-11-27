using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF19_2019_POP2020.Models
{
    [Serializable]
    public class Termin
    {
        private string _sifra;

        public string Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
        }

        private string _jmbgLekara;

        public string JmbgLekara
        {
            get { return _jmbgLekara; ; }
            set { _jmbgLekara = value; }
        }

        private DateTime _datum;

        public DateTime Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }


        private EStatusTermina _status;

        public EStatusTermina Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string jmbgPacijenta;

        public string JmbgPacijenta
        {
            get { return jmbgPacijenta; }
            set { jmbgPacijenta = value; }
        }

        private bool _aktivan;

        public bool Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
        }


        public string terminUFajl()
        {
            return Sifra + ";" + Datum + ";" + Status + ";" + jmbgPacijenta + ";" + JmbgLekara + ";" + Aktivan;
        }

    }
}