using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_19_2019_POP2020.Models
{
    [Serializable]
    public class Lekar
    {
        private string _domZdravlja;

        public string DomZdravlja
        {
            get { return _domZdravlja; }
            set { _domZdravlja = value; }
        }

        private Korisnik _korisnick;

        public Korisnik Korisnicko
        {
            get { return _korisnick; }
            set { _korisnick = value; }
        }

        public override string ToString()
        {
            return Korisnicko.KorisnickoIme;

        }

        private ObservableCollection<String> _zakazaniTermini;

        public ObservableCollection<String> ZakazaniTermini
        {
            get { return _zakazaniTermini; }
            set { _zakazaniTermini = value; }
        }


        private ObservableCollection<String> _slobodniTermini;

        public ObservableCollection<String> SlobodniTermini
        {
            get { return _zakazaniTermini; }
            set { _zakazaniTermini = value; }
        }

        public string LekarUpisUFajl()
        {
            return DomZdravlja + ";" + Korisnicko.KorisnickoIme;
        }

    }
}
