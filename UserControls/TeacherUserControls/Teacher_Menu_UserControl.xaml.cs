using Electronic_journal.Classes.DataClasses;
using Electronic_journal.UserControls.AdminUserControls;
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

namespace Electronic_journal.UserControls.TeacherUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Teacher_Menu_UserControl.xaml
    /// </summary>
    public partial class Teacher_Menu_UserControl : UserControl
    {
        MainWindow window;
        Teacher teacher;

        public Teacher_Menu_UserControl(MainWindow window, Teacher teacher)
        {
            InitializeComponent();
            this.window = window;
            this.teacher = teacher;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            teacher_header.Text = "Welcome - " + teacher.Name + " " + teacher.Surname;
            if (teacher.Class_name!="") class_button.IsEnabled = true;
            else class_button.IsEnabled = false;
                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            switch (userName)
            {
                case "profile_button":
                    window.frame.NavigationService.Navigate(new Teacher_Profile_UserControl(window, teacher));
                    break;
                case "class_button":
                    //window.frame.NavigationService.Navigate(new Admin_ClassesMenu_UserControl(window));
                    break;
                case "lessons_button":
                    //window.frame.NavigationService.Navigate(new Admin_LessonsMenu_UserControl(window));
                    break;
                case "messages_button":
                    //window.frame.NavigationService.Navigate(new Admin_LessonsMenu_UserControl(window));
                    break;
                case "grades_button":
                    //window.frame.NavigationService.Navigate(new Admin_LessonsMenu_UserControl(window));
                    break;
                case "attendence_button":
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
