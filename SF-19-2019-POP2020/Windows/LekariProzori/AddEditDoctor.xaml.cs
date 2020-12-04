using SF_19_2019_POP2020.Models;
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

namespace SF19_2019_POP2020.Windows
{
    /// <summary>
    /// Interaction logic for AddEditDoctor.xaml
    /// </summary>
    public partial class AddEditDoctor : Window
    {
        private EStatus odabranStatus;
        private Korisnik odabranLekar;
        public AddEditDoctor(Korisnik lekar, EStatus status = EStatus.Dodaj)
        {
            InitializeComponent();

            this.DataContext = lekar;

            odabranLekar = lekar;
            odabranStatus = status;

            CmbTipKorisnika.ItemsSource = Enum.GetValues(typeof(ETipKorisnika)).Cast<ETipKorisnika>();

            if (status.Equals(EStatus.Izmeni) && lekar != null)
            {
                this.Title = "Izmeni lekara";
                /*TxtEmail.Text = lekar.Email;
                TxtKorisnickoIme.Text = lekar.KorisnickoIme;
                TxtName.Text = lekar.Ime;
                TxtPrezime.Text = lekar.Prezime;*/
                TxtKorisnickoIme.IsEnabled = false;
            }
            else
            {
                this.Title = "Dodaj lekara";
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = false;
            this.Close();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            /*ComboBoxItem item = (ComboBoxItem)CmbTipKorisnika.SelectedItem;
            string value = item.Content.ToString();
            Enum.TryParse(value, out ETipKorisnika tip);*/

            /*Korisnik k = new Korisnik
            {
                Ime = TxtName.Text,
                Prezime = TxtPrezime.Text,
                KorisnickoIme = TxtKorisnickoIme.Text,
                Email = TxtEmail.Text,
                TipKorisnika = tip,
                Aktivan = true, 
                JMBG = "1234", 
                Lozinka = "1234"
            };*/



            if (odabranStatus.Equals(EStatus.Dodaj))
            {
                odabranLekar.Aktivan = true;
                Lekar lekar = new Lekar
                {
                    DomZdravlja = "Dom zdravlja 1",
                    Korisnicko = odabranLekar
                };

                Util.Instance.Korisnici.Add(odabranLekar);
                Util.Instance.Lekari.Add(lekar);
            }
            else
            {
                /*int izmenaLekar = Util.Instance.Lekari.ToList().FindIndex(u => u.Korisnicko.KorisnickoIme.Equals(TxtKorisnickoIme.Text));
                int izmenaKorisnik = Util.Instance.Korisnici.ToList().FindIndex(u => u.KorisnickoIme.Equals(TxtKorisnickoIme.Text));

                Util.Instance.Korisnici[izmenaKorisnik] = k;
                Util.Instance.Lekari[izmenaLekar] = lekar;*/
            }

            Util.Instance.SacuvajEntite("korisnici.txt");
            Util.Instance.SacuvajEntite("lekari.txt");

            this.DialogResult = true;
            this.Close();
        }
    }
}
