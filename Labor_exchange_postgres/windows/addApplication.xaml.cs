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
using Labor_exchange_postgres.Services;
using Labor_exchange_postgres.Entities;

namespace Labor_exchange_postgres.windows
{
    /// <summary>
    /// Логика взаимодействия для addApplication.xaml
    /// </summary>
    public partial class addApplication : Window
    {
        public delegate bool AddApp(string comment, string prof);
        public AddApp del;

        public addApplication()
        {
            InitializeComponent();

            foreach (Proficiency prof in Tables.proficiencies())
            {
                profCB.Items.Add(prof.name);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int index = profCB.SelectedIndex;
            string prof = Tables.proficiencies()[index].name;
            string comment = CommentTB.Text;

            if ((comment != "") && (prof != ""))
                del(comment, prof);
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
