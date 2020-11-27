using SF_19_2019_POP2020.Models;
using SF_19_2019_POP2020.MyExceptions;
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
    public class TerminService
    {
        public void deleteTermin(string sifra)
        {
            Termin t = Util.Instance.Termini.ToList().Find(termin => termin.Sifra.Equals(sifra));

            if (t == null)
                throw new UserNotFoundException($"Ne postoji korisnik sa korisnickim imenom {sifra}");
            t.Aktivan = false;
            Util.Instance.SacuvajEntite("termini.txt");
        }

        public void readTermin(string filename)
        {
            Util.Instance.Termini = new ObservableCollection<Termin>();

            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] terminIzFajla = line.Split(';');

                    Enum.TryParse(terminIzFajla[2], out EStatusTermina status);

                    Boolean.TryParse(terminIzFajla[5], out Boolean aktivan);
                    DateTime oDate = Convert.ToDateTime(terminIzFajla[1]);
                    Termin termin = new Termin
                    {

                        Aktivan = aktivan,
                        Datum = oDate,
                        JmbgLekara = terminIzFajla[4],
                        JmbgPacijenta = terminIzFajla[3],
                        Sifra = terminIzFajla[0],
                        Status = status



                        //Aktivan = Convert.ToBoolean(korisnikIzFajla[8])

                    };
                    Util.Instance.Termini.Add(termin);
                }
            }
        }

        public void saveTermin(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Termin termin in Util.Instance.Termini)
                {
                    file.WriteLine(termin.terminUFajl());
                }
            }
        }
    }
}
