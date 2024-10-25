using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Electronic_journal.UserControls.TeacherUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Teacher_Lessons_UserControl.xaml
    /// </summary>
    public partial class Teacher_Lessons_UserControl : UserControl
    {
        private MainWindow window;
        private Teacher teacher;

        string[,] swietaPanstwowe = new string[,]
{
    { "01.01", "Nowy Rok" },
    { "06.01", "Święto Trzech Króli (Epifania)" },
    { "01.05", "Święto Pracy" },
    { "03.05", "Święto Narodowe Trzeciego Maja" },
    { "15.08", "Wniebowzięcie Najświętszej Maryi Panny (Święto Matki Bożej Zielnej)" },
    { "15.08", "Święto Wojska Polskiego" },
    { "01.11", "Dzień Wszystkich Świętych" },
    { "11.11", "Narodowe Święto Niepodległości" },
    { "25.12", "Boże Narodzenie" },
    { "26.12", "Drugi Dzień Świąt Bożego Narodzenia" }
};


        public Teacher_Lessons_UserControl(MainWindow window, Teacher teacher)
        {
            InitializeComponent();
            this.window = window;
            this.teacher = teacher;
            SetupClassMenuItems();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                personel_DataGrid.ItemsSource = DatabaseOperator.GetTeachers();
                SetupDataGridColumns();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading teachers: {ex.Message}");
            }
        }

        private void SetupDataGridColumns()
        {
            personel_DataGrid.Columns.Clear();

            personel_DataGrid.Columns.Add(CreateTextColumn("Id", "Id"));
            personel_DataGrid.Columns.Add(CreateTextColumn("Name", "Name"));
            personel_DataGrid.Columns.Add(CreateTextColumn("Surname", "Surname"));
            personel_DataGrid.Columns.Add(CreateTextColumn("Subject", "Subject"));
            personel_DataGrid.Columns.Add(CreateTextColumn("Classname", "Classname"));
            personel_DataGrid.Columns.Add(CreateTextColumn("Classroom", "Classroom"));
        }

        private DataGridTextColumn CreateTextColumn(string header, string bindingPath)
        {
            return new DataGridTextColumn
            {
                Header = header,
                Binding = new Binding(bindingPath)
            };
        }

        private void SetupClassMenuItems()
        {
            // Implementacja, aby załadować klasy, które nauczyciel może wybierać.
        }

        private void personel_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (personel_DataGrid.SelectedItem is Lesson selectedLesson)
            {
                // Przekieruj do szczegółów lekcji
                //window.frame.Navigate(new Teacher_LessonMenu_UserControl(window, teacher, selectedLesson));
            }
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.GoBack();
        }
    }
}
