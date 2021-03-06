﻿using System;
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
using WpfApp1.Sotrudnic;
using WpfApp1.Model;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для New_Prog.xaml
    /// </summary>
    public partial class New_ProgV : Page
    {
     
        public New_ProgV(int ID, SotrudnicWindowVM windowVM, Bank bank)
        {
            InitializeComponent();
            DataContext = new New_ProgVM(ID, windowVM, bank);
        }
        public New_ProgV(int ID, SotrudnicWindowVM windowVM, Bank bank, Prog prog)
        {
            InitializeComponent();
            DataContext = new New_ProgVM(ID, windowVM, bank, prog);
        }
    }
}
