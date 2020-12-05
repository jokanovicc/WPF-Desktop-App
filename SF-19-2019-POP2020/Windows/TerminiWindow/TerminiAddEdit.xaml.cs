﻿using SF_19_2019_POP2020.Windows.LekariProzori;
using SF_19_2019_POP2020.Windows.PacijentiProzori;
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

namespace SF_19_2019_POP2020.Windows.TerminiWindow
{
    /// <summary>
    /// Interaction logic for TerminiAddEdit.xaml
    /// </summary>
    public partial class TerminiAddEdit : Window
    {
        Termin termin;
        public enum Stanje { DODAVANJE, IZMENA };
        Stanje stanje;

        public TerminiAddEdit(Termin termin, Stanje stanje = Stanje.DODAVANJE)
        {
            InitializeComponent();

            this.termin = termin;
            this.stanje = stanje;

            

            //BUG SA DATUMOM - ne radi odabir datuma tjst ne prolazi select.

            termin.Status = EStatusTermina.ZAKAZAN;
            termin.Aktivan = true;
            termin.Datum = DateTime.Now;
            tbSifra.DataContext = termin;
            tbLekar1.DataContext = termin;
            tbPacijent.DataContext = termin;
            dpDatum.DataContext = termin;
            






        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (stanje == Stanje.DODAVANJE)
            {
                Aplikacija.Instance.Termini.Add(termin);
            }
            this.Close();
        }

        private void btnPickLekar_Click(object sender, RoutedEventArgs e)
        {
            LekariPick gw = new LekariPick(LekariPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                termin.Lekar = gw.SelektovaniLekar;
            }
        }


        private void btnPickPacijent_Click(object sender, RoutedEventArgs e)
        {
            PacijentiPick gw = new PacijentiPick(PacijentiPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                termin.Pacijent = gw.SelektovaniPacijent;
            }
        }
    }
}