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
    /// Логика взаимодействия для ProgramV.xaml
    /// </summary>
    public partial class ProgramV : Page
    {
        public ProgramV()
        {
            InitializeComponent();
        }
        ProgramVM programVM;
        public ProgramV(int id, SotrudnicWindowVM windowVM, Bank bank)
        {
            InitializeComponent();
            programVM = new ProgramVM(id, windowVM, bank);
            DataContext = programVM;
        }

        public void UPD()
        {
            programVM.UPD();
        }
    }
}
