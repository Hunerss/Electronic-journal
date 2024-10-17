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
    /// Logika interakcji dla klasy Admin_MainMenu_UserControl.xaml
    /// </summary>
    public partial class Admin_MainMenu_UserControl : UserControl
    {
        MainWindow window;

        public Admin_MainMenu_UserControl(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            switch (userName)
            {
                case "classes_button":
                    window.frame.NavigationService.Navigate(new Admin_ClassesMenu_UserControl(window));
                    break;
                case "teachers_button":
                    window.frame.NavigationService.Navigate(new Admin_TeachersMenu_UserControl(window));
                    break;
                case "students_button":
                    window.frame.NavigationService.Navigate(new Admin_StudentsMenu_UserControl(window));
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
