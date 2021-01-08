﻿using SF_19_2019_POP2020.Windows.AdresaProzori;
using SF_19_2019_POP2020.Windows.DomZdravljaProzori;
using SF_19_2019_POP2020.Windows.LekariProzori;
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

namespace SF_19_2019_POP2020.Windows.NEPRIJAVLJENIWindow
{
    /// <summary>
    /// Interaction logic for OdaberiDomZdravljaMesto.xaml
    /// </summary>
    public partial class OdaberiDomZdravljaMesto : Window
    {
        int id;
        int id2;

        public OdaberiDomZdravljaMesto()
        {
            InitializeComponent();
        }

        private void btnPicAdresa_Click(object sender, RoutedEventArgs e)
        {
            AdresaPick gw = new AdresaPick(AdresaPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                //  domZdravlja.Adresa = gw.SelektovanaAdresa;
               id= gw.SelektovanaAdresa.SifraAdrese;
            }
        }

        private void btnPicLekar_Click(object sender, RoutedEventArgs e)
        {
            LekariPick gw = new LekariPick(LekariPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                id2 = gw.SelektovaniLekar.ID;
            }
        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            IzabraniDomZdravlja izd = new IzabraniDomZdravlja(id,id2);
            izd.Show();
        }
    }
}
