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
using WpfApp1.Model;

namespace WpfApp1.Clientu
{
    /// <summary>
    /// Логика взаимодействия для KreditV.xaml
    /// </summary>
    public partial class KreditV : Page
    {
        KreditVM kreditVM;
        public KreditV(int id, ClientWindowVM window,Bank bank)
        {
            InitializeComponent();
            kreditVM = new KreditVM(id, window, bank);
            DataContext = kreditVM;
        }
        public void UPD()
        {
            kreditVM.UPD();
        }
    }
}
