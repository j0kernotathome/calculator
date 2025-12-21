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
        public string Token { get; set; } // то шо ввели в поле
        

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void DoMath(string Token)
        {
            tokenBox.Text += Convert.ToString(Token); // ToString можно поменять на другой тип данных
            
        }

        // кнопки с цифрами
        private void bttn7(object sender, RoutedEventArgs e)
        {
            Token = "7";
            DoMath(Token);

        }

        private void bttn8(object sender, RoutedEventArgs e)
        {
            Token = "8";
            DoMath(Token);
        }

        private void bttn9(object sender, RoutedEventArgs e)
        {
            Token = "9";
            DoMath(Token);
        }

        private void bttn4(object sender, RoutedEventArgs e)
        {
            Token = "4";
            DoMath(Token);
        }

        private void bttn5(object sender, RoutedEventArgs e)
        {
            Token = "5";
            DoMath(Token);
        }

        private void bttn6(object sender, RoutedEventArgs e)
        {
            Token = "6";
            DoMath(Token);
        }

        private void bttn1(object sender, RoutedEventArgs e)
        {
            Token = "1";
            DoMath(Token);
        }

        private void bttn2(object sender, RoutedEventArgs e)
        {
            Token = "2";
            DoMath(Token);
        }

        private void bttn3(object sender, RoutedEventArgs e)
        {
            Token = "3";
            DoMath(Token);
        }

        private void bttn0(object sender, RoutedEventArgs e)
        {
            Token = "0";
            DoMath(Token);
        }


        private void bttnpl(object sender, RoutedEventArgs e) // +
        {
            Token = "+";
            DoMath(Token);
        }

        private void bttnmn(object sender, RoutedEventArgs e) // -
        {
            Token = "-";
            DoMath(Token);
        }

        private void bttnmul(object sender, RoutedEventArgs e) // *
        {
            Token = "*";
            DoMath(Token);
        }

        private void bttnbktr(object sender, RoutedEventArgs e) // (
        {
            Token = "(";
            DoMath(Token);
        }

        private void bttnbktl(object sender, RoutedEventArgs e) // )
        {
            Token = ")";
            DoMath(Token);
        }

        private void bttndeg(object sender, RoutedEventArgs e) // /
        {
            Token = "/";
            DoMath(Token);
        }

        private void bttndel(object sender, RoutedEventArgs e) // удалить
        {
            if(tokenBox.Text.Length>0)
            tokenBox.Text=tokenBox.Text.Substring(0, tokenBox.Text.Length - 1);
        }

       
        private void bttneq(object sender, RoutedEventArgs e) // =
        {
            try
            {
                tokenBox.Text = Convert.ToString(MathExpressionParser.ParseAndEvaluate(tokenBox.Text));
            }
            catch 
            {
                tokenBox.Text = "Error";
            }
        }
    }
}