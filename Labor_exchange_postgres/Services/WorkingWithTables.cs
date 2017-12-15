using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labor_exchange_postgres.Entities;

namespace Labor_exchange_postgres.Services
{
    
    class WorkingWithTables
    {
        public List<dbApplication> GetAppsByClientId(int id)
        {
            List<dbApplication> list=new List<dbApplication>();
            foreach (dbApplication application in Tables.applications())
            {
                if (application.client_id == id)
                    list.Add(application);
            }
            return list;
        }

        public List<Vacancy> GetVacanciesByCompanyId(int id)
        {
            List<Vacancy> list = new List<Vacancy>();
            foreach (Vacancy vacancy in Tables.vacancies())
            {
                if (vacancy.company_id == id)
                    list.Add(vacancy);
            }
            return list;
        }

        public List<int> GetIndexesOfVacanciesByApplications(string prof)
        {
            List<int> indexes = new List<int>();
            int i=0;
            foreach(Vacancy vacancy in Tables.vacancies())
            {
                if (vacancy.proficiency == prof)
                    indexes.Add(i);
                ++i;
            }
            return indexes;
        }
    }
}
