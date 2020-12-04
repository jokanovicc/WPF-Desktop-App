using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_19_2019_POP2020.Models
{
    public class Korisnik: ICloneable, INotifyPropertyChanged
    {
        private string korisnickoIme;
        private string ime;
        private string prezime;
        private string lozinka;
        private string email;
        private string jmbg;
        private Adresa adresa;
        private EPol pol;
        private ETipKorisnika tipKorisnika;
        private bool aktivan;


        public string KorisnickoIme
        {
            get
            {
                return korisnickoIme;
            }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorIme");
            }
        }


        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }
        public string Lozinka
        {
            get
            {
                return lozinka;
            }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }


        public string JMBG
        {
            get
            {
                return jmbg;
            }
            set
            {
                jmbg = value;
                OnPropertyChanged("Jmbg");
            }
        }



        public Adresa Adresa
        {
            get
            {
                return adresa;
            }
            set
            {
                adresa= value;
                OnPropertyChanged("Adresa");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public EPol Pol
        {
            get
            {
                return pol;
            }
            set
            {
                pol = value;
                OnPropertyChanged("Pol");
            }
        }

        public ETipKorisnika TipKorisnika
        {
            get
            {
                return tipKorisnika;
            }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("Tip Korisnika");
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


        public override string ToString()
        {
            return KorisnickoIme;
        }

        public string KorisnikZaUpisUFajl()
        {
            return KorisnickoIme + ";" + Ime + ";" + Prezime + ";" + JMBG + ";" +
                Email + ";" + Lozinka + ";" + Pol + ";" + TipKorisnika + ";" + Aktivan;
        }

        public object Clone()
        {
            Korisnik kopija = new Korisnik();

            kopija.KorisnickoIme = KorisnickoIme;
            kopija.Adresa = Adresa;
            kopija.Aktivan = Aktivan;
            kopija.Email = Email;
            kopija.Ime = Ime;
            kopija.Prezime = Prezime;
            kopija.Pol = Pol;
            kopija.Lozinka = Lozinka;
            kopija.JMBG = JMBG;
         

            return kopija;
        }

    }
}
