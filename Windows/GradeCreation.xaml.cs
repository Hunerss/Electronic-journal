using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Windows;

namespace Electronic_journal.Windows
{
    public partial class GradeCreation : Window
    {
        public string GradeName { get; private set; }
        public string GradeDescription { get; private set; }
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
            GradeName = name_TextBox.Text.Trim();
            GradeDescription = description_TextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(GradeName))
            {
                MessageBox.Show("Fill name field");
                return;
            }

            if (string.IsNullOrWhiteSpace(GradeDescription))
            {
                MessageBox.Show("Fill description field");
                return;
            }

            if (!int.TryParse(weight_TextBox.Text, out int weight))
            {
                MessageBox.Show("Please enter a valid integer for Weight.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            GradeWeight = weight;

            List<Student> students = DatabaseOperator.GetStudents(classname);
            try
            {
                foreach (Student student in students)
                {
                    DatabaseOperator.AddGrade(GradeName, GradeDescription, GradeWeight, teacher_id, classname, student.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding grades: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            DialogResult = true;
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
