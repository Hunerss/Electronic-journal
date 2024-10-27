using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.Windows.UserControls.TeacherUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Teacher_Grades_UserControl.xaml
    /// </summary>
    public partial class Teacher_Grades_UserControl : UserControl
    {
        MainWindow window;
        Teacher teacher;

        string classname;

        List<Grade> grades;

        public Teacher_Grades_UserControl(MainWindow window, Teacher teacher)
        {
            InitializeComponent();
            this.window = window;
            this.teacher = teacher;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetupClassMenuItems();
            gradesDataGrid.ItemsSource = grades;
        }

        private MenuItem CreateMenuItem(string header)
        {
            MenuItem item = new()
            {
                Name = "item_" + header.ToLowerInvariant() + "_menuItem",
                Header = header
            };
            item.Click += MenuItem_Click;
            return item;
        }

        private void SetupClassMenuItems()
        {
            List<string> classes = DatabaseOperator.GetClassesHeaders(teacher.Id);

            classes_MenuItem.Items.Clear();

            foreach (string header in classes)
            {
                if (!string.IsNullOrEmpty(header))
                {
                    classes_MenuItem.Items.Add(CreateMenuItem(header));
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            classname = ((MenuItem)sender).Header.ToString();
            grades_header.Text = "- " + classname;
            grades = DatabaseOperator.GetGrades(classname, teacher.Id);
            gradesDataGrid.ItemsSource = grades;
            Console.WriteLine("Class " + classname);
        }

        private void Add_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new GradeCreation(teacher.Id, classname);
            if (dialog.ShowDialog() == true)
            {
                Console.WriteLine("Grade added");
            }
        }


        private void Save_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (Grade grade in grades)
            {
                try
                {
                    DatabaseOperator.UpdateGrade(grade);
                    Console.WriteLine("Grades updated")
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating grade {grade.Id}: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Reload_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            grades_header.Text = "- " + classname;
            grades = DatabaseOperator.GetGrades(classname, teacher.Id);
            gradesDataGrid.ItemsSource = grades;
            Console.WriteLine("Class " + classname);
        }
    }
}
