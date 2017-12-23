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
    /// Логика взаимодействия для addWindow.xaml
    /// </summary>
    public partial class addWindow : Window
    {
        public delegate bool AddClient(string name, int age);
        public AddClient del;

        public addWindow()
        {
            InitializeComponent();
            
        }

        private void addB_Click(object sender, RoutedEventArgs e)
        { 
            string name=""; 
            int age=0;

            try
            {
                name= nameTB.Text;
                age= Convert.ToInt32(ageTB.Text);
                del(name,age);
            }
            catch (Exception) { MessageBox.Show("Wrong input"); }           
            
            this.Close();
        }

        private void cancelB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
