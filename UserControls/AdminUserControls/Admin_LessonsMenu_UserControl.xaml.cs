using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Electronic_journal.UserControls.AdminUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Admin_LessonsMenu_UserControl.xaml
    /// </summary>
    public partial class Admin_LessonsMenu_UserControl : UserControl
    {
        MainWindow window;

        string Class_name;

        public Admin_LessonsMenu_UserControl(MainWindow window)
        {
            InitializeComponent();
            InitializeGrid();
            this.window = window;
        }

        private readonly List<string> Subjects = new List<string>
        {
            "Język polski", "Matematyka", "Język angielski", "Historia", "Wiedza o społeczeństwie (WOS)",
            "Geografia", "Biologia", "Chemia", "Fizyka", "Informatyka", "Wychowanie fizyczne (WF)",
            "Edukacja dla bezpieczeństwa (EDB)", "Religia", "Etyka", "Język rosyjski", "Podstawy przedsiębiorczości"
        };

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

        private DataGridTextColumn CreateTextColumn(string header, string bindingPath)
        {
            return new DataGridTextColumn
            {
                Header = header,
                Binding = new Binding(bindingPath)
            };
        }

        private void SetupDataGridColumns()
        {
            personel_DataGrid.Columns.Clear();

            personel_DataGrid.Columns.Add(CreateTextColumn("Id", "Id"));
            personel_DataGrid.Columns.Add(CreateTextColumn("Name", "Name"));
            personel_DataGrid.Columns.Add(CreateTextColumn("Surname", "Surname"));
            personel_DataGrid.Columns.Add(CreateTextColumn("Subject", "Subject"));
            personel_DataGrid.Columns.Add(CreateTextColumn("Classname", "Class_name"));
            personel_DataGrid.Columns.Add(CreateTextColumn("Classroom", "Classroom"));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            List<Lesson> lessons = GetLessons();

            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("Name " + lesson.Name);
                Console.WriteLine("Class " + lesson.Class_name);
                Console.WriteLine("Classroom " + lesson.Classroom);
                Console.WriteLine("Teacher_id " + lesson.Teacher_id);
                Console.WriteLine("Lesson_hour " + lesson.Lesson_hour);
                Console.WriteLine("Lesson_day " + lesson.Lesson_day);
            }
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.GoBack();
        }

        private void InitializeGrid()
        {
            for (int row = 1; row <= 10; row++)
            {
                for (int column = 1; column <= 5; column++)
                {
                    DockPanel dockPanel = new();

                    ComboBox comboBox = new()
                    {
                        ItemsSource = Subjects,
                        Width = 70,
                        Height = 20,
                        Margin = new Thickness(0, 10, 0, 5),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };


                    TextBox textBox = new()
                    {
                        Width = 30,
                        Height = 20,
                        Margin = new Thickness(0, 5, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    dockPanel.Children.Add(comboBox);
                    dockPanel.Children.Add(textBox);

                    Grid.SetRow(dockPanel, row);
                    Grid.SetColumn(dockPanel, column);
                    main_Grid.Children.Add(dockPanel);
                }
            }
        }

        private List<Lesson> GetLessons()
        {
            List<Lesson> lessons = [];

            for (int row = 1; row <= 10; row++)
            {
                for (int column = 1; column <= 5; column++) 
                {
                    DockPanel dockPanel = (DockPanel)main_Grid.Children
                        .Cast<UIElement>()
                        .FirstOrDefault(d => Grid.GetRow(d) == row && Grid.GetColumn(d) == column);

                    if (dockPanel != null)
                    {
                        ComboBox comboBox = dockPanel.Children.OfType<ComboBox>().FirstOrDefault();
                        TextBox textBox = dockPanel.Children.OfType<TextBox>().FirstOrDefault();

                        int teacher_id = int.TryParse(textBox.Text, out int tid) ? tid : 0;
                        int classroom;
                        if(teacher_id == 0)
                            classroom = 0;
                        else
                            classroom = DatabaseOperator.GetClassroom(teacher_id);

                        if (comboBox != null && textBox != null && !string.IsNullOrWhiteSpace(comboBox.SelectedItem as string) && !string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            Lesson lesson = new()
                            {
                                Name = comboBox.SelectedItem.ToString(),
                                Class_name = Class_name,
                                Classroom = classroom,
                                Teacher_id = teacher_id,
                                Lesson_hour = row - 1,
                                Lesson_day = column
                            };

                            lessons.Add(lesson);
                        }
                    }
                }
            }

            return lessons; // Zwróć listę lekcji
        }




    }
}
