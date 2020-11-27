using SF_19_2019_POP2020.Models;
using SF19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_19_2019_POP2020.Services
{
    public class AdresaService
    {
        public void deleteDomZdravlja(string sifra)
        {
            Adresa a = Util.Instance.Adrese.ToList().Find(adresa => adresa.SifraAdrese.Equals(sifra));

/*            if (a == null)
                throw new UserNotFoundException($"Ne postoji korisnik sa korisnickim imenom {sifra}");*/
            a.Aktivan = false;
            Util.Instance.SacuvajEntite("korisnici.txt");
        }

        public void readAdresa(string filename)
        {
            Util.Instance.Adrese = new ObservableCollection<Adresa>();

            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] aIzFajla = line.Split(';');

                    Boolean.TryParse(aIzFajla[5], out Boolean aktivan);
                    Adresa ad = new Adresa
                    {
                        SifraAdrese = aIzFajla[0],
                        Ulica = aIzFajla[1],
                        Broj = aIzFajla[2],
                        Drzava = aIzFajla[3],
                        Grad = aIzFajla[4]



                    };
                    Util.Instance.Adrese.Add(ad);
                }
            }
        }



        public void saveAdresa(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Adresa ad in Util.Instance.Adrese)
                {
                    file.WriteLine(ad.AdresaUFajl());
                }
            }
        }
    }
}
