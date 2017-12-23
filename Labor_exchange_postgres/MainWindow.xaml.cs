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
using Labor_exchange_postgres.windows;

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

            status = -1;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            tableDGV1.ItemsSource = Tables.clients();
            tableDGV1.CanUserAddRows = true;
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
            if (status == 0)
            {
                int id = Tables.clients()[index].id;
                tableDGV2.ItemsSource = exe.GetAppsByClientId(id);
                tableDGV2.CanUserAddRows = true;
            }
            if (status == 1)
            {
                int id = Tables.clients()[index].id;
                tableDGV2.ItemsSource = exe.GetVacanciesByCompanyId(id);
            }
            if (status == 3)
            {
                string prof = Tables.applications()[index].proficiency;
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
            CompanyRB.IsChecked = false;
            ClientRB.IsChecked = false;
            tableDGV1.ItemsSource = Tables.applications();
            tableDGV2.ItemsSource = Tables.vacancies();
            status = 3;

        }

        private void tableDGV1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            int index = tableDGV1.SelectedIndex;
            if (index >= 0)
            {
                menu.Margin = new Thickness(e.GetPosition(null).X, e.GetPosition(null).Y, 0, 0);
                if (status == 0)
                {
                    Item1.Header = "add client";
                    Item2.Header = "add application";
                    menu.Visibility = Visibility.Visible;
                }
                if (status == 1)
                {
                    Item1.Header = "add company";
                    Item2.Header = "add vacancy";
                    menu.Visibility = Visibility.Visible;
                }

            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Hidden;
            if (status == 0)
            {
                addWindow win = new addWindow();
                win.del = exe.AddClient;
                win.Show();
            }
            if (status == 1)
            {
                addCompany win = new addCompany();
                win.del = exe.AddCompany;
                win.Show();
            }
        }

        private void Item2_Click(object sender, RoutedEventArgs e)
        {
            menu.Visibility = Visibility.Hidden;
            if (status == 0)
            {
                addApplication win = new addApplication();
                win.del = AddApp;
                win.Show();
            }
            if (status == 1)
            {
                addVacancy win = new addVacancy();
                win.del = AddVacancy;
                win.Show();
            }
        }

        private void RefreshTables()
        {
            switch (status)
            {
                case 0: tableDGV1.ItemsSource = Tables.clients(); break;
                case 1: tableDGV1.ItemsSource = Tables.companies(); break;
                case 2: tableDGV1.ItemsSource = Tables.applications();
                    tableDGV2.ItemsSource = Tables.vacancies(); break;
            }
        }

        private void Window_Activated_1(object sender, EventArgs e)
        {
            RefreshTables();
        }

        public bool AddApp(string comment, string prof)
        {
            int index=tableDGV1.SelectedIndex;
            int id=Tables.clients()[index].id;
            string name=Tables.clients()[index].name;
            return exe.AddApplication(comment,id,name,prof);
        }

        public bool AddVacancy(string comment, string prof)
        {
            int index=tableDGV1.SelectedIndex;
            int id=Tables.companies()[index].id;
            string name=Tables.clients()[index].name;
            return exe.AddVacancy(comment, id, name, prof);
        }

    }
}
