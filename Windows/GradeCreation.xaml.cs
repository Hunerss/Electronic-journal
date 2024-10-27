using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System;
using System.Windows;

namespace Electronic_journal.Windows
{
    public partial class GradeCreation : Window
    {
        public string GradeName { get; private set; }
        public int GradeWeight { get; private set; }

        private int teacher_id;
        private string classname;

        public GradeCreation(int teacher_id, string classname)
        {
            InitializeComponent();
            this.teacher_id = teacher_id;
            this.classname = classname;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            GradeName = NameTextBox.Text;

            if (int.TryParse(WeightTextBox.Text, out int weight))
            {
                GradeWeight = weight;
                List<Student> students = DatabaseOperator.GetStudents(classname);
                foreach (Student student in students)
                {
                    DatabaseOperator.AddGrade(GradeName, GradeWeight, teacher_id, classname, student.Id);
                }
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid integer for Weight.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
