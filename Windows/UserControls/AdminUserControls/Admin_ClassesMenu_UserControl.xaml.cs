using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Electronic_journal.UserControls.AdminUserControls
{
    public partial class Admin_ClassesMenu_UserControl : UserControl
    {
        MainWindow window;

        List<Class_data> classes;

        public Admin_ClassesMenu_UserControl(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                classes = DatabaseOperator.GetClasses();
                classes_DataGrid.ItemsSource = classes;
                SetupDataGridColumns();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading students: {ex.Message}");
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
            classes_DataGrid.Columns.Clear();

            classes_DataGrid.Columns.Add(CreateTextColumn("Class", "Classname"));
            classes_DataGrid.Columns.Add(CreateTextColumn("Classroom", "Classroom"));
            classes_DataGrid.Columns.Add(CreateTextColumn("Homeroom Teacher Name", "HomeroomTeacher_name"));
            classes_DataGrid.Columns.Add(CreateTextColumn("Homeroom Teacher Surname", "HomeroomTeacher_surname"));
            classes_DataGrid.Columns.Add(CreateTextColumn("Students Count", "Students_number"));
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.GoBack();
        }
    }
}
