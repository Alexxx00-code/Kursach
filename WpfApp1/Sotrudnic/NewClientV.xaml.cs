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
using WpfApp1.Model;
namespace WpfApp1.Sotrudnic
{
    /// <summary>
    /// Логика взаимодействия для NewClientV.xaml
    /// </summary>
    public partial class NewClientV : Page
    {
        public NewClientV(int ID,SotrudnicWindowVM windowVM,Bank bank)
        {
            InitializeComponent();
            DataContext = new NewClientVM(ID, windowVM, bank);
        }
        public NewClientV(int ID, SotrudnicWindowVM windowVM, Bank bank,Client client)
        {
            InitializeComponent();
            DataContext = new NewClientVM(ID, windowVM, bank,client);
        }
    }
}
