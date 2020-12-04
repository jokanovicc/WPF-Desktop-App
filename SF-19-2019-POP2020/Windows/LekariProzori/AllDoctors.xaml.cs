using SF_19_2019_POP2020.Models;
using SF19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AllDoctors.xaml
    /// </summary>
    public partial class AllDoctors : Window
    {
        ICollectionView view;

        public AllDoctors()
        {
            InitializeComponent();

            UpdateView();

            view.Filter = CustomFilter;
        }

        private bool CustomFilter(object obj)
        {
            Korisnik korisnik = obj as Korisnik;
            // Korisnik korisnik1 = (Korisnik)obj;

            if (korisnik.TipKorisnika.Equals(ETipKorisnika.LEKAR) && korisnik.Aktivan)
                if (TxtPretraga.Text != "")
                {
                    return korisnik.Ime.Contains(TxtPretraga.Text);
                }
                else
                    return true;
            return false;
        }

        private void UpdateView()
        {
            //DGLekari.ItemsSource = null;
            view = CollectionViewSource.GetDefaultView(Util.Instance.Korisnici);
            DGLekari.ItemsSource = view; // Util.Instance.Korisnici;
            DGLekari.IsSynchronizedWithCurrentItem = true;
            DGLekari.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void DGLekari_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            /*if (e.PropertyName.Equals("Aktivan"))
                e.Column.Visibility = Visibility.Collapsed;*/
        }

        private void MIDodajLekara_Click(object sender, RoutedEventArgs e)
        {
            Korisnik noviKorisnik = new Korisnik();

            AddEditDoctor add = new AddEditDoctor(noviKorisnik);

            this.Hide();
            if (!(bool)add.ShowDialog())
            {

            }
            this.Show();
            view.Refresh();
        }

        private void MIIzmeniLekara_Click(object sender, RoutedEventArgs e)
        {
            //Korisnik selektovan = (Korisnik)DGLekari.SelectedItem;
            Korisnik selektovan = view.CurrentItem as Korisnik;
            Korisnik stariLekar = (Korisnik)selektovan.Clone();

            AddEditDoctor add = new AddEditDoctor(selektovan, EStatus.Izmeni);

            this.Hide();
            if (!(bool)add.ShowDialog())
            {
                int index = Util.Instance.Korisnici.ToList().FindIndex(k => k.KorisnickoIme.Equals(selektovan.KorisnickoIme));
                Util.Instance.Korisnici[index] = stariLekar;
            }
            this.Show();
            view.Refresh();
        }

        private void ObrisiLekaraMI_Click(object sender, RoutedEventArgs e)
        {
            Korisnik selektovan = view.CurrentItem as Korisnik;
            Util.Instance.DeleteUser(selektovan.KorisnickoIme);

            view.Refresh();
            /*int index = Util.Instance.Lekari.ToList().FindIndex(u => u.Korisnicko.KorisnickoIme.Equals(obrisiLekar.KorisnickoIme));
            Util.Instance.Lekari[index].Korisnicko.Aktivan = false;*/

            //UpdateView();
        }

        private void TxtPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
    }
}
