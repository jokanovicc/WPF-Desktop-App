using SF_19_2019_POP2020.Models;
using SF_19_2019_POP2020.Windows.PacijentiProzori;
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

namespace SF_19_2019_POP2020.Windows
{
    /// <summary>
    /// Interaction logic for PacijentiWindow.xaml
    /// </summary>
    public partial class PacijentiWindow : Window
    {
        ICollectionView view;
        ICollectionView view2;

        public ObservableCollection<Korisnik> Korisnici1 { get; set; }

        public PacijentiWindow()
        {
            InitializeComponent();
            Korisnici1 = new ObservableCollection<Korisnik>();



            

                
            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.KorisniciPacijenti);


       
            dgPacijenti.ItemsSource = view;
            dgPacijenti.IsSynchronizedWithCurrentItem = true;


            dgPacijenti.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);



            view2 = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Pacijenti);

/*            dgPacijentiZasebno.ItemsSource = view2;
            dgPacijentiZasebno.IsSynchronizedWithCurrentItem = true;
            dgPacijentiZasebno.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);*/
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Korisnik selektovaniKorisnik = view.CurrentItem as Korisnik;
                Aplikacija.Instance.KorisniciPacijenti.Remove(selektovaniKorisnik);
            }
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Korisnik novKorisnik = new Korisnik();
            PacijentAddEdit few = new PacijentAddEdit(novKorisnik);
            few.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Korisnik selektovaniKorisnik = view.CurrentItem as Korisnik; //preuzimanje selektovane adrese

            if (selektovaniKorisnik != null)
            {
                Korisnik old = (Korisnik)selektovaniKorisnik.Clone();
                PacijentAddEdit few = new PacijentAddEdit(selektovaniKorisnik,
                    PacijentAddEdit.Stanje.IZMENA);
                if (few.ShowDialog() != true) //ako je kliknuo cancel, ponistavaju se izmene nad objektom
                {

   
                    int index = Aplikacija.Instance.KorisniciPacijenti.IndexOf(
                        selektovaniKorisnik);
                    //vratimo vrednosti njegovih atributa na stare vrednosti, jer je izmena ponistena
                    Aplikacija.Instance.KorisniciPacijenti[index] = old;
                }
            }
        }



    }
}
