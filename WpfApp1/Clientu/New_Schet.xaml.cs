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
using WpfApp1.Model;

namespace WpfApp1.Clientu
{
    /// <summary>
    /// Логика взаимодействия для New_Schet.xaml
    /// </summary>
    public partial class New_SchetV : Page
    {
        public New_SchetV(int id,ClientWindowVM window,Bank bank)
        {
            InitializeComponent();
            DataContext = new New_SchetVM(id,window,bank);
        }
    }
}
