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
using WpfApp1.Model;

namespace WpfApp1.Clientu
{
    /// <summary>
    /// Логика взаимодействия для Perevod.xaml
    /// </summary>
    public partial class PerevodV : Page
    {
        PerevodVM perevod;
        public PerevodV(int id, ClientWindowVM window,Bank bank)
        {
            InitializeComponent();
            perevod = new PerevodVM(id, window, bank);
            DataContext = perevod;

        }
        
        public void UPD()
        {
            perevod.UPD();
        }

    }
}
