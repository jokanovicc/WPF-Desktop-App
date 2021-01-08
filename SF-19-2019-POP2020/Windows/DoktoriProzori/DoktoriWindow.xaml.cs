using SF_19_2019_POP2020.Models;
using SF19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SF_19_2019_POP2020.Windows.DoktoriProzori
{
    /// <summary>
    /// Interaction logic for DoktoriWindow.xaml
    /// </summary>
    public partial class DoktoriWindow : Window
    {
        ICollectionView view;



        public DoktoriWindow()
        {
            InitializeComponent();






            view = CollectionViewSource.GetDefaultView(Util.Instance.Lekari);
            view.Filter = CustomFilter;



            dgLekari.ItemsSource = view;
            dgLekari.IsSynchronizedWithCurrentItem = true;


            dgLekari.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);



            /*            dgPacijentiZasebno.ItemsSource = view2;
                        dgPacijentiZasebno.IsSynchronizedWithCurrentItem = true;
                        dgPacijentiZasebno.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);*/
        }

        private bool CustomFilter(object obj)
        {
            Lekar korisnik = obj as Lekar;
            // Korisnik korisnik1 = (Korisnik)obj;

            if (korisnik.Aktivan)
            {
                if (TxtPretraga.Text != "")
                {
                    if (korisnik.Ime.Contains(TxtPretraga.Text))
                    {
                        return korisnik.Ime.Contains(TxtPretraga.Text);
                    }
                    if (korisnik.Prezime.Contains(TxtPretraga.Text))
                    {
                        return korisnik.Prezime.Contains(TxtPretraga.Text);
                    }
                    if (korisnik.Email.Contains(TxtPretraga.Text))
                    {
                        return korisnik.Email.Contains(TxtPretraga.Text);
                    }
                    if (korisnik.AdresaID.ToString().Contains(TxtPretraga.Text))
                    {
                        return korisnik.AdresaID.ToString().Contains(TxtPretraga.Text);
                    }
                }
                else
                    return true;

            }
            return false;
        }

        private void TxtPretraga_KeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
                        if (MessageBox.Show("Da li ste sigurni?", "Potvrda",
                            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            Lekar selektovaniKorisnik = view.CurrentItem as Lekar;
                            Util.Instance.DeleteDoktor(selektovaniKorisnik.JMBG);
                            view.Refresh();
                        }
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool PrikazFiltera(object obj)
        {
            return ((Lekar)obj).Aktivan;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Lekar novLekar = new Lekar();
            DoktorAddEdit few = new DoktorAddEdit(novLekar);
       //     Util.Instance.CitanjeEntiteta();
            few.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Lekar selektovaniKorisnik = view.CurrentItem as Lekar; //preuzimanje selektovane adrese

            if (selektovaniKorisnik != null)
            {
                Lekar old = (Lekar)selektovaniKorisnik.Clone();
                DoktorAddEdit few = new DoktorAddEdit(selektovaniKorisnik,
                    DoktorAddEdit.Stanje.IZMENA);
                if (few.ShowDialog() != true) //ako je kliknuo cancel, ponistavaju se izmene nad objektom
                {


                    int index = Util.Instance.Lekari.IndexOf(
                        selektovaniKorisnik);
                    //vratimo vrednosti njegovih atributa na stare vrednosti, jer je izmena ponistena
                    Util.Instance.Lekari[index] = old;
                }
            }
        }

    }
}

/*    }

}
*/