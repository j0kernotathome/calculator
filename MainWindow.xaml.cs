using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator2000
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Token { get; set; } // то шо ввели в поле
        public int[] Tokens { get; set; } // массив с числами
        public string MathChar { get; set; } // то шо выбирают в символах

        public double firstValue, secondValue, result;

        public bool isSec = false, StartNewNumb = false;



        public MainWindow()
        {
            InitializeComponent();
        }
        
        // кнопки с цифрами
        private void bttn7(object sender, RoutedEventArgs e)
        {
            Token = 7;
            if (isSec && StartNewNumb) // проверка, яаляется ли число новым
            {
                tokenBox.Text = "";
                tokenBox.Text += Convert.ToDouble(Token);
                StartNewNumb = false;
            }
            else if (isSec && StartNewNumb == false) // проверяет, дописывают ли новое число
            {
                tokenBox.Text += Convert.ToDouble(Token);
            }
            else
            {
                tokenBox.Text += Convert.ToDouble(Token); // просто ввод самого первого числа
            }
        }

        private void bttn8(object sender, RoutedEventArgs e)
        {
            Token = 8;
            tokenBox.Text += Convert.ToDouble(Token); // присвоение значения 8. Вообще можно и через метод, но тут одна строчка кода так что хз

        }

        private void bttn9(object sender, RoutedEventArgs e)
        {
            Token = 9;
            tokenBox.Text += Convert.ToDouble(Token); //

        }

        private void bttn4(object sender, RoutedEventArgs e)
        {
            Token = 4;
            tokenBox.Text += Convert.ToDouble(Token); //

        }

        private void bttn5(object sender, RoutedEventArgs e)
        {
            Token = 5;
            tokenBox.Text += Convert.ToDouble(Token); //

        }

        private void bttn6(object sender, RoutedEventArgs e)
        {
            Token = 6;
            tokenBox.Text += Convert.ToDouble(Token); //

        }

        private void bttn1(object sender, RoutedEventArgs e)
        {
            Token = 1;
            tokenBox.Text += Convert.ToDouble(Token); //

        }

        private void bttn2(object sender, RoutedEventArgs e)
        {
            Token = 2;
            tokenBox.Text += Convert.ToDouble(Token); //

        }

        private void bttn3(object sender, RoutedEventArgs e)
        {
            Token = 3;
            tokenBox.Text += Convert.ToDouble(Token); //

        }

        private void bttn0(object sender, RoutedEventArgs e)
        {
            Token = 0;
            tokenBox.Text += Convert.ToDouble(Token); //

        }

        // кнопки с действиями
        private void bttneq(object sender, RoutedEventArgs e) // =
        {
            DoMath(firstValue, secondValue, MathChar); // вызов метода вывода резальтата
        }

        private void bttnpl(object sender, RoutedEventArgs e) // +
        {
            MathChar = "+";
            if (isSec && StartNewNumb == false)
            {
                secondValue = Convert.ToDouble(tokenBox.Text); // сохраняем второе число
                DoMath(firstValue, secondValue, MathChar); // у нас калькулятор китайский, принимает только 2 слогаемых, тут проверка на то, 
                                                //ввели ли мы два числа
            }
            else
            {
                firstValue = Convert.ToDouble(tokenBox.Text); // сохраняем первое число
                tokenBox.Text += Convert.ToChar(MathChar); // вывод
                isSec = true; // теперь можно писать второе число

                StartNewNumb = true; // записываем новое число
            }
            

        }

        private void bttnmn(object sender, RoutedEventArgs e) // -
        {
            MathChar = "-";
            tokenBox.Text += Convert.ToChar(MathChar); //

        }

        private void bttnmul(object sender, RoutedEventArgs e) // *
        {
            MathChar = "*";
        }

        private void bttnbktr(object sender, RoutedEventArgs e) // (
        {
            MathChar = "(";
        }

        private void bttnbktl(object sender, RoutedEventArgs e) // )
        {
            MathChar = ")";
        }

        private void bttndeg(object sender, RoutedEventArgs e) // /
        {
            MathChar = "/";
        }

        private void bttndel(object sender, RoutedEventArgs e) // удалить
        {
            MathChar = "del";
        }

        private void DoMath(double a, double b, string MathSymol)
        {
            switch(MathSymol)
            {
                case "+":
                    result = a + b; // пока только сложение
                    tokenBox.Text = Convert.ToString(result); // вывод результата, но тут какая-то хрень и она не работает
                    break;
            }

            
        }
    }
}