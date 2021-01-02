using SF_19_2019_POP2020.Windows.DomZdravljaProzori;
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

namespace SF_19_2019_POP2020.Windows
{
    /// <summary>
    /// Interaction logic for DomoviZdravljaWindow.xaml
    /// </summary>
    public partial class DomoviZdravljaWindow : Window
    {
        ICollectionView view;
        public DomoviZdravljaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Util.Instance.DomoviZdravlja);
            view.Filter = PrikazFiltera;
            dgDomZdravlja.ItemsSource = view;
            dgDomZdravlja.IsSynchronizedWithCurrentItem = true;



            dgDomZdravlja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                DomZdravlja selektovaniDomZdravlja = view.CurrentItem as DomZdravlja;
                Util.Instance.DeleteDomZdravlja(selektovaniDomZdravlja.Sifra);
                view.Refresh();
            }
        }

        private bool PrikazFiltera(object obj)
        {
            return ((DomZdravlja)obj).Aktivan;
        }
        
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DomZdravlja noviDomZdravlja = new DomZdravlja();
            DomoviZdravljaAddEdit few = new DomoviZdravljaAddEdit(noviDomZdravlja);
  
            few.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DomZdravlja selektovaniDomZdravlja = view.CurrentItem as DomZdravlja; //preuzimanje selektovanog 

            if (selektovaniDomZdravlja != null)//ako je elektovan
            {
                DomZdravlja old = (DomZdravlja)selektovaniDomZdravlja.Clone();
                DomoviZdravljaAddEdit few = new DomoviZdravljaAddEdit(selektovaniDomZdravlja,
                    DomoviZdravljaAddEdit.Stanje.IZMENA);
                view.Refresh();
                if (few.ShowDialog() != true) //ako je kliknuo cancel, ponistavaju se izmene nad objektom
                {

                    //pronadjemo indeks selektovanog fakulteta
                    int index = Aplikacija.Instance.DomoviZdravlja.IndexOf(
                        selektovaniDomZdravlja);
                    //vratimo vrednosti njegovih atributa na stare vrednosti, jer je izmena ponistena
                   // Aplikacija.Instance.DomoviZdravlja[index] = old;
                }
            }
        }

    
}
}
