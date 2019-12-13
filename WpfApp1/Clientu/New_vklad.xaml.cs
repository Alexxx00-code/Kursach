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

namespace WpfApp1.Clientu
{
    /// <summary>
    /// Логика взаимодействия для New_vklad.xaml
    /// </summary>
    public partial class New_vklad : Page
    {
        public New_vklad(int id, ClientWindow window)
        {
            InitializeComponent();
            DataContext = new New_VkladVM(id, window);
        }
    }
    
}
