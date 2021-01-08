using SF_19_2019_POP2020.Models;
using SF_19_2019_POP2020.Services;
using SF_19_2019_POP2020.Windows.AdresaProzori;
using SF_19_2019_POP2020.Windows.DomZdravljaProzori;
using SF19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SF_19_2019_POP2020.Windows.DoktoriProzori
{
    /// <summary>
    /// Interaction logic for DoktorAddEdit.xaml
    /// </summary>
    public partial class DoktorAddEdit : Window
    {
        Lekar korisnik;
        public enum Stanje { DODAVANJE, IZMENA };
        Stanje stanje;

        public DoktorAddEdit(Lekar korisnik, Stanje stanje = Stanje.DODAVANJE)
        {
            InitializeComponent();

            this.korisnik = korisnik;
            this.stanje = stanje;

            tbPol.ItemsSource = Enum.GetValues(typeof(EPol)).Cast<EPol>();
            Random random = new Random();
      //      korisnik.ID = random.Next(1, 1000);
            korisnik.Aktivan = true;
            tbLozinka.DataContext = korisnik;
            tbIme.DataContext = korisnik;
            tbEmail.DataContext = korisnik;
            tbIme.DataContext = korisnik;
            tbJmbg.DataContext = korisnik;
            tbPol.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbPol.DataContext = korisnik;
            korisnik.AdresaID = 390;
            korisnik.DomZdravljaID = 847;
            tbAdresa.DataContext = korisnik;
            tbDomZdravlja.DataContext = korisnik;

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (stanje == Stanje.DODAVANJE)
            {
                if (validacije()) { 
                Util.Instance.Lekari.Add(korisnik);
                Util.Instance.SacuvajEntitet(korisnik);
            }
        }
            if (stanje == Stanje.IZMENA)
            {
                //Util.Instance.Adrese.Add(adresa);
                Util.Instance.updateDoktor(korisnik);


            }
            this.Close();
        }

        private void btnPicAdresa_Click(object sender, RoutedEventArgs e)
        {
            AdresaPick gw = new AdresaPick(AdresaPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                korisnik.AdresaID = gw.SelektovanaAdresa.SifraAdrese;
            }
        }

        private void btnPicDomZdravlja_Click(object sender, RoutedEventArgs e)
        {
            DomZdravljaPick gw = new DomZdravljaPick(DomZdravljaPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                korisnik.DomZdravljaID = gw.SelektovaniDomZdravlja.Sifra;
            }
        }

        private bool validacije()
        {
            bool ok = true;
            String poruka = "Korisnik se nije sacuvao\nMolimo popravite sledece greske u unosu:\n";
            if (tbIme.Text.Equals(""))
            {
                poruka += "\n- Polje Ime ne sme biti Prazno!\n";
                ok = false;
            }
            if (tbPrezime.Text.Equals(""))
            {
                poruka += "- Polje Prezime ne sme biti Prazno!\n";
                ok = false;
            }
            if (!tbEmail.Text.Contains("@"))
            {
                poruka += "- Polje email nije u odgovarajucem formatu!\n";
                ok = false;
            }
            if (tbJmbg.Text.Length != 13)
            {
                poruka += "- Jmbg mora imati 13 cifara!\n";
                ok = false;
            }
            if (tbLozinka.Text.Equals(""))
            {
                poruka += "- Polje lozinke ne sme biti prazno!!\n";
                ok = false;
            }
            if (ok == false)
            {
                MessageBox.Show(poruka, "Probajte ponovo");
            }
            return ok;




        }
    }
}
