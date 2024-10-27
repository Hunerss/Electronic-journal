using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using Electronic_journal.Windows;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.UserControls.GeneralUserControls
{
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
            LoadMessages();
        }

        private void LoadMessages()
        {
            List<Message> messages = GetUserMessages();
            messages_DataGrid.ItemsSource = messages;
        }

        private List<Message> GetUserMessages()
        {
            List<Message> messages = [];
            int roleId = 0;
            string? className = null;

            if (admin != null)
            {
                roleId = 0;
                //Console.WriteLine(admin.Id.ToString() + roleId.ToString());
                messages.AddRange(DatabaseOperator.GetMessages(admin.Id, roleId));
            }
            else if (teacher != null)
            {
                roleId = 1;
                className = teacher.Classname;
                //Console.WriteLine(teacher.Id.ToString() + roleId.ToString());
                messages.AddRange(DatabaseOperator.GetMessages(teacher.Id, roleId));
            }
            else if (student != null)
            {
                roleId = 2;
                className = student.Classname;
                //Console.WriteLine(student.Id.ToString() + roleId.ToString());
                messages.AddRange(DatabaseOperator.GetMessages(student.Id, roleId));
            }
            else if (parent != null)
            {
                roleId = 3;
                //className = DatabaseOperator.GetClassnameParent(parent.Id);
                Console.WriteLine(parent.Id.ToString() + roleId.ToString());
                messages.AddRange(DatabaseOperator.GetMessages(parent.Id, roleId));
            }

            if (className != null)
            {
                messages.AddRange(DatabaseOperator.GetMessages(className));
            }

            return messages;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string name = ((MenuItem)sender).Name;
            if (name == "new_message_MenuITem")
            {
                MessageCreation messageWindow = admin != null ? new MessageCreation(admin) : teacher != null ? new MessageCreation(teacher) : student != null ? new MessageCreation(student) : new MessageCreation(parent);
                messageWindow.Show();
            }
            else
            {
                LoadMessages();
            }
        }

        private void MessagesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (messages_DataGrid.SelectedItem is Message selectedMessage)
            {
                MessageDetails messageDetailWindow = new(selectedMessage);
                messageDetailWindow.ShowDialog();
            }
        }

        private void Return_Button_Click(object sender, RoutedEventArgs e)
        {
            window.frame.NavigationService.GoBack();
        }
    }
}
