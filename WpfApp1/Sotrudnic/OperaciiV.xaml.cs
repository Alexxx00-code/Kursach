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
    /// Логика взаимодействия для OperaciiV.xaml
    /// </summary>
    public partial class OperaciiV : Page
    {
        OperaciiVM operacii;
        public OperaciiV(int id, SotrudnicWindowVM window, Bank bank)
        {
            InitializeComponent();
            operacii = new OperaciiVM(id,window,bank);
            DataContext = operacii;
        }
        public void UPD()
        {
            operacii.UPD();
        }
    }
}
