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

        public bool AddClient(string name, int age)
        {
            Client newclient = new Client(Tables.MaxClientId()+1,name,age);
            return BDAdding.AddClient(newclient); 
        }

        public bool AddCompany(string name)
        {
            Company company = new Company(Tables.MaxCompanyId()+1, name);
            return BDAdding.AddCompany(company);
        }

        public bool AddApplication(string comment, int client_id, string client, string prof)
        {
            dbApplication app = new dbApplication(Tables.MaxApplicationId() + 1, comment,client_id,client,prof);
            return BDAdding.AddApplication(app);
        }

        public bool AddVacancy(string comment, int company_id, string company, string prof)
        {
            Vacancy vacancy=new Vacancy(Tables.MaxVacancyId()+1,comment,company_id,company,prof);
            return BDAdding.AddVacancy(vacancy);
        }
      
    }
}
