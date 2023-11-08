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

namespace TeamProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для QuestionPage1.xaml
    /// </summary>
    public partial class QuestionPage1 : Page
    {
        string text { get; set; }
        public QuestionPage1(string text)
        {
            this.text = text;
            DataContext = this;
            InitializeComponent();
        }

        private void AcceptBtnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
