using SF_19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF19_2019_POP2020.Models
{
    public class Terapija : ICloneable, INotifyPropertyChanged
    {

        private string sifra;
        private string opis;
        private Lekar lekar;
        private Pacijent pacijent;
        private bool aktivan;



        public string Sifra
        {
            get
            {
                return sifra;

            }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }

        }

        public string Opis
        {
            get
            {
                return opis;

            }
            set
            {
                opis = value;
                OnPropertyChanged("Opis");
            }

        }

        public Lekar Lekar
        {
            get
            {
                return lekar;

            }
            set
            {
                lekar = value;
                OnPropertyChanged("Lekar");
            }

        }

        public Boolean Aktivan
        {
            get
            {
                return aktivan;
            }
            set
            {
                aktivan = value;
                OnPropertyChanged("Aktivan");
            }
        }


        public Pacijent Pacijent
        {
            get
            {
                return pacijent;

            }
            set
            {
                pacijent = value;
                OnPropertyChanged("Pacijent");
            }

        }


        public string terapijaUFajl()
        {
            return ";";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public object Clone()
        {
            Terapija kopija = new Terapija();
            kopija.Opis = Opis;
            kopija.Lekar = Lekar;
            kopija.Pacijent = Pacijent;
            kopija.Sifra = Sifra;
            kopija.Aktivan = Aktivan;
            return kopija;

        }
    }
}
