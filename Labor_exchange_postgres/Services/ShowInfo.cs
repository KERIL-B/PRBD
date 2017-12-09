using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labor_exchange_postgres.Entities;
using System.Windows.Controls;

namespace Labor_exchange_postgres.Services
{
    class ShowInfo
    {
        private BDReading go;
 
        public ShowInfo()
        {
            go = new BDReading();
        }

        public void ShowClients(DataGrid tableDGV)
        {
            List<Client> clients = go.GetClients();
            tableDGV.ItemsSource = clients;
        }

        public void ShowCompanies(DataGrid tableDGV)
        {
            List<Company> companies = go.GetCompanies();
            tableDGV.ItemsSource = companies;
        }

        public void ShowVacancies(DataGrid tableDGV)
        {
            List<Vacancy> vacancies = go.GetVacancies();
            tableDGV.ItemsSource = vacancies;
        }

        public void ShowApplications(DataGrid tableDGV)
        {
            List<dbApplication> applications = go.GetApplications();
            tableDGV.ItemsSource = applications;
        }

        public void ShowCompare(DataGrid tableDGV1, DataGrid tableDGV2)
        {
            ShowVacancies(tableDGV1);
            ShowApplications(tableDGV2);
        }

        public void ShowCompareOneTable(DataGrid table)
        {
 
        }
    }
}
