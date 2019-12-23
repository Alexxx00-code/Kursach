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
    /// Логика взаимодействия для Schet.xaml
    /// </summary>
    public partial class SchetV : Page
    {
        SchetVM schetVM;
        public SchetV(int id, ClientWindowVM window,Bank bank)
        {
            InitializeComponent();
            schetVM = new SchetVM(id, window, bank);
            DataContext = schetVM;
            Binding binding = new Binding();
            binding.ElementName = "";
        }
        public void UPD()
        {
            schetVM.UPD();
        }
    }
}
