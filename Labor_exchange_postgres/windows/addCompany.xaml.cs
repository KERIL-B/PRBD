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
using System.Windows.Shapes;

namespace Labor_exchange_postgres.windows
{
    /// <summary>
    /// Логика взаимодействия для addCompany.xaml
    /// </summary>
    public partial class addCompany : Window
    {
        public delegate bool AddCompany(string name);
        public AddCompany del;

        public addCompany()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string name = nameTB.Text;
            if (name != "")
                del(name);
            else 
                MessageBox.Show("Wrong input");
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
