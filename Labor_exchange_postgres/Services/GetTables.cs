using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labor_exchange_postgres.Entities;


namespace Labor_exchange_postgres.Services
{
    static class Tables
    {
        static public List<Client> clients()
        {
            return BDReading.GetClients();
        }

        static public List<Company> companies()
        {
            return BDReading.GetCompanies();
        }

        static public List<dbApplication> applications()
        {
            return BDReading.GetApplications();
        }

        static public List<Vacancy> vacancies()
        {
            return BDReading.GetVacancies();
        }

        static public List<Proficiency> proficiencies()
        {
            return BDReading.GetProficiencies();
        }
    }
}
