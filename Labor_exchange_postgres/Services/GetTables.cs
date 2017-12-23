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
        #region Tables
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
        #endregion

        #region Ids
        static public int MaxClientId()
        {
            int max = 0;
            foreach (Client client in clients())
            {
                if (client.id > max)
                    max = client.id;
            }
            return max;
        }

        static public int MaxCompanyId()
        {
            int max = 0;
            foreach (Company company in companies())
            {
                if (company.id > max)
                    max = company.id;
            }
            return max;
        }

        static public int MaxApplicationId()
        {
            int max = 0;
            foreach (dbApplication app in applications())
            {
                if (app.id > max)
                    max = app.id;
            }
            return max;
        }

        static public int MaxVacancyId()
        {
            int max = 0;
            foreach (Vacancy vacancy in vacancies())
            {
                if (vacancy.id > max)
                    max = vacancy.id;
            }
            return max;
        }
        #endregion

        static public int GetProfId(string name)
        {
            foreach (Proficiency prof in proficiencies())
            {
                if (prof.name == name)
                    return prof.id;
            }
            return 0;
        }
    }
}
