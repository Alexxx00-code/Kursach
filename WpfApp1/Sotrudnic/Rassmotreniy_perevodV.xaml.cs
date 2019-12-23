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
    /// Логика взаимодействия для Rassmotreniy_perevod.xaml
    /// </summary>
    public partial class Rassmotreniy_perevodV : Page
    {
        public Rassmotreniy_perevodV(int id, SotrudnicWindowVM window,Operacii operacii, Bank bank)
        {
            InitializeComponent();
            DataContext = new Rassmotreniy_perevodVM(id,operacii,bank,window);
        }
    }
}
