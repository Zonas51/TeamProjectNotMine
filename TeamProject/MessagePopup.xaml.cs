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

namespace TeamProject
{
    /// <summary>
    /// Логика взаимодействия для MessagePopup.xaml
    /// </summary>
    public partial class MessagePopup : UserControl
    {
        public MessagePopup()
        {
            InitializeComponent();
        }
        public MessagePopup(string text)
        {
            TextWarn.Text = text;
            InitializeComponent();
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            Visibility=Visibility.Collapsed;
        }
    }
}
