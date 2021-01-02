using SF_19_2019_POP2020.Models;
using SF19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF_19_2019_POP2020.Services
{
    public class DoctorService : IUserService
    {
        public void deleteUser(string username)
        {

        }

        public void readUsers()
        {
            Util.Instance.Lekari = new ObservableCollection<Lekar>();
            Util.Instance.Korisnici = new ObservableCollection<Korisnik>();

            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"select * from users where TypeOfUser like 'LEKAR'";

                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    Util.Instance.Korisnici.Add(new Korisnik
                    {
                        ID = reader.GetInt32(0),
                        KorisnickoIme = reader.GetString(1),
                        Ime = reader.GetString(2),
                        TipKorisnika = ETipKorisnika.LEKAR,
                        Email = reader.GetString(4),
                        Aktivan = reader.GetBoolean(5),
                        Pol = (EPol)Enum.Parse(typeof(EPol), reader.GetString(6)),
                        JMBG = reader.GetString(7),
                        Prezime = reader.GetString(8)


                    }); ;

                }

                reader.Close();
            }
        }

        public int saveUser(Object obj)
        {
            Lekar lekar = obj as Lekar;

            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"insert into dbo.Doctors (Id)
                                        output inserted.id VALUES (@Id)";

                command.Parameters.Add(new SqlParameter("Id", lekar.ID));

                return (int)command.ExecuteScalar();
            }
        }

        public void updateUser(object obj)
        {
            throw new NotImplementedException();
        }

        public void updateUser1(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
