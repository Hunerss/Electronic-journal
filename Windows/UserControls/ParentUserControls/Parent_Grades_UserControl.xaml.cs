using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.Windows.UserControls.ParentUserControls
{
    public partial class Parent_Grades_UserControl : UserControl
    {
        MainWindow window;
        Person parent;

        public Parent_Grades_UserControl(MainWindow window, Person parent)
        {
            InitializeComponent();
            this.window = window;
            this.parent = parent;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string classname = DatabaseOperator.GetClassnameParent(parent.Id);
            int student_id = DatabaseOperator.GetStudentParent(parent.Id);
            FillStackPanel(DatabaseOperator.GetTeachers(classname), DatabaseOperator.GetGrades(student_id));
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.GoBack();
        }

        private void FillStackPanel(List<Teacher> teachers, List<Grade> grades)
        {
            grades_StackPanel.Children.Clear();

            var groupedTeachers = teachers.GroupBy(t => new { t.Subject, t.Id, t.Name, t.Surname }).ToList();

            foreach (var teacherGroup in groupedTeachers)
            {
                var teacher = teacherGroup.First();

                TextBlock header = new()
                {
                    Text = $"{teacher.Subject}: {teacher.Name} {teacher.Surname}",
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 5, 0, 5)
                };
                grades_StackPanel.Children.Add(header);

                var teacherGrades = grades.Where(g => g.Teacher_id == teacher.Id).ToList();

                if (!teacherGrades.Any())
                {
                    TextBlock noGradesInfo = new()
                    {
                        Text = "Brak ocen",
                        Margin = new Thickness(0, 0, 0, 10)
                    };
                    grades_StackPanel.Children.Add(noGradesInfo);
                }
                else
                {
                    double totalWeightedMarks = 0;
                    int totalWeight = 0;

                    foreach (var grade in teacherGrades)
                    {
                        TextBlock gradeInfo = new()
                        {
                            Text = $"Grade: {grade.Mark}\nWeight: {grade.Weight}\nDescription: {grade.Description}\nDate: {FormatDate(grade.Creation_date)}",
                            Margin = new Thickness(0, 0, 0, 10)
                        };
                        grades_StackPanel.Children.Add(gradeInfo);

                        totalWeightedMarks += GetGradeValue(grade.Mark) * grade.Weight;
                        totalWeight += grade.Weight;
                    }

                    double weightedAverage = totalWeight > 0 ? totalWeightedMarks / totalWeight : 0;
                    TextBlock averageInfo = new()
                    {
                        Text = $"Średnia ważona: {weightedAverage:F2}",
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(0, 5, 0, 10)
                    };
                    grades_StackPanel.Children.Add(averageInfo);
                }

                TextBlock separator = new()
                {
                    Text = new string('-', 40),
                    Margin = new Thickness(0, 5, 0, 5)
                };
                grades_StackPanel.Children.Add(separator);
            }
        }

        private double GetGradeValue(string mark)
        {
            return mark switch
            {
                "6" => 6.0,
                "6-" => 5.75,
                "5+" => 5.5,
                "5" => 5.0,
                "5-" => 4.75,
                "4+" => 4.5,
                "4" => 4.0,
                "4-" => 3.75,
                "3+" => 3.50,
                "3" => 3.0,
                "3-" => 2.75,
                "2+" => 2.5,
                "2" => 2.0,
                "2-" => 1.75,
                "1+" => 1.5,
                "1" => 1.0,
                _ => 0.0
            };
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
    }
}