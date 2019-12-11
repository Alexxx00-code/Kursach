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
using WpfApp1;
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Osnovnoe.xaml
    /// </summary>
    public partial class Osnovnoe : Window
    {
        Controler bd;
        int Client_ID;
        public Osnovnoe(string login)
        {
            InitializeComponent();
            Client_ID = 1;
            DataContext =new Controler(Client_ID);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
