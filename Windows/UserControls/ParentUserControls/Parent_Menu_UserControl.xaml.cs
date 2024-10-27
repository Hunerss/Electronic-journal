using Electronic_journal.Classes.DataClasses;
using Electronic_journal.UserControls.GeneralUserControls;
using Electronic_journal.Windows.UserControls.GeneralUserControls;
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

namespace Electronic_journal.UserControls.ParentUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Parent_Menu_UserControl.xaml
    /// </summary>
    public partial class Parent_Menu_UserControl : UserControl
    {
        MainWindow window;
        Person parent;

        public Parent_Menu_UserControl(MainWindow window, Person parent)
        {
            InitializeComponent();
            this.window = window;
            this.parent = parent;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            parent_header.Text = "Welcome - " + parent.Name + " " + parent.Surname;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            switch (userName)
            {
                case "lessons_button":
                    window.frame.NavigationService.Navigate(new General_Lessons_UserControl(window, parent));
                    break;
                case "messages_button":
                    window.frame.NavigationService.Navigate(new General_Messages_UserControl(window, parent));
                    break;
                case "grades_button":
                    //window.frame.NavigationService.Navigate(new Admin_LessonsMenu_UserControl(window));
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
