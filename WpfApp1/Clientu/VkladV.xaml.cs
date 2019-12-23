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

namespace WpfApp1.Clientu
{
    /// <summary>
    /// Логика взаимодействия для Vklad.xaml
    /// </summary>
    public partial class VkladV : Page
    {
        VkladVM VkladVM;
        public VkladV(int id, ClientWindowVM window,Bank bank)
        {
            InitializeComponent();
            VkladVM = new VkladVM(id, window,bank);
            DataContext = VkladVM;
        }
        public void UPD()
        {
            VkladVM.UPD();
        }
    }
}
