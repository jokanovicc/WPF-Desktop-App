using SF_19_2019_POP2020.Models;
using SF_19_2019_POP2020.Services;
using SF19_2019_POP2020.Model;
using SF19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF19_2019_POP2020.Services
{
    public class PacijentService : IUserService
    {

        public void deleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public void readUsers(string filename)
        {
            Util.Instance.Pacijenti = new ObservableCollection<Pacijent>();
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] pacijentIzFajla = line.Split(';');
                    string terapije = pacijentIzFajla[1];
                    List<string> Terapija11 = terapije.Split('|').ToList();
                    List<string> termini11 = terapije.Split('|').ToList();
                    ObservableCollection<string> kolekcijaTerapija = new ObservableCollection<string>(Terapija11);
                    ObservableCollection<string> kolekcijaTermina = new ObservableCollection<string>(termini11);


                    Korisnik korisnik = Util.Instance.Korisnici.ToList().Find(kori => kori.KorisnickoIme.Equals(pacijentIzFajla[0]));
                    //Korisnik korisnik = NadjiKorisnika(lekarIzFajla[1]);
                    Pacijent pacijent = new Pacijent
                    {
                        Korisnicko = korisnik,
                        Terapije = kolekcijaTerapija,
                        Termini = kolekcijaTermina

                    };
                    Util.Instance.Pacijenti.Add(pacijent);
                }
            }
        }



        public void saveUsers(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Pacijent pacijent in Util.Instance.Pacijenti)
                {
                    file.WriteLine(pacijent.pacijentZaUpisuFajl());
                }
            }
        }
    }
}
