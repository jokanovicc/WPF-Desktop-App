using SF_19_2019_POP2020.MyExceptions;
using SF19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_19_2019_POP2020.Models
{
    class DomZdravljaService
    {
        public void deleteDomZdravlja(string sifra)
        {
            DomZdravlja dm = Util.Instance.DomoviZdravlja.ToList().Find(domZdravlja => domZdravlja.Sifra.Equals(sifra));

            if (dm == null)
                throw new UserNotFoundException($"Ne postoji korisnik sa korisnickim imenom {sifra}");
            dm.Aktivan = false;
            Util.Instance.SacuvajEntite("korisnici.txt");
        }

        public void readDomZdravlja(string filename)
        {
            Util.Instance.DomoviZdravlja = new ObservableCollection<DomZdravlja>();

            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] dzIzFajla = line.Split(';');

                    Boolean.TryParse(dzIzFajla[3], out Boolean aktivan);
                    DomZdravlja dz = new DomZdravlja
                    {
                        Naziv = dzIzFajla[1],
                        Sifra = dzIzFajla[0],
                        SifraAdrese = dzIzFajla[2],
                        Aktivan = aktivan
                        //Aktivan = Convert.ToBoolean(korisnikIzFajla[8])

                    };
                    Util.Instance.DomoviZdravlja.Add(dz);
                }
            }
        }

        public void saveDomZdravlja(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (DomZdravlja dm in Util.Instance.DomoviZdravlja)
                {
                    file.WriteLine(dm.domZdravljaUFajl());
                }
            }
        }
    }
}
