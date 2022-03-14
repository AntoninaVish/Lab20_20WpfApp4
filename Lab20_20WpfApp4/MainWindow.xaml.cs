using System;
using System.Data;
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

namespace Lab20_20WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement el in MainRoot.Children) // через цикл перебираем все элементы (MainRoot), которые нахадятся в UniformGrid
                                                        // через Children получаем все дочерние объекты
            {
                if (el is Button) // el- это объект, является ли этот объект на основе класса Button
                {
                    ((Button)el).Click += Button_Click; // (метод) обработчик событий вызывается при нажатии на кнопку
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) // метод, который обрабатывает действие(нажатие)
        {
            string str = (string)((Button)e.OriginalSource).Content; // переменная str (внутри переменной установлен тот текст, который будет на кнопке, кторую нажал пользователь)

            if (str == "AC")// если пользователь нажимает на кнопку АС, тогда поле очищается
                textLabel.Text = "";


            else if (str == "=") // проверяем что указано на кнопке и если на кнопке будет знак "=" выполняет математическое действие
            {
                string value = new DataTable().Compute(textLabel.Text, null).ToString();// переменная value  в ней создаем объект класса DataTable
                                                                                        // обращаемся к методу Compute, этот метод высчитывается какую либо математическую операцию
                                                                                        // в качестве параметров передаем строку 
                textLabel.Text = value;// устанавливаем новое значение
            }
            else
                textLabel.Text += str;// добавляем новые значения

        }
    }
}
