using Electronic_journal.Classes.DataClasses;
using Electronic_journal.UserControls.GeneralUserControls;
using Electronic_journal.Windows.UserControls.GeneralUserControls;
using Electronic_journal.Windows.UserControls.StudentUserControls;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.UserControls.StudentUserControls
{
    public partial class Student_Menu_UserControl : UserControl
    {
        MainWindow window;
        Student student;

        public Student_Menu_UserControl(MainWindow window, Student student)
        {
            InitializeComponent();
            this.window = window;
            this.student = student;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            student_header.Text = "Welcome - " + student.Name + " " + student.Surname;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            switch (userName)
            {
                case "profile_button":
                    window.frame.NavigationService.Navigate(new Student_Profile_UserControl(window, student));
                    break;
                case "lessons_button":
                    window.frame.NavigationService.Navigate(new General_Lessons_UserControl(window, student));
                    break;
                case "messages_button":
                    window.frame.NavigationService.Navigate(new General_Messages_UserControl(window, student));
                    break;
                case "grades_button":
                    window.frame.NavigationService.Navigate(new Student_Grades_UserControl(window, student));
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
