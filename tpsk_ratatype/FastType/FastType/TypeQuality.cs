using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace FastType
{
    /// <summary>
    /// Представляет свойства и статические методы для расчета скорости и печати 
    /// </summary>
    static class TypeQuality
    {
        /// <summary>
        ///  Возвращает, или задает скорость печати 
        /// </summary>
        internal static double Speed { get; set; }
        internal static int Fails { get; set; }
        /// <summary>
        /// Возвращает, или задает количество невеорно нажатых символов
        /// </summary>
        /// <sumamry>
        /// Расчитывает скорость печати в формате"знаки в минуту"
        /// </sumamry>
        internal static double Accuracy { get; set; }
        /// <summary>
        /// Задает статус печати для пользователя
        /// </summary>
        internal enum Status
        {
            /// <summary>
            /// Золото
            /// </summary>
            Gold =1,
            /// <summary>
            /// Серебро
            /// </summary>
            Silver,
            /// <summary>
            /// Бронза(Статутспечати)
            /// </summary>
            Bronze,
            NoStatus,
        }
        
       
        internal static string CalculateSpeed(TextBox userTb, TextBlock programTbl,int time)
        {
            
            String str = programTbl.Text.Substring(0, userTb.Text.Length);
            if(userTb.Text.Equals(str))
            {
                Speed = Math.Round(((Double)userTb.Text.Length / time * 60), 0);
                userTb.Foreground = new SolidColorBrush(Colors.Black);
                // расчет скорости
            }
            else
            {
                Fails++;
                userTb.Foreground = new SolidColorBrush(Colors.Red);
               // расчет ошибки
            }

            
            return Speed.ToString();
        }

        internal static string CalculateAccuracy(TextBlock tbl)
        {
            Accuracy = Math.Round((tbl.Text.Length-Fails) *100.0/tbl.Text.Length, 1);
            return Accuracy.ToString();
        }
    }
}
   



