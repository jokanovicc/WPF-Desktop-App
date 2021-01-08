﻿using SF19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
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
    /// Interaction logic for DomZdravljaPrekoAdresePrikaz.xaml
    /// </summary>
    public partial class DomZdravljaPrekoAdresePrikaz : Window
    {
        ICollectionView view;
        public DomZdravljaPrekoAdresePrikaz(int sifraAdrese)
        {
            InitializeComponent();
            ObservableCollection<DomZdravlja> pac2 = readDomZdravlja(sifraAdrese);

            view = CollectionViewSource.GetDefaultView(pac2);
            dgDomZdravlja.ItemsSource = view;
            dgDomZdravlja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        public ObservableCollection<DomZdravlja> readDomZdravlja(int sifraAdrese)
        {
            ObservableCollection<DomZdravlja> pac = new ObservableCollection<DomZdravlja>();
            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"select d.id,d.naziv,d.adresa_id,d.active from domZdravlja d where adresa_id =" + sifraAdrese;

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    pac.Add(new DomZdravlja
                    {
                        Sifra = reader.GetInt32(0),
                        Naziv = reader.GetString(1),
                        AdresaID = reader.GetInt32(2),
                        Aktivan = reader.GetBoolean(3)
                    });


                }



                reader.Close();

                return pac;
            }
        }
    }
}
