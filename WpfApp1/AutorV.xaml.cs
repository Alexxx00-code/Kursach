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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Autor.xaml
    /// </summary>
    public partial class AutorV : Window
    {
        public AutorV()
        {
            InitializeComponent();
            DataContext = new AutorVM(this);
        }
    }
}
