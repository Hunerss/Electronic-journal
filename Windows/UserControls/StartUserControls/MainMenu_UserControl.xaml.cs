using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.UserControls.StartUserControls
{
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
