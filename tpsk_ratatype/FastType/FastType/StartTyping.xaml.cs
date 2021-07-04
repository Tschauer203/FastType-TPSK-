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
    /// Логика взаимодействия для StartTyping.xaml
    /// </summary>
    public partial class StartTyping : Page
    {
        bool isCapital=true;
        bool isBackpace = true;
        int fails = 0;
        internal static string speed;
        int time=0;

        DispatcherTimer timer;

        
        public StartTyping()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time++;
        }

        void CapitalLetters()
        {
            Q.Content = "Й";
            W.Content = "Ц";
            E.Content = "У";
            R.Content = "К";
            T.Content = "Е";
            Y.Content = "Н";
            U.Content = "Г";
            I.Content = "Ш";
            O.Content = "Щ";
            P.Content = "З";
            OemOpenBreckets.Content = "Х";
            Oem6.Content = "Ъ";
            A.Content = "Ф";
            S.Content = "Ы";
            D.Content = "В";
            F.Content = "А";
            G.Content = "П";
            H.Content = "Р";
            J.Content = "О";
            K.Content = "Л";
            L.Content = "Д";
            Oem1.Content = "Ж";
            OemQuotes.Content = "Э";
            Z.Content = "Я";
            X.Content = "Ч";
            C.Content = "С";
            V.Content = "М";
            B.Content = "И";
            N.Content = "Т";
            M.Content = "Ь";
            OemComma.Content = "Б";
            OemPeriod.Content = "Ю";
            Oem3.Content = "Ё";
            LeftSHIFT.Content = "Shift";
            



        }
        void CapitaLSymbols()
        {
            D1.Content = "!";
            D2.Content = "";
            D3.Content = "№";
            D4.Content = ";";
            D5.Content = "%";
            D6.Content = ":";
            D7.Content = "?";
            D8.Content = "*";
            D9.Content = "(";
            D0.Content = ")";
            OemMinus.Content = "_";
            OemPlus.Content = "=";
            OemQuestion.Content = ",";
            Oem5.Content = "/";
           
        }
        void LowerLetters()
        {
            Q.Content = "й";
            W.Content = "ц";
            E.Content = "у";
            R.Content = "к";
            T.Content = "е";
            Y.Content = "н";
            U.Content = "г";
            I.Content = "ш";
            O.Content = "щ";
            P.Content = "з";
            OemOpenBreckets.Content = "х";
            Oem6.Content = "ъ";
            A.Content = "ф";
            S.Content = "ы";
            D.Content = "в";
            F.Content = "а";
            G.Content = "п";
            H.Content = "р";
            J.Content = "о";
            K.Content = "л";
            L.Content = "д";
            Oem1.Content = "ж";
            OemQuotes.Content = "э";
            Z.Content = "я";
            X.Content = "ч";
            C.Content = "с";
            V.Content = "м";
            B.Content = "и";
            N.Content = "т";
            M.Content = "ь";
            OemComma.Content = "б";
            OemPeriod.Content = "ю";
            RightSHIFT.Content = "Shift";





        }
        void LowerSymbols()
        {
            D1.Content = "1";
            D2.Content = "2";
            D3.Content = "3";
            D4.Content = "4";
            D5.Content = "5";
            D6.Content = "6";
            D7.Content = "7";
            D8.Content = "8";
            D9.Content = "9";
            D0.Content = "0";
            OemMinus.Content = "-";
            OemPlus.Content = "=";
            OemQuestion.Content = ".";
            Oem5.Content = "/";
        }

        private void MainPage_PreviewKeyDown(object sender, KeyEventArgs e)
        { 
            foreach(UIElement ui in GridBtns.Children)
            {
                if(ui is StackPanel)
                {
                    foreach(var item in (ui as StackPanel).Children)
                    {
                        if(item is Button)
                        {
                        
                            if ((item as Button).Name == e.Key.ToString())
                            {
                                (item as Button).Opacity = 0.5;
                                if (e.Key.ToString() == "Capital")

                                
                                {
                                    if (isCapital)
                                    {
                                        CapitalLetters();
                                        isCapital = false;
                                    }

                                    else
                                    {
                                        LowerLetters();
                                        isCapital = true;
                                    }
                                }
                                if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    CapitaLSymbols();
                                    CapitalLetters();
                                }

                            }
                      
                        }
                    }
                }
            }
        }

        private void MainPage_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            foreach (UIElement ui in GridBtns.Children)
            {
                if (ui is StackPanel)
                {
                    foreach (var item in (ui as StackPanel).Children)
                    {
                        if (item is Button)
                        {

                            if ((item as Button).Name == e.Key.ToString())
                            {
                                (item as Button).Opacity = 1;


                                if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                {
                                    LowerSymbols();
                                    LowerLetters();
                                }
                            }
                            
                               
                        }
                    }
                }
            }

        }

        private void UserLine_TextChanged(object sender, TextChangedEventArgs e)
        {
            timer.Start();
            string programLine = ProgramLine.Text.Substring(0, UserLine.Text.Length);
            if (UserLine.Text.Equals(programLine))
            {
                Speed();
                UserLine.Foreground = Brushes.Green;
            }
            else
            {
                UserLine.Foreground = Brushes.Red;
                fails++;
            }

            Fails.Text = speed;
            if (ProgramLine.Text.Length == UserLine.Text.Length)
            {
                timer.Stop();
                UserLine.IsReadOnly = true;
               
                this.NavigationService.Navigate(new TypinResults());
            }
            


            
        }

       void Speed()
       {
            speed = Math.Round(((((double)UserLine.Text.Length) / time) * 60), 0).ToString();
       }
    }
}
