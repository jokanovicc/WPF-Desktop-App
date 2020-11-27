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

        private ObservableCollection<String> _terapije;

        public ObservableCollection<String> Terapije
        {
            get { return _terapije; }
            set { _terapije = value; }
        }

        private ObservableCollection<String> _termini;

        public ObservableCollection<String> Termini
        {
            get { return _termini; }
            set { _termini = value; }
        }



        public string pacijentZaUpisuFajl()
        {
            return Korisnicko + ";" + String.Join("|", Terapije) + ";" + String.Join("|", Termini);
        }


    }
}


/*5.Pacijent – Registrovan korisnik(JMBG), lista zakazanih Termina i lista Terapija*/