using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Register_UserControl.xaml
    /// </summary>
    public partial class Register_UserControl : UserControl
    {
        MainWindow window;
        public Register_UserControl(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void Navigation(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            if (userName == "return_Button")
            {

            }
            else if (userName == "register_Button")
            {

            }
            else if (userName == "read_Button")
            {

            }
        }
    }
}
