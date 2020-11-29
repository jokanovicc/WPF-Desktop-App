using SF_19_2019_POP2020.Models;
using SF_19_2019_POP2020.Services;
using SF19_2019_POP2020.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SF19_2019_POP2020.Models
{
    public sealed class Util
    {
        private static readonly Util instance = new Util();
        IUserService _userService;
        IUserService _doctorService;
        IUserService _pacijentService;
        DomZdravljaService _domZdravljaService;
        TerminService _terminService;
        TerapijaService _terapijaService;
        AdresaService _adreseService;
        ETipKorisnika tipKorisnika;

        private Util()
        {
            _userService = new UserService();
            _doctorService = new DoctorService();
            _pacijentService = new PacijentService();
            _domZdravljaService = new DomZdravljaService();
            _terminService = new TerminService();
            _terapijaService = new TerapijaService();
            _adreseService = new AdresaService();
        }
        static Util()
        {

        }

        public static Util Instance
        {
            get
            {
                return instance;
            }
        }

        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<Lekar> Lekari { get; set; }
        public ObservableCollection<Pacijent> Pacijenti { get; set; }
        public ObservableCollection<Termin> Termini { get; set; }
        public ObservableCollection<Terapija> Terapije { get; set; }

        public ObservableCollection<DomZdravlja> DomoviZdravlja { get; set; }

        public ObservableCollection<Adresa> Adrese { get; set; }
        public ObservableCollection<Korisnik> Pacijenti1 { get; private set; }

        public void Initialize()
        {
            Korisnici = new ObservableCollection<Korisnik>();
            Lekari = new ObservableCollection<Lekar>();
            Pacijenti = new ObservableCollection<Pacijent>();
            Terapije = new ObservableCollection<Terapija>();
            Termini = new ObservableCollection<Termin>();
            DomoviZdravlja = new ObservableCollection<DomZdravlja>();
            Adrese = new ObservableCollection<Adresa>();

            Adresa adresa = new Adresa
            {
                Grad = "Grad 1",
                Broj = "Broj 1",
                Drzava = "Drzava 1",
                Ulica = "Ulica 1",
                SifraAdrese = "1"
            };

            Korisnik korisnik1 = new Korisnik();
            korisnik1.KorisnickoIme = "pera";
            korisnik1.Ime = "petar";
            korisnik1.Prezime = "peric";
            korisnik1.JMBG = "123456";
            korisnik1.Lozinka = "pera";
            korisnik1.Email = "pera@gmail.com";
            korisnik1.Pol = EPol.M;
            korisnik1.TipKorisnika = ETipKorisnika.ADMINISTRATOR;
            korisnik1.Aktivan = true;
            //korisnik1.Adresa = adresa;

            Korisnik korisnik2 = new Korisnik
            {
                Email = "zika@gmail.com",
                Ime = "zika",
                Prezime = "zikic",
                KorisnickoIme = "ziza",
                JMBG = "654321",
                Lozinka = "zika",
                Pol = EPol.Z,
                TipKorisnika = ETipKorisnika.PACIJENT,
                //Adresa = adresa
            };


            Korisnici.Add(korisnik1);
            Korisnici.Add(korisnik2);

   

                Pacijenti1 = new ObservableCollection<Korisnik>();
                foreach (Korisnik korisnik in Korisnici)
                {
                    if (korisnik.TipKorisnika.Equals(ETipKorisnika.PACIJENT))
                    {
                        Pacijenti1.Add(korisnik);

                    }
                }
            


        }



        public void SacuvajEntite(string filename)
        {
            if (filename.Contains("korisnici"))
            {
                _userService.saveUsers(filename);
            }
            else if (filename.Contains("lekari"))
            {
                _doctorService.saveUsers(filename);
            }

            else if (filename.Contains("pacijenti"))
            {
                _doctorService.saveUsers(filename);
            }
            else if (filename.Contains("domoviZdravlja"))
            {
                _domZdravljaService.saveDomZdravlja(filename);
            }
            else if (filename.Contains("termini"))
            {
                _terminService.saveTermin(filename);
            }
            else if (filename.Contains("terapije"))
            {
                _terapijaService.saveTerapija(filename);
            }
            else if (filename.Contains("adrese"))
            {
                _adreseService.saveAdresa(filename);
            }
        }

        public void CitanjeEntiteta(string filename)
        {
            if (filename.Contains("korisnici"))
            {
                _userService.readUsers(filename);
            }
            else if (filename.Contains("lekari"))
            {
                _doctorService.readUsers(filename);
            }
            else if (filename.Contains("pacijenti"))
            {
                _pacijentService.readUsers(filename);
            }
            else if (filename.Contains("pacijenti"))
            {
                _doctorService.readUsers(filename);
            }
            else if (filename.Contains("domoviZdravlja"))
            {
                _domZdravljaService.readDomZdravlja(filename);
            }
            else if (filename.Contains("termini"))
            {
                _terminService.readTermin(filename);
            }
            else if (filename.Contains("terapije"))
            {
                _terapijaService.readTerapija(filename);
            }
            else if (filename.Contains("adrese"))
            {
                _adreseService.readAdresa(filename);
            }
        }

        public void DeleteUser(string username)
        {
            _userService.deleteUser(username);
        }

        public void DeleteDomZdravlja(string sifra)
        {
            _domZdravljaService.deleteDomZdravlja(sifra);
        }
    }
}
