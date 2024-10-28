using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.Windows.UserControls.StudentUserControls
{
    public partial class Student_Profile_UserControl : UserControl
    {
        MainWindow window;
        Student student;

        public Student_Profile_UserControl(MainWindow window, Student student)
        {
            InitializeComponent();
            this.window = window;
            this.student = student;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            name_TextBlock.Text = student.Name + " " + student.Surname;
            class_TextBlock.Text = student.Classname.ToUpper();
            birthday_TextBlock.Text = FormatDate(student.Birthday);
            age_TextBlock.Text = student.Age.ToString();
            sex_TextBlock.Text = student.Sex == 0 ? "Female" : "Male";
            parent1_TextBlock.Text = DatabaseOperator.GetParentName(student.Parent_1_id);
            parent2_TextBlock.Text = DatabaseOperator.GetParentName(student.Parent_2_id);
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
