using MongoDB.Driver.Core.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Csharp_and_SQL_connect
{
    class Program
    {
        private static string connectionString = @"Server=DESKTOP-5NGLKM0\SQLEXPRESS;Database=CINEMA;Trusted_Connection=True;";
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            //GetCinemaById();
            //Console.WriteLine("=========================================================");
            //GetCinemaCreateActors("Nicat", "Məmmədov", 19);
            //Console.WriteLine("=========================================================");
            //GetCinemaCreateCustomers("Sebuhi", "Behbudov", 22);
            //Console.WriteLine("=========================================================");
            //GetCinemaFilmsDelete(3);
            //Console.WriteLine("=========================================================");
            //GetCinemaUpdateGenres(2);
            //Console.WriteLine("=========================================================");
            //GetCinemaUpdateHalls(1);
            //Console.WriteLine("=========================================================");
            //GetCinemaAllActors();
            //Console.WriteLine("=========================================================");
            //GetCinemaAllCustomers();
            //Console.WriteLine("=========================================================");
            //GetCinemaAllFilms();
            //Console.WriteLine("=========================================================");
            //GetCinemaAllTickets();
            //Console.WriteLine("=========================================================");
            //GetCinemaUpdateTickets(4);
            //Console.WriteLine("=========================================================");
            //GetCinemaUpdateFilms(5);
            //Console.WriteLine("=========================================================");
            //GetCinemaActorsDelete(2);
            //Console.WriteLine("=========================================================");
            //GetCinemaSessionDelete(3);
            //Console.WriteLine("=========================================================");
            GetCinemaHallsDelete(1);
        }
        static void GetCinemaById()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = " SELECT Name FROM Customers WHERE Id =1 ";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    string result = comm.ExecuteScalar().ToString();
                    Console.WriteLine(result);
                }
            }
        }
        //CREATE
        static void GetCinemaCreateActors(string name, string surname, int age)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"INSERT INTO Actors VALUES (N'{name}',N'{surname}',N'{age}')";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    Console.WriteLine(comm.ExecuteNonQuery());
                }
            }
        }
        static void GetCinemaCreateCustomers(string name, string surname, int age)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"INSERT INTO Customers VALUES (N'{name}',N'{surname}',N'{age}')";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    Console.WriteLine(comm.ExecuteNonQuery());
                }
            }
        }
        //DELETE
        static void GetCinemaFilmsDelete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE Films Where Id={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Film is deleted!");
                    }
                    else
                    {
                        Console.WriteLine("Id not found!");
                    }
                }

            }
        }
        //UPDATE 
        static void GetCinemaUpdateGenres(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"UPDATE Genres SET Name = 'Qorxu' WHERE Id={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    Console.WriteLine(comm.ExecuteNonQuery());
                }
            }
        }
        //SELECT
        static void GetCinemaAllActors()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"SELECT * FROM Actors";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetInt32("Id") + ". " + reader.GetString("Name") + " " + reader.GetString("Surname") + " " + reader.GetInt32("Age"));
                        }
                    }
                }
                #region 2-ci usul
                /*
                using (SqlDataAdapter sda = new SqlDataAdapter(command, conn))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        Console.WriteLine($"{dr["Id"]}. {dr["Name"]} {dr["Surname"]} {dr["Age"]}");
                    }
                }
                */
                #endregion
            }
        }
        static void GetCinemaUpdateHalls(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"UPDATE Halls SET Name = 'Zal 5' WHERE Id={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    Console.WriteLine(comm.ExecuteNonQuery());
                }
            }
        }
        static void GetCinemaAllCustomers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"SELECT * FROM Customers";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetInt32("Id") + ". " + reader.GetString("Name") + " " + reader.GetString("Surname") + " " + reader.GetInt32("Age"));
                        }
                    }
                }
            }
        }
        static void GetCinemaAllFilms()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"SELECT * FROM Films";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetInt32("Id") + ". " + reader.GetString("Name") + " " + reader.GetDateTime("Releasedate"));
                        }
                    }
                }
            }
        }
        static void GetCinemaAllTickets()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"SELECT * FROM Tickets";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader.GetInt32("Id") + ". " + reader.GetDateTime("Solddate") + " " + reader.GetDecimal("Price") + " " + reader.GetInt32("Place"));
                        }
                    }
                }
            }
        }
        static void GetCinemaUpdateTickets(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"UPDATE Tickets SET Price = '25.55' WHERE Id={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    Console.WriteLine(comm.ExecuteNonQuery());
                }
            }
        }
        static void GetCinemaUpdateFilms(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"UPDATE Films SET Name = 'Kurtlar Vadisi' WHERE Id={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    Console.WriteLine(comm.ExecuteNonQuery());
                }
            }
        }
        static void GetCinemaActorsDelete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE Actors Where Id={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Actors is deleted!");
                    }
                    else
                    {
                        Console.WriteLine("Id not found!");
                    }
                }
            }
        }
        static void GetCinemaSessionDelete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE Session Where Id={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Session is deleted!");
                    }
                    else
                    {
                        Console.WriteLine("Id not found!");
                    }
                }
            }
        }
        static void GetCinemaHallsDelete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string command = $"DELETE Halls Where Id={id}";
                using (SqlCommand comm = new SqlCommand(command, conn))
                {
                    if (comm.ExecuteNonQuery() > 0)
                    {
                        Console.WriteLine("Halls is deleted!");
                    }
                    else
                    {
                        Console.WriteLine("Id not found!");
                    }
                }
            }
        }
    }
}
