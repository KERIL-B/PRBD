using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labor_exchange_postgres.Entities;
using Npgsql;

namespace Labor_exchange_postgres.Services
{
     static class BDAdding
    {
        private const string connectionString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgre;Database=Labor_Exchange;";

        static public bool AddClient(Client client)
        {
            string sqlQuery = "INSERT INTO public.\"Client\" VALUES(" + client.id + ", " + client.age + ", '" + client.name + "');";

            return ExecuteQuery(sqlQuery);
        }

        static public bool AddCompany(Company company)
        {
            string sqlQuery = "INSERT INTO public.\"Company\" VALUES(" + company.id + ", '" + company.name + "');";

            return ExecuteQuery(sqlQuery);
        }

        static public bool AddApplication(dbApplication app)
        {
            string sqlQuery = "INSERT INTO public.\"Application\" VALUES("+app.id+", "+app.client_id+","+Tables.GetProfId(app.proficiency)+",'"+app.comment+"');";

            return ExecuteQuery(sqlQuery);
        }

        static public bool AddVacancy(Vacancy vacancy)
        {
            string sqlQuery = "INSERT INTO public.\"Vacancy\" VALUES("+vacancy.id+", "+vacancy.company_id+", "+Tables.GetProfId(vacancy.proficiency)+",'"+vacancy.comment+"');";

            return ExecuteQuery(sqlQuery);
        }

        static private bool ExecuteQuery(string sqlQuery)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand(sqlQuery, conn);
            conn.Open();

            int result = comm.ExecuteNonQuery();

            conn.Close();

            return result >= 0;
        }
    }
}
