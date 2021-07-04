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
    /// Логика взаимодействия для SignUserResult.xaml
    /// </summary>
    public partial class SignUserResult : Page
    {
        public SignUserResult()
        {
            InitializeComponent();
            SignUserSpeed.Text = TypeQuality.Speed.ToString();
            SignUserAccuracy.Text = TypeQuality.Accuracy.ToString();
            SignUserName.Text = UserSession.Username.ToString();
        }

        private void TryAgainBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartTesting());
        }
    }
}
