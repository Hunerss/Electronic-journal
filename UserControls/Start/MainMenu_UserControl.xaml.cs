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

namespace Electronic_journal.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy MainMenu_UserControl.xaml
    /// </summary>
    public partial class MainMenu_UserControl : UserControl
    {
        MainWindow window;

        public MainMenu_UserControl(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            switch (userName)
            {
                case "login_button":
                    window.frame.NavigationService.Navigate(new Login_UserControl(window));
                    break;
                case "register_button":
                    window.frame.NavigationService.Navigate(new Register_UserControl(window));
                    break;
                case "turnoff_button":
                    Application.Current.Shutdown();
                    window.Close();
                    break;
                default:
                    Console.WriteLine("RoleSelction_UserControl - Button Error");
                    break;
            }
        }
    }
}
