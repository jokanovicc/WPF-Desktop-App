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



            foreach (Korisnik korisnik in Aplikacija.Instance.Korisnici)
            {
                if (korisnik.TipKorisnika.Equals(ETipKorisnika.PACIJENT))
                {
                    Korisnici1.Add(korisnik);
                    view = CollectionViewSource.GetDefaultView(Korisnici1);
                }

            }

       
            dgPacijenti.ItemsSource = view;
            dgPacijenti.IsSynchronizedWithCurrentItem = true;


            dgPacijenti.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);



            view2 = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Pacijenti);

            dgPacijentiZasebno.ItemsSource = view2;
            dgPacijentiZasebno.IsSynchronizedWithCurrentItem = true;
            dgPacijentiZasebno.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }





    }
}
