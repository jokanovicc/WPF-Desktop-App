using SF_19_2019_POP2020.Models;
using SF19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_19_2019_POP2020
{
    class Aplikacija
    {
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Pacijent> Pacijenti { get; set; }

        public ObservableCollection<DomZdravlja> DomoviZdravlja { get; set; }

        public ObservableCollection<Termin> Termini { get; set; }

        public ObservableCollection<Adresa> Adrese { get; set; }

        public ObservableCollection<Terapija> Terapije { get; set; }

        private static Aplikacija instance = new Aplikacija();


        public static Aplikacija Instance
        {
            get
            {
                return instance;
            }
        }

        private Aplikacija()
        {
            Korisnici = new ObservableCollection<Korisnik>();
            DomoviZdravlja = new ObservableCollection<DomZdravlja>();
            Termini = new ObservableCollection<Termin>();
            Adrese = new ObservableCollection<Adresa>();
            Terapije = new ObservableCollection<Terapija>();
            PopuniPodatke();
        }




        private void PopuniPodatke()
        {
            Korisnik korisnik1 = new Korisnik
            {
                Aktivan = true,
                Email = "imejl@gmail.com",
                Ime = "Perica",
                JMBG = "2313212",
                KorisnickoIme = "perica123",
                Lozinka = "perica11",
                Pol = EPol.M,
                Prezime = "Peric",
                SifraAdrese = "23213",
                TipKorisnika = ETipKorisnika.PACIJENT



            };
            Korisnici.Add(korisnik1);

            Korisnik korisnik2 = new Korisnik
            {
                Aktivan = true,
                Email = "imejl@gmail.com",
                Ime = "jovica",
                JMBG = "2313212",
                KorisnickoIme = "perica123",
                Lozinka = "perica11",
                Pol = EPol.M,
                Prezime = "Peric",
                SifraAdrese = "23213",
                TipKorisnika = ETipKorisnika.PACIJENT



            };
            Korisnici.Add(korisnik2);

            Korisnik korisnik3 = new Korisnik
            {
                Aktivan = true,
                Email = "ado@gmail.com",
                Ime = "Ado",
                JMBG = "233213",
                KorisnickoIme = "adminat",
                Lozinka = "adminat11",
                Pol = EPol.M,
                Prezime = "Adminic",
                SifraAdrese = "34223423",
                TipKorisnika = ETipKorisnika.ADMINISTRATOR



            };

            Korisnici.Add(korisnik3);


            DomZdravlja domZdravlja = new DomZdravlja
            {
                Naziv = "DOM ZDRAVLJA SECANJ",
                Sifra = "255366",
                SifraAdrese = "324234",
                Aktivan = true
        };
            DomoviZdravlja.Add(domZdravlja);

            Termin termin = new Termin
            {
                Aktivan = true,
                Datum = new DateTime(2020, 5, 1, 8, 30, 52),
                JmbgLekara = "231312",
                JmbgPacijenta = korisnik1.JMBG,
                Sifra = "232432432",
                Status = EStatusTermina.SLOBODAN


            };
            Termini.Add(termin);


            Adresa adresa = new Adresa
            {
                Aktivan = true,
                Broj = "23342",
                Drzava = "Srbija",
                Grad = "Beograd",
                SifraAdrese = "232432",
                Ulica = "Nemanjina 23"

            };

            Adrese.Add(adresa);


            Terapija terapija = new Terapija
            {
                Aktivan = true,
                opis = "Sve okej",
                Sifra = "332423",
                SifraLekara = "342233",
                SifraPacijenta = korisnik1.JMBG
            };

            Terapije.Add(terapija);

        }

    }
}
