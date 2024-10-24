using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.UserControls.GeneralUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy General_Messages_UserControl.xaml
    /// </summary>
    public partial class General_Messages_UserControl : UserControl
    {
        MainWindow window;
        Admin admin;
        Teacher teacher;
        Student student;
        Person parent;

        public General_Messages_UserControl(MainWindow window, Admin admin)
        {
            InitializeComponent();
            this.window = window;
            this.admin = admin;
        }

        public General_Messages_UserControl(MainWindow window, Teacher teacher)
        {
            InitializeComponent();
            this.window = window;
            this.teacher = teacher;
        }

        public General_Messages_UserControl(MainWindow window, Student student)
        {
            InitializeComponent();
            this.window = window;
            this.student = student;
        }

        public General_Messages_UserControl(MainWindow window, Person parent)
        {
            InitializeComponent();
            this.window = window;
            this.parent = parent;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<Message> messages = [];
            if (admin != null)
            {
                messages.AddRange(DatabaseOperator.GetMessages(admin.Id, 0));
            }
            else if (teacher != null)
            {
                messages.AddRange(DatabaseOperator.GetMessages(teacher.Id, 1));
                messages.AddRange(DatabaseOperator.GetMessages(teacher.Classname));
            }
            else if (student != null)
            {
                messages.AddRange(DatabaseOperator.GetMessages(student.Id, 2));
                messages.AddRange(DatabaseOperator.GetMessages(student.Classname));
            }
            else if (parent != null)
            {
                messages.AddRange(DatabaseOperator.GetMessages(parent.Id, 3));
                string classname = DatabaseOperator.GetClassname(parent.Id);
                messages.AddRange(DatabaseOperator.GetMessages(classname));
            }
            messages_DataGrid.ItemsSource = messages;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MessagesDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (messages_DataGrid.SelectedItem is Message selectedMessage)
            {
                MessageDetails messageDetailWindow = new(selectedMessage);
                messageDetailWindow.ShowDialog();
            }
        }
    }
}
