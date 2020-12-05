using SF_19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF19_2019_POP2020.Models
{
    [Serializable]
    public class Pacijent
    {
        private Korisnik _korisnick;
        public Korisnik Korisnicko
        {
            get { return _korisnick; }
            set { _korisnick = value; }
        }

        //OVO CE DRUGACIJE BITI IMPLEMENTIRANO POSLE KT1
/*        private List<String> _terapije;

        public List<String> Terapije
        {
            get { return _terapije; }
            set { _terapije = value; }
        }

        private ObservableCollection<String> _termini;

        public ObservableCollection<String> Termini
        {
            get { return _termini; }
            set { _termini = value; }
        }*/

        public override string ToString()
        {
            return Korisnicko.KorisnickoIme;

        }

        public string pacijentZaUpisuFajl()
        {
            return Korisnicko.KorisnickoIme;
        }


    }
}


/*5.Pacijent – Registrovan korisnik(JMBG), lista zakazanih Termina i lista Terapija*/