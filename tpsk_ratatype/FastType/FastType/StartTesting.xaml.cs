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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace FastType
{
    /// <summary>
    /// Логика взаимодействия для StartTesting.xaml
    /// </summary>
    public partial class StartTesting : Page
    {
        //таймер
        TypeQuality.Status status;
        DispatcherTimer timer=null;
        internal int time = 1;
        public StartTesting()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Tick += Timer_Tick;
            
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time++;
        }

        private void TypeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            timer.Start();
            ResultSpeedTbl.Text = TypeQuality.CalculateSpeed(TypeTb, TypeTbl, time);
            ResultAccuracyTbl.Text = TypeQuality.CalculateAccuracy(TypeTbl);
            
            if(TypeTb.Text.Length==TypeTbl.Text.Length)
            {
                //останвока таймера
                timer.Stop();
                //TypeTb перевести в режим "только для чтения"
                TypeTb.IsReadOnly = true;



                //присвоение статуса
                if (UserSession.IsUserEnter)
                {
                    if (TypeQuality.Speed >= 350 && TypeQuality.Accuracy >= 99.5)
                    {
                        status = TypeQuality.Status.Gold;
                    }
                    else if ((TypeQuality.Speed < 350 && TypeQuality.Accuracy < 99.5) && (TypeQuality.Speed >= 250 && TypeQuality.Accuracy >= 98.7))
                    {
                        status = TypeQuality.Status.Silver;
                    }
                    else if ((TypeQuality.Speed < 250 && TypeQuality.Accuracy < 98.7) && (TypeQuality.Speed >= 200 && TypeQuality.Accuracy >= 96))
                    {
                        status = TypeQuality.Status.Bronze;
                    }
                    else
                    {
                        status = TypeQuality.Status.NoStatus;
                    }
                    QuerySql.AddUserTypingResult("INSERT INTO UserRating(Userid,Speed,Accuracy,Statusid) VALUES (@userid,@speed,@accuracy,@status)", ResultSpeedTbl, ResultAccuracyTbl, status);
                    NavigationService.Navigate(new SignUserResult());
                }






                //добавление результата


                //если пользователь вошел,то делаем запись в бд

                //переход на другую страницу с результатом

            }


        }

        private void TrainGeBtn_Click(object sender, RoutedEventArgs e)
        {
            TypeQuality.Accuracy = 100;
            TypeQuality.Speed = 0;
            TypeTb.Text = string.Empty;
        }
    }
}
