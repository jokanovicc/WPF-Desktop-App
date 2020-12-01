using SF_19_2019_POP2020.Models;
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

namespace SF_19_2019_POP2020.Windows.AdresaEditUpdate
{
    /// <summary>
    /// Interaction logic for FakultetEditWindow.xaml
    /// </summary>
    public partial class AdresaEditAddDelete : Window
    {
        Adresa adresa;
        public enum Stanje { DODAVANJE, IZMENA };
        Stanje stanje;

        public AdresaEditAddDelete(Adresa adresa, Stanje stanje = Stanje.DODAVANJE) //default vrednost parametra
        {
            InitializeComponent();

            this.adresa = adresa;
            this.stanje = stanje;

            adresa.Aktivan = true;
            tbBroj.DataContext = adresa;
            tbDrzava.DataContext = adresa;
            tbSifraAdrese.DataContext = adresa;
            tbGrad.DataContext = adresa;
            tbUlica1.DataContext = adresa;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (stanje == Stanje.DODAVANJE)
            {
                Aplikacija.Instance.Adrese.Add(adresa);
            }
            this.Close();
        }

 

    }
}
