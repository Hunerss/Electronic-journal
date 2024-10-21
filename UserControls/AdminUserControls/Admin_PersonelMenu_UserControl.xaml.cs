using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Electronic_journal.UserControls.AdminUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Admin_PersonelMenu_UserControl.xaml
    /// </summary>
    public partial class Admin_PersonelMenu_UserControl : UserControl
    {
        MainWindow window;
        List<Admin> admins_list;
        List<Teacher> teachers_list;
        List<Student> students_list;
        List<Person> parents_list;

        int role = 2;
        public Admin_PersonelMenu_UserControl(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                students_list = DatabaseOperator.GetStudents();
                personel_DataGrid.ItemsSource = students_list;
                SetupDataGridColumns();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading students: {ex.Message}");
            }
        }

        private void Add_menuItem_Click(object sender, RoutedEventArgs e)
        {
            string name = ((MenuItem)sender).Name;
            switch (name)
            {
                case "add_admin_menuItem":
                    {
                        PersonelMenu menu = new(0, true);
                        menu.Show();
                        break;
                    }

                case "add_student_menuItem":
                    {
                        PersonelMenu menu = new(2, true);
                        menu.Show();
                        break;
                    }

                case "add_teacher_menuItem":
                    {
                        PersonelMenu menu = new(1, true);
                        menu.Show();
                        break;
                    }

                case "add_parent_menuItem":
                    {
                        PersonelMenu menu = new(3, true);
                        menu.Show();
                        break;
                    }

                default:
                    Console.WriteLine("Add_menuItem_Click - name error");
                    break;
            }
        }

        private void Remove_menuItem_Click(object sender, RoutedEventArgs e)
        {
            string name = ((MenuItem)sender).Name;
            switch (name)
            {
                case "remove_admin_menuItem":
                    {
                        PersonelMenu menu = new(0, false);
                        menu.Show();
                        break;
                    }

                case "remove_student_menuItem":
                    {
                        PersonelMenu menu = new(2, false);
                        menu.Show();
                        break;
                    }

                case "remove_teacher_menuItem":
                    {
                        PersonelMenu menu = new(1, false);
                        menu.Show();
                        break;
                    }

                case "remove_parent_menuItem":
                    {
                        PersonelMenu menu = new(3, false);
                        menu.Show();
                        break;
                    }

                default:
                    Console.WriteLine("Remove_menuItem_Click - name error");
                    break;
            }
        }

        private void Show_menuItem_Click(object sender, RoutedEventArgs e)
        {
            string name = ((MenuItem)sender).Name;
            UpdateDatabase();
            try
            {
                switch (name)
                {
                    case "show_admin_menuItem":
                        admins_list = DatabaseOperator.GetAdmins();
                        personel_DataGrid.ItemsSource = admins_list;
                        header_TextBlock.Text = "Personel - Admins";
                        role = 0;
                        break;

                    case "show_teacher_menuItem":
                        teachers_list = DatabaseOperator.GetTeachers();
                        personel_DataGrid.ItemsSource = teachers_list;
                        header_TextBlock.Text = "Personel - Teachers";
                        role = 1;
                        break;

                    case "show_student_menuItem":
                        students_list = DatabaseOperator.GetStudents();
                        personel_DataGrid.ItemsSource = students_list;
                        header_TextBlock.Text = "Personel - Students";
                            role = 2;
                        break;

                    case "show_parent_menuItem":
                        parents_list = DatabaseOperator.GetParents();
                        personel_DataGrid.ItemsSource = parents_list;
                        header_TextBlock.Text = "Personel - Parents";
                        role = 3;
                        break;

                    default:
                        Console.WriteLine($"Unknown MenuItem name: {name} in {nameof(Show_menuItem_Click)}");
                        break;
                }

                SetupDataGridColumns();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error showing personnel data: {ex.Message}");
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

            switch (personel_DataGrid.ItemsSource)
            {
                case List<Admin>:
                    personel_DataGrid.Columns.Add(CreateTextColumn("Email", "Email"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Password", "Password"));
                    break;
                case List<Student>:
                    personel_DataGrid.Columns.Add(CreateTextColumn("Name", "Name"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Surname", "Surname"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Birthday", "Birthday"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Age", "Age"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Classname", "Class_name"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Parent1", "Parent_1_id"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Parent2", "Parent_2_id"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Sex", "Sex"));
                    break;
                case List<Person>:
                    personel_DataGrid.Columns.Add(CreateTextColumn("Name", "Name"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Surname", "Surname"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Birthday", "Birthday"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Sex", "Sex"));
                    break;
                case List<Teacher>:
                    personel_DataGrid.Columns.Add(CreateTextColumn("Name", "Name"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Surname", "Surname"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Birthday", "Birthday"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Age", "Age"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Subject", "Subject"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Classname", "Class_name"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Classroom", "Classroom"));
                    personel_DataGrid.Columns.Add(CreateTextColumn("Sex", "Sex"));
                    break;
            }
        }

        private List<object> GetCurrentDataFromDataGrid()
        {
            switch (role)
            {
                case 0:
                    return personel_DataGrid.Items.OfType<Admin>().Cast<object>().ToList();
                case 1:
                    return personel_DataGrid.Items.OfType<Teacher>().Cast<object>().ToList();
                case 2:
                    return personel_DataGrid.Items.OfType<Student>().Cast<object>().ToList();
                case 3:
                    return personel_DataGrid.Items.OfType<Person>().Cast<object>().ToList();
                default:
                    Console.WriteLine("GetCurrentDataFromDataGrid() - role value error");
                    return [];
            }
        }

        private void UpdateDatabase()
        {
            var currentData = GetCurrentDataFromDataGrid();

            foreach (var data in currentData)
            {
                UpdatePersonInDatabase(data);
            }

            Console.WriteLine("Data updated in database");
        }

        private void UpdatePersonInDatabase(object person)
        {
            string email = "";
            string password = "";
            switch (person)
            {
                case Admin admin:
                    DatabaseOperator.UpdateAdmin(admin);
                    break;
                case Teacher teacher:
                    DatabaseOperator.UpdateTeacher(teacher);
                    email = teacher.Name + "." + teacher.Surname;
                    password = teacher.Name+ teacher.Surname + teacher.Birthday;
                    DatabaseOperator.UpdateUser(1, teacher.Id, email, password);
                    break;
                case Student student:
                    DatabaseOperator.UpdateStudent(student);
                    email = student.Name + "." + student.Surname;
                    password = student.Surname + student.Birthday;
                    DatabaseOperator.UpdateUser(2, student.Id, email, password);
                    break;
                case Person parent:
                    DatabaseOperator.UpdateParent(parent);
                    email = parent.Name + "." + parent.Surname;
                    password = parent.Name+parent.Surname+parent.Birthday;
                    DatabaseOperator.UpdateUser(3,parent.Id,email,password);
                    break;
                default:
                    Console.WriteLine("UpdatePersonInDatabase() - unknown type");
                    break;
            }
        }
        
        private void Save_menuItem_Click(object sender, RoutedEventArgs e)
        {
            UpdateDatabase();
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDatabase();
            window.frame.NavigationService.GoBack();
        }
    }
}
