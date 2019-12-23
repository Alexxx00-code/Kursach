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
    /// Логика взаимодействия для Operacii_na_potv.xaml
    /// </summary>
    public partial class Operacii_na_potvV : Page
    {
        Operacii_na_potvVM VM;
        public Operacii_na_potvV(int id, SotrudnicWindowVM window, Bank bank)
        {
            InitializeComponent();
            VM = new Operacii_na_potvVM(id,window,bank,this);
            DataContext = VM;
        }
        public void UPD()
        {
            VM.UPD();
        }
    }
}
