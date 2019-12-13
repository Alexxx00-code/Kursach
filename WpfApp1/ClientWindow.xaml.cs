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
using WpfApp1.Clientu;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        int Client_ID =3;
        public ClientWindow()
        {
            InitializeComponent();
            Page.Content = new SchetV(Client_ID, this);
            DataContext = new MainWindowVM(Client_ID, this);

            
        }
    }
}
