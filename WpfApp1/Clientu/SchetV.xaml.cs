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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1.Clientu
{
    /// <summary>
    /// Логика взаимодействия для Schet.xaml
    /// </summary>
    public partial class SchetV : Page
    {
        public SchetV(int id, ClientWindow window)
        {
            InitializeComponent();
            DataContext = new SchetVM(id,window);
        }
    }
}