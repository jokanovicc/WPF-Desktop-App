
using SF_19_2019_POP2020.Windows.TerminiWindow;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SF_19_2019_POP2020.Windows
{
    
    /// <summary>
    /// Interaction logic for TerminiWindow.xaml
    /// </summary>
    public partial class TerminiWindow1 :  Window
        
    {
        ICollectionView view;
        public TerminiWindow1()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Termini);
            dgTermini.ItemsSource = view;
            dgTermini.IsSynchronizedWithCurrentItem = true;


            dgTermini.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Termin selektovaniTermin = view.CurrentItem as Termin;
                Aplikacija.Instance.Termini.Remove(selektovaniTermin);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Termin noviTermin = new Termin();
            TerminiAddEdit few = new TerminiAddEdit(noviTermin);
            few.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Termin selektovaniTermin = view.CurrentItem as Termin; 

            if (selektovaniTermin != null)
            {

                Termin old = (Termin)selektovaniTermin.Clone();
                TerminiAddEdit few = new TerminiAddEdit(selektovaniTermin,
                    TerminiAddEdit.Stanje.IZMENA);
                if (few.ShowDialog() != true) 
                {

                    int index = Aplikacija.Instance.Termini.IndexOf(
                        selektovaniTermin);
                    Aplikacija.Instance.Termini[index] = old;
                }
            }
        }


    }
}
