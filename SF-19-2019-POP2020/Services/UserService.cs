using SF_19_2019_POP2020.Models;
using SF_19_2019_POP2020.MyExceptions;
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
    public class UserService : IUserService
    {
        public void deleteUser(string username)
        {
            Korisnik k = Util.Instance.Korisnici.ToList().Find(korisnik => korisnik.KorisnickoIme.Equals(username));

            if (k == null)
                throw new UserNotFoundException($"Ne postoji korisnik sa korisnickim imenom {username}");
            k.Aktivan = false;

            updateUser(k);
        }

        public void readUsers()
        {
            Util.Instance.Korisnici = new ObservableCollection<Korisnik>();

            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"select * from users";

            }

        }

        public int saveUser(Object obj)
        {
            Korisnik korisnik = obj as Korisnik;

            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"insert into dbo.Users (Username, Firstname, TypeOfUser,Lastname, Email , Active, Pol,Jmbg)
                                        output inserted.id VALUES (@Username, @Firstname, @TypeOfUser,@Lastname, @Email, @Active,@Pol,@Jmbg)";

                command.Parameters.Add(new SqlParameter("Username", korisnik.KorisnickoIme));
                command.Parameters.Add(new SqlParameter("Firstname", korisnik.Ime));
                command.Parameters.Add(new SqlParameter("Lastname", korisnik.Prezime));
                command.Parameters.Add(new SqlParameter("TypeOfUser", korisnik.TipKorisnika.ToString()));
                command.Parameters.Add(new SqlParameter("Email", korisnik.Email));
                command.Parameters.Add(new SqlParameter("Active", korisnik.Aktivan));
                command.Parameters.Add(new SqlParameter("Pol", EPol.M));
                command.Parameters.Add(new SqlParameter("Lozinka", korisnik.Lozinka));
                command.Parameters.Add(new SqlParameter("Jmbg", korisnik.JMBG));

                return (int)command.ExecuteScalar();
            }
            //return -1;
        }

        public void updateUser(object obj)
        {
            Korisnik korisnik = obj as Korisnik;
            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"update dbo.Users 
                                        SET Active = @Active
                                        where username = @Username";

                command.Parameters.Add(new SqlParameter("Active", korisnik.Aktivan));
                command.Parameters.Add(new SqlParameter("Username", korisnik.KorisnickoIme));

                command.ExecuteNonQuery();
            }
        }



        public void updateUser1(object obj)
        {
            Korisnik korisnik = obj as Korisnik;
            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"update dbo.Users 
                                        SET firstname = @Firstname,
                                        lastname = @Lastname,
                                        jmbg = @JMBG,
                                        email = @Email,
                                        pol = @Pol
                                        where username = @Username";

                command.Parameters.Add(new SqlParameter("Username", korisnik.KorisnickoIme));
                command.Parameters.Add(new SqlParameter("firstname", korisnik.Ime));
                command.Parameters.Add(new SqlParameter("lastname", korisnik.Prezime));
                command.Parameters.Add(new SqlParameter("JMBG", korisnik.JMBG));
                command.Parameters.Add(new SqlParameter("email", korisnik.Email));
                command.Parameters.Add(new SqlParameter("pol", korisnik.Pol.ToString()));


                command.ExecuteScalar();
            }
        }
    }
}
