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

namespace SF_19_2019_POP2020.Windows.TerapijaProzori
{
    /// <summary>
    /// Interaction logic for TerapijeWindow.xaml
    /// </summary>
    public partial class TerapijeWindow : Window
    {
        ICollectionView view;



        public TerapijeWindow()
        {
            InitializeComponent();






            view = CollectionViewSource.GetDefaultView(Util.Instance.Terapije);
            view.Filter = PrikazFiltera;


            dgLekari.ItemsSource = view;
            dgLekari.IsSynchronizedWithCurrentItem = true;


            dgLekari.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);



            /*            dgPacijentiZasebno.ItemsSource = view2;
                        dgPacijentiZasebno.IsSynchronizedWithCurrentItem = true;
                        dgPacijentiZasebno.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);*/
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Terapija selektovaniTerapija= view.CurrentItem as Terapija;
                Util.Instance.DeleteTerapija(selektovaniTerapija.Sifra);
                view.Refresh();
            }
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool PrikazFiltera(object obj)
        {
            return ((Terapija)obj).Aktivan;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Terapija novaTerapija = new Terapija();
            TerapijaAddEdit few = new TerapijaAddEdit(novaTerapija);
            //     Util.Instance.CitanjeEntiteta();
            few.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Terapija selektovaniKorisnik = view.CurrentItem as Terapija; //preuzimanje selektovane adrese

            if (selektovaniKorisnik != null)
            {
                Terapija old = (Terapija)selektovaniKorisnik.Clone();
                TerapijaAddEdit few = new TerapijaAddEdit(selektovaniKorisnik,
                    TerapijaAddEdit.Stanje.IZMENA);
                if (few.ShowDialog() != true) //ako je kliknuo cancel, ponistavaju se izmene nad objektom
                {


                    int index = Util.Instance.Terapije.IndexOf(
                        selektovaniKorisnik);
                    //vratimo vrednosti njegovih atributa na stare vrednosti, jer je izmena ponistena
                    Util.Instance.Terapije[index] = old;
                }
            }
            view.Refresh();
        }

    }
}
