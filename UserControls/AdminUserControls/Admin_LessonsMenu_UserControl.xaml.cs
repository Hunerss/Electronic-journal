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
        private MainWindow window;

        private List<Lesson> lessons;

        private List<List<Lesson>> lessons_list;

        private List<string> Subjects = new()
        {
            "Język polski", "Matematyka", "Język angielski", "Historia", "Wiedza o społeczeństwie (WOS)",
            "Geografia", "Biologia", "Chemia", "Fizyka", "Informatyka", "Wychowanie fizyczne (WF)",
            "Edukacja dla bezpieczeństwa (EDB)", "Religia", "Etyka", "Język rosyjski", "Podstawy przedsiębiorczości"
        };

        private string Class_name;

        bool check = true;

        public Admin_LessonsMenu_UserControl(MainWindow window)
        {
            InitializeComponent();
            InitializeGrid();
            this.window = window;
            //Subjects = DatabaseOperator.GetSubjects();
            lessons_list = [];
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
            try
            {
                SetupClassMenuItems();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading classes: {ex.Message}");
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

            if(lessons.Count == 0)
            {
                MessageBox.Show("There is nothing to save.");
            }
            else
            {
                ShowScheduleConflicts(lessons_list);
                foreach (Lesson lesson in lessons)
                {
                    lesson.Class_name = Class_name;
                    //DatabaseOperator.AddLesson(lesson);
                }
                //if (ShowScheduleConflicts(lessons_list))
                //{
                //    if (check)
                //    {

                //    }
                //    else
                //    {
                //        foreach (Lesson lesson in lessons)
                //        {
                //            lesson.Class_name = Class_name;
                //            DatabaseOperator.AddLesson(lesson);
                //        }
                //    }
                //}
            }
        }

        private void Show_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Class_name = ((MenuItem)sender).Header.ToString();
            class_header.Text = Class_name;
            lessons = DatabaseOperator.GetLessons(Class_name);
            FillGrid(lessons);
            Console.WriteLine("Class " + Class_name);
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
                        if (teacher_id == 0)
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

        private void FillGrid(List<Lesson> lessons)
        {
            if(lessons.Count == 0)
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
                        {
                            comboBox.SelectedItem = null;
                        }
                        else if (dockChild is TextBox textBox)
                        {
                            textBox.Text = string.Empty;
                        }
                    }
                }
            }
        }

        private List<(int TeacherId, int LessonDay, int LessonHour)> CheckScheduleConflicts(List<Lesson> lessons)
        {
            var conflicts = lessons
                .GroupBy(l => new { l.Teacher_id, l.Lesson_day, l.Lesson_hour })
                .Where(g => g.Count() > 1)
                .Select(g => (g.Key.Teacher_id, g.Key.Lesson_day, g.Key.Lesson_hour))
                .ToList();

            return conflicts;
        }

        private List<(int TeacherId, int LessonDay, int LessonHour)> CheckScheduleConflictsForMultipleClasses(List<List<Lesson>> allLessons)
        {
            List<Lesson> mergedLessons = [];

            foreach (var lessonList in allLessons)
            {
                mergedLessons.AddRange(lessonList);
            }

            return CheckScheduleConflicts(mergedLessons);
        }

        private bool ShowScheduleConflicts(List<List<Lesson>> allLessons)
        {
            var conflicts = CheckScheduleConflictsForMultipleClasses(allLessons);

            if (conflicts.Count == 0)
            {
                MessageBox.Show("Lessons don't colide.");
                return true;
            }

            string message = "";
            int counter = 1;
            foreach (var conflict in conflicts)
            {
                message += $"{counter}. Teacher id: {conflict.TeacherId}, Lesson hour: {conflict.LessonHour}, Day: {conflict.LessonDay}\n";
                counter++;
            }

            MessageBox.Show(message, "Conflicts Detected", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }
    }
}
