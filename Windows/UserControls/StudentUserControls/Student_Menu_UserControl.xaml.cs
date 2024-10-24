using Electronic_journal.Classes.DataClasses;
using Electronic_journal.UserControls.TeacherUserControls;
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

namespace Electronic_journal.UserControls.StudentUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Student_Menu_UserControl.xaml
    /// </summary>
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
                    //window.frame.NavigationService.Navigate(new Teacjer_Profile_UserControl(window, student));
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
