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

namespace FastType
{
    /// <summary>
    /// Логика взаимодействия для Education.xaml
    /// </summary>
    public partial class Education : Page
    {
        public Education()
        {
            InitializeComponent();
        }

        private void TextBlock_AccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
        {

        }

        private void Trenerovat_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new StartTyping ());
        }
    }
}