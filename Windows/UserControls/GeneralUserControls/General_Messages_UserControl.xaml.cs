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
        Person user;
        Admin Admin;

        public General_Messages_UserControl(MainWindow window, Person user)
        {
            InitializeComponent();
            this.window = window;
            this.user = user;
        }

        public General_Messages_UserControl(MainWindow window, Admin admin)
        {
            InitializeComponent();
            this.window = window;
            this.Admin = admin;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<Message> messages = GetUserMessages();
            messages_DataGrid.ItemsSource = messages;
        }

        private List<Message> GetUserMessages()
        {
            List<Message> messages = new();
            int roleId = 0;

            if (Admin is Admin admin)
            {
                roleId = 0;
                messages.AddRange(DatabaseOperator.GetMessages(admin.Id, roleId));
            }
            else if (user is Teacher teacher)
            {
                roleId = 1;
                messages.AddRange(DatabaseOperator.GetMessages(teacher.Id, roleId));
                messages.AddRange(DatabaseOperator.GetMessages(teacher.Classname));
            }
            else if (user is Student student)
            {
                roleId = 2;
                messages.AddRange(DatabaseOperator.GetMessages(student.Id, roleId));
                messages.AddRange(DatabaseOperator.GetMessages(student.Classname));
            }
            else if (user is Person parent)
            {
                roleId = 3;
                messages.AddRange(DatabaseOperator.GetMessages(parent.Id, roleId));
                string classname = DatabaseOperator.GetClassnameParent(parent.Id);
                messages.AddRange(DatabaseOperator.GetMessages(classname));
            }

            return messages;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageCreation messageWindow = new(user);
            messageWindow.Show();
        }

        private void MessagesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (messages_DataGrid.SelectedItem is Message selectedMessage)
            {
                MessageDetails messageDetailWindow = new(selectedMessage);
                messageDetailWindow.ShowDialog();
            }
        }
    }
}
