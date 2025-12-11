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
        public char MathChar { get; set; } // то шо выбирают в символах

        public MainWindow()
        {
            InitializeComponent();
        }
        
        // кнопки с цифрами
        private void bttn7(object sender, RoutedEventArgs e)
        {
            Token = '7';
        }

        private void bttn8(object sender, RoutedEventArgs e)
        {

        }

        private void bttn9(object sender, RoutedEventArgs e)
        {

        }

        private void bttn4(object sender, RoutedEventArgs e)
        {

        }

        private void bttn5(object sender, RoutedEventArgs e)
        {

        }

        private void bttn6(object sender, RoutedEventArgs e)
        {

        }

        private void bttn1(object sender, RoutedEventArgs e)
        {

        }

        private void bttn2(object sender, RoutedEventArgs e)
        {

        }

        private void bttn3(object sender, RoutedEventArgs e)
        {

        }

        private void bttn0(object sender, RoutedEventArgs e)
        {

        }

        // кнопки с действиями
        private void bttneq(object sender, RoutedEventArgs e) // =
        {
            MathChar = '=';
        }

        private void bttnpl(object sender, RoutedEventArgs e) // +
        {

        }

        private void bttnmn(object sender, RoutedEventArgs e) // -
        {

        }

        private void bttnmul(object sender, RoutedEventArgs e) // *
        {

        }

        private void bttnbktr(object sender, RoutedEventArgs e) // (
        {

        }

        private void bttnbktl(object sender, RoutedEventArgs e) // )
        {

        }

        private void bttndeg(object sender, RoutedEventArgs e) // /
        {

        }

        private void bttndel(object sender, RoutedEventArgs e) // удалить
        {

        }
    }
}