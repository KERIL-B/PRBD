using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labor_exchange_postgres.Entities;
using Npgsql;

namespace Labor_exchange_postgres.Services
{
     static class BDReading
    {
        private const string connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgre;Database=Labor_Exchange;";

        public static List<Client> GetClients()
        {
            List<Client> list = new List<Client>();

            string sqlQuery = "SELECT * FROM public.\"Client\"";

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand(sqlQuery, conn);
            conn.Open();

            NpgsqlDataReader reader;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    Client client = new Client(reader.GetInt32(0), reader.GetString(2), reader.GetInt32(1));
                    list.Add(client);
                }
                catch { }

            }
            conn.Close();

            return list;
        }

        static public List<Company> GetCompanies()
        {
            List<Company> list = new List<Company>();

            string sqlQuery = "SELECT * FROM public.\"Company\"";

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand(sqlQuery, conn);
            conn.Open();

            NpgsqlDataReader reader;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    Company company = new Company(reader.GetInt32(0), reader.GetString(1));
                    list.Add(company);
                }
                catch { }

            }
            conn.Close();

            return list;
        }

        static public List<Vacancy> GetVacancies()
        {
            List<Vacancy> list = new List<Vacancy>();

            string sqlQuery = "SELECT * FROM public.\"Vacancy\"\n" +
                "JOIN public.\"Company\"\n" +
                "ON public.\"Vacancy\".id_company=public.\"Company\".id_company\n" +
                "JOIN public.\"Proficiency\"\n" +
                "ON public.\"Vacancy\".id_proficiency=public.\"Proficiency\".id_proficiency";

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand(sqlQuery, conn);
            conn.Open();

            NpgsqlDataReader reader;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    Vacancy vacancy = new Vacancy(reader.GetInt32(0), reader.GetString(3), reader.GetInt32(4),reader.GetString(5), reader.GetString(7));
                    list.Add(vacancy);
                }
                catch { }

            }
            conn.Close();

            return list;
        }

        static public List<dbApplication> GetApplications()
        {
            List<dbApplication> list = new List<dbApplication>();

            string sqlQuery = "SELECT * FROM public.\"Application\"\n" +
                "JOIN public.\"Client\"\n" +
                "ON public.\"Application\".id_client=public.\"Client\".id_client\n" +
                "JOIN public.\"Proficiency\"\n" +
                "ON public.\"Application\".id_proficiency=public.\"Proficiency\".id_proficiency";

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand(sqlQuery, conn);
            conn.Open();

            NpgsqlDataReader reader;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    dbApplication application = new dbApplication(reader.GetInt32(0), reader.GetString(3), reader.GetInt32(4), reader.GetString(6), reader.GetString(8));
                    list.Add(application);
                }
                catch { }

            }
            conn.Close();

            return list;
        }

        static public List<Proficiency> GetProficiencies()
        {
            List<Proficiency> list = new List<Proficiency>();

            string sqlQuery = "SELECT * FROM public.\"Proficiency\"";

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand(sqlQuery, conn);
            conn.Open();

            NpgsqlDataReader reader;
            reader = comm.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    Proficiency proficiency = new Proficiency(reader.GetInt32(0), reader.GetString(1));
                    list.Add(proficiency);
                }
                catch { }

            }
            conn.Close();

            return list;
        }
    }
}
