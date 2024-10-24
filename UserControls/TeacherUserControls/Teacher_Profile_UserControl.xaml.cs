using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
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
    /// Logika interakcji dla klasy Teacher_Profile_UserControl.xaml
    /// </summary>
    public partial class Teacher_Profile_UserControl : UserControl
    {
        MainWindow window;
        Teacher teacher;

        public Teacher_Profile_UserControl(MainWindow window, Teacher teacher)
        {
            InitializeComponent();
            this.window = window;
            this.teacher = teacher;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            name_TextBlock.Text = teacher.Name + " " + teacher.Surname;
            subject_TextBlock.Text = teacher.Subject;
            homeroom_class_TextBlock.Text = teacher.Classname.ToUpper();
            classroom_TextBlock.Text = teacher.Classroom.ToString();
            birthday_TextBlock.Text = FormatDate(teacher.Birthday);
            age_TextBlock.Text = teacher.Age.ToString();
            sex_TextBlock.Text = teacher.Sex == 0 ? "Female" : "Male";
            lessons_TextBlock.Text = DatabaseOperator.GetLessonsCount(teacher.Id).ToString();
        }

        public static string FormatDate(int dateAsInt)
        {
            string dateAsString = dateAsInt.ToString();

            int year = int.Parse(dateAsString[..4]);
            int month = int.Parse(dateAsString.Substring(4, 2));
            int day = int.Parse(dateAsString.Substring(6, 2));

            DateTime date = new(year, month, day);

            return date.ToString("dd.MM.yyyy");
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.GoBack();
        }
    }
}
