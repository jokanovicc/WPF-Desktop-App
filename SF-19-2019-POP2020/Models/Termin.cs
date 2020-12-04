using SF_19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF19_2019_POP2020.Models
{
    public class Termin: ICloneable, INotifyPropertyChanged
    {
        private string sifra;
        private Lekar lekar;
        private DateTime datum;
        private EStatusTermina status;
        private Pacijent pacijent;
        private Boolean aktivan;



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

        public DateTime Datum
        {
            get
            {
                return datum;
            }
            set
            {
                datum = value;
                OnPropertyChanged("Datum");
            }
        }

        public EStatusTermina Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                OnPropertyChanged("Status");
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


        public object Clone()
        {
            Termin kopija = new Termin();
            kopija.sifra = Sifra;
            kopija.lekar = Lekar;
            kopija.datum = DateTime.Now;
            kopija.status = Status;
            kopija.pacijent = Pacijent;
            kopija.aktivan = Aktivan;
            return kopija;

        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}