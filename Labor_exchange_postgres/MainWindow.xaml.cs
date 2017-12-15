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
using Labor_exchange_postgres.Entities;

namespace Labor_exchange_postgres
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WorkingWithTables exe;
        int status;

        public MainWindow()
        {
            InitializeComponent();
            exe = new WorkingWithTables();
            tableDGV1.CanUserSortColumns = false;
            tableDGV2.CanUserSortColumns = false;
            status=-1;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            tableDGV1.ItemsSource = Tables.clients();
            tableDGV2.ItemsSource = null;
            status = 0;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            tableDGV1.ItemsSource = Tables.companies();
            tableDGV2.ItemsSource = null;
            status = 1;
        }

        private void tableDGV1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = tableDGV1.SelectedIndex;
                if (status==0)
                {
                    int id = Tables.clients()[index].id;
                    tableDGV2.ItemsSource = exe.GetAppsByClientId(id);
                }
                if(status==1)
                {
                    int id = Tables.clients()[index].id;
                    tableDGV2.ItemsSource = exe.GetVacanciesByCompanyId(id);
                }
                if (status == 3)
                {
                    string prof = Tables.applications()[index].proficiency;
                    //List<int> indexes = exe.GetIndexesOfVacanciesByApplications(prof);
                    foreach (Vacancy vacancy in tableDGV2.ItemsSource)
                    {
                        var row = tableDGV2.ItemContainerGenerator.ContainerFromItem(vacancy) as DataGridRow;
                        if (vacancy.proficiency == prof)
                            row.Background = Brushes.LightSkyBlue;
                        else row.Background = Brushes.White;
                    }
                }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tableDGV1.ItemsSource = Tables.applications();
            tableDGV2.ItemsSource = Tables.vacancies();
            status = 3;
        }
    }
}
