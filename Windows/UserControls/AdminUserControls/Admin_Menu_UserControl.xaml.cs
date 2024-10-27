using Electronic_journal.Classes.DataClasses;
using Electronic_journal.UserControls.GeneralUserControls;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.UserControls.AdminUserControls
{
    public partial class Admin_Menu_UserControl : UserControl
    {
        MainWindow window;
        Admin admin;

        public Admin_Menu_UserControl(MainWindow window, Admin admin)
        {
            InitializeComponent();
            this.window = window;
            this.admin = admin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            switch (userName)
            {
                case "messages_button":
                    window.frame.NavigationService.Navigate(new General_Messages_UserControl(window, admin));
                    break;
                case "personel_button":
                    window.frame.NavigationService.Navigate(new Admin_PersonelMenu_UserControl(window));
                    break;
                case "classes_button":
                    window.frame.NavigationService.Navigate(new Admin_ClassesMenu_UserControl(window));
                    break;
                case "lesson_button":
                    window.frame.NavigationService.Navigate(new Admin_LessonsMenu_UserControl(window));
                    break;
                case "logout_button":
                    window.frame.NavigationService.GoBack();
                    break;
                default:
                    Console.WriteLine("RoleSelction_UserControl - Button Error");
                    break;
            }
        }
    }
}
