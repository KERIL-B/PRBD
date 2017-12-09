using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Labor_exchange_postgres.Services;

namespace Labor_exchange_postgres
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ShowInfo go;

        public MainWindow()
        {
            InitializeComponent();
            SetComboBox();         
            go =new ShowInfo();
        }

        private void SetComboBox()
        {
            TablesCB.Items.Add("Client");
            TablesCB.Items.Add("Company");
            TablesCB.Items.Add("Vacancy");
            TablesCB.Items.Add("Application");
            TablesCB.Items.Add("Compare");
        }

        private void TablesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (TablesCB.SelectedIndex)
            {
                case 0: go.ShowClients(tableDGV1);  break;
                case 1: go.ShowCompanies(tableDGV1); break;
                case 2: go.ShowVacancies(tableDGV1); break;
                case 3: go.ShowApplications(tableDGV1); break;
                case 4: go.ShowCompare(tableDGV1, tableDGV2); break;
                    
            }
        }
    }
}
