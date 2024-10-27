using Electronic_journal.Classes.DataClasses;
using Electronic_journal.UserControls.GeneralUserControls;
using Electronic_journal.Windows.UserControls.GeneralUserControls;
using Electronic_journal.Windows.UserControls.TeacherUserControls;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.UserControls.TeacherUserControls
{
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            switch (userName)
            {
                case "profile_button":
                    window.frame.NavigationService.Navigate(new Teacher_Profile_UserControl(window, teacher));
                    break;
                case "lessons_button":
                    window.frame.NavigationService.Navigate(new General_Lessons_UserControl(window, teacher));
                    break;
                case "messages_button":
                    window.frame.NavigationService.Navigate(new General_Messages_UserControl(window, teacher));
                    break;
                case "grades_button":
                    window.frame.NavigationService.Navigate(new Teacher_Grades_UserControl(window, teacher));
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
