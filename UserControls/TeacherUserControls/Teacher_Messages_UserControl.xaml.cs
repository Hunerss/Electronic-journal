using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Electronic_journal.UserControls.TeacherUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Teacher_Messages_UserControl.xaml
    /// </summary>
    public partial class Teacher_Messages_UserControl : UserControl
    {
        MainWindow window;
        Teacher teacher;

        public Teacher_Messages_UserControl(MainWindow window, Teacher teacher)
        {
            InitializeComponent();
            this.window = window;
            this.teacher = teacher;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            messages_DataGrid.ItemsSource = DatabaseOperator.GetMessages(teacher.Id);
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
