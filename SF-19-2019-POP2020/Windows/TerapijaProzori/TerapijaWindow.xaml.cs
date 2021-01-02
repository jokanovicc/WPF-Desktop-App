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
    /// Interaction logic for TerapijaWindow.xaml
    /// </summary>
    public partial class TerapijaWindow : Window
    {
        ICollectionView view;
        public TerapijaWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Util.Instance.Terapije);
            view.Filter = PrikazFiltera;
            dgTerapije.ItemsSource = view;
            dgTerapije.IsSynchronizedWithCurrentItem = true;


            dgTerapije.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Terapija selektovanaTerapija = view.CurrentItem as Terapija;
                Util.Instance.DeleteTerapija(selektovanaTerapija.Sifra);
                view.Refresh();
            }
        }

        private bool PrikazFiltera(object obj)
        {
            return ((Terapija)obj).Aktivan;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Terapija novaTerapija = new Terapija();
            TerapijeAddEdit few = new TerapijeAddEdit(novaTerapija);
            few.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Terapija selektovanaTerapija= view.CurrentItem as Terapija; 

            if (selektovanaTerapija != null)
            {
                Terapija old = (Terapija)selektovanaTerapija.Clone();
                TerapijeAddEdit few = new TerapijeAddEdit(selektovanaTerapija,
                    TerapijeAddEdit.Stanje.IZMENA);

                if (few.ShowDialog() != true) 
                {

                    int index = Aplikacija.Instance.Terapije.IndexOf(
                        selektovanaTerapija);
               //     Aplikacija.Instance.Terapije[index] = old;
                }
            }
        }


    }


}
