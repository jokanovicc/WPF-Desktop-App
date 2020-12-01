using SF_19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF19_2019_POP2020.Models
{
    public class DomZdravlja : ICloneable, INotifyPropertyChanged
    {

        private string sifra;
        private string naziv;
        private Adresa adresa;
        private Boolean aktivan;



        public string Sifra
        {
            get
            {
                return sifra; 
            }
            set {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }


        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
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
                adresa = value;
                OnPropertyChanged("Adresa");
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
            DomZdravlja kopija = new DomZdravlja();
            kopija.Sifra = Sifra;
            kopija.Naziv = Naziv;
            kopija.Adresa = Adresa;
            kopija.Aktivan = Aktivan;
            return kopija;

        }




    }
}
