﻿using PLWPF.Helpers;
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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        BE.Order order = new BE.Order();

        public Order(Mode mode)
        {
            InitializeComponent();

            this.DataContext = order;
        }

        public Order(Mode mode, BE.Order foundOrder)
        {
            order = foundOrder;

            InitializeComponent();

            this.DataContext = order;
        }
    }
}
