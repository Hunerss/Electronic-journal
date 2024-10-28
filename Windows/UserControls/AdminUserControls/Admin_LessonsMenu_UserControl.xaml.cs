using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Electronic_journal.UserControls.AdminUserControls
{
    public partial class Admin_LessonsMenu_UserControl : UserControl
    {
        private MainWindow window;

        private List<Lesson> lessons;

        private List<List<Lesson>> lessons_list;

        private List<string> Subjects = [];

        private string classname;

        bool check = true;

        public Admin_LessonsMenu_UserControl(MainWindow window)
        {
            InitializeComponent();
            Subjects = DatabaseOperator.GetSubjects();
            InitializeGrid();
            this.window = window;
            lessons_list = [];
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                personel_DataGrid.ItemsSource = DatabaseOperator.GetTeachers();
                SetupDataGridColumns();
                SetupClassMenuItems();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while loading: {ex.Message}");
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
            personel_DataGrid.Columns.Add(CreateTextColumn("Classname", "Classname"));
            personel_DataGrid.Columns.Add(CreateTextColumn("Classroom", "Classroom"));
        }

        private MenuItem CreateMenuItem(string header)
        {
            MenuItem item = new()
            {
                Name = "item_" + header.ToLowerInvariant() + "_menuItem",
                Header = header
            };
            item.Click += Show_MenuItem_Click;
            return item;
        }

        private void SetupClassMenuItems()
        {
            List<string> classes = DatabaseOperator.GetClassesHeaders();

            choose_class_menuItem.Items.Clear();

            foreach (string header in classes)
            {
                if (!string.IsNullOrEmpty(header))
                {
                    lessons_list.Add(DatabaseOperator.GetLessons(header));
                    choose_class_menuItem.Items.Add(CreateMenuItem(header));
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            List<Lesson> lessons = GetLessons();

            if (lessons.Count == 0)
            {
                MessageBox.Show("There is nothing to save.");
            }
            else
            {

                Dictionary<int, List<int>> conflicts = ShowScheduleConflicts(lessons);

                if (conflicts.Count == 0)
                {
                    Console.WriteLine("Zero conflicts");
                    DatabaseOperator.RemoveLessonsByClass(classname);

                    try
                    {
                        foreach (Lesson lesson in lessons)
                        {
                            lesson.Classname = classname;
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine(lesson.Id);
                            Console.WriteLine(lesson.Name);
                            Console.WriteLine(lesson.Classname);
                            Console.WriteLine(lesson.Classroom);
                            Console.WriteLine(lesson.Teacher_id);
                            Console.WriteLine(lesson.Lesson_hour);
                            Console.WriteLine(lesson.Lesson_day);

                            DatabaseOperator.AddLesson(lesson);
                        }

                        MessageBox.Show("Schedule saved successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving the schedule: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("More then one conflict");
                    string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
                    StringBuilder message = new("Detected conflicts:");

                    foreach (KeyValuePair<int, List<int>> conflict in conflicts)
                    {
                        int day = conflict.Key;
                        List<int> hours = conflict.Value;

                        if (day >= 1 && day <= 5)
                        {
                            string dayName = days[day - 1];

                            foreach (int hour in hours)
                            {
                                message.AppendLine($"Day: {dayName}, Lesson: {hour}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Week day value overflow");
                        }
                    }

                    MessageBox.Show(message.ToString(), "Schedule Conflicts", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Show_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            classname = ((MenuItem)sender).Header.ToString();
            class_header.Text = classname;
            lessons = DatabaseOperator.GetLessons(classname);
            ClearGrid();
            FillGrid(lessons);
            Console.WriteLine("Class " + classname);
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
                        Width = 100,
                        Height = 40,
                        Margin = new Thickness(0, 10, 0, 5),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };


                    TextBox textBox = new()
                    {
                        Width = 40,
                        Height = 30,
                        Margin = new Thickness(0, 5, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center
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
                        if (teacher_id == 0)
                            classroom = 0;
                        else
                            classroom = DatabaseOperator.GetClassroom(teacher_id);

                        if (comboBox != null && textBox != null && !string.IsNullOrWhiteSpace(comboBox.SelectedItem as string) && !string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            Lesson lesson = new()
                            {
                                Name = comboBox.SelectedItem.ToString(),
                                Classname = classname,
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
            return lessons;
        }

        private void FillGrid(List<Lesson> lessons)
        {
            if (lessons.Count == 0)
            {
                MessageBox.Show("This class doesn't have lessons plan yet.");
                check = false;
                ClearGrid();
            }
            else
            {
                foreach (var lesson in lessons)
                {
                    foreach (var child in main_Grid.Children)
                    {
                        if (child is DockPanel dockPanel)
                        {
                            int row = Grid.GetRow(dockPanel);
                            int column = Grid.GetColumn(dockPanel);

                            if (row == lesson.Lesson_hour + 1 && column == lesson.Lesson_day)
                            {
                                foreach (var dockChild in dockPanel.Children)
                                {
                                    if (dockChild is ComboBox comboBox)
                                        comboBox.SelectedItem = lesson.Name;
                                    else if (dockChild is TextBox textBox)
                                        textBox.Text = lesson.Teacher_id.ToString();
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void ClearGrid()
        {
            foreach (var child in main_Grid.Children)
            {
                if (child is DockPanel dockPanel)
                {
                    foreach (var dockChild in dockPanel.Children)
                    {
                        if (dockChild is ComboBox comboBox)
                            comboBox.SelectedItem = null;
                        else if (dockChild is TextBox textBox)
                            textBox.Text = string.Empty;
                    }
                }
            }
        }

        private Dictionary<int, List<int>> ShowScheduleConflicts(List<Lesson> lessons)
        {
            Dictionary<int, List<int>> conflicts = [];

            foreach (Lesson lesson in lessons)
            {
                if (!DatabaseOperator.CheckLessons(lesson))
                {
                    if (!conflicts.TryGetValue(lesson.Lesson_day, out List<int>? hours))
                    {
                        hours = [];
                        conflicts[lesson.Lesson_day] = hours;
                    }
                    hours.Add(lesson.Lesson_hour);
                }
            }
            Console.WriteLine("conflicts " + conflicts.Count);
            return conflicts;
        }


    }
}
