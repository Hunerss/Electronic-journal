using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy MessageCreation.xaml
    /// </summary>
    public partial class MessageCreation : Window
    {
        Admin admin;
        Teacher teacher;
        Student student;
        Person parent;

        public MessageCreation(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
        }

        public MessageCreation(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
        }

        public MessageCreation(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        public MessageCreation(Person parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == "return_Button")
            {
                Close();
                return;
            }

            Message message = new()
            {
                Author_id = admin?.Id ?? teacher?.Id ?? student?.Id ?? parent?.Id ?? 0,
                Single_target = single_RadioButton.IsChecked == true,
                Target_school_role = GetTargetRole()
            };

            if (message.Single_target)
            {
                bool isClassName = IsClassName(name_TextBox.Text);
                if (isClassName)
                {
                    Console.WriteLine("I");
                    List<string> classList = DatabaseOperator.GetClassesHeaders();
                    //string classname = GetClassname(DatabaseOperator.GetUserId(name_TextBox.Text, admin?.Id ?? teacher?.Id ?? student?.Id ?? parent?.Id ?? 0));
                    if (classList.Contains(name_TextBox.Text))
                        message.Group_id = name_TextBox.Text;
                    else
                        MessageBox.Show("Wrong classname");
                }
                else
                {
                    Console.WriteLine("II");
                    int userId = DatabaseOperator.GetUserId(name_TextBox.Text);
                    if (userId > 0)
                    {
                        message.Target_id = GetTargetId(name_TextBox.Text, message.Target_school_role);
                    }
                }
            }

            if (string.IsNullOrEmpty(title_TextBox.Text))
            {
                MessageBox.Show("Fill Title");
                return;
            }
            message.Title = title_TextBox.Text;

            if (string.IsNullOrEmpty(content_TextBox.Text))
            {
                MessageBox.Show("Fill Content");
                return;
            }
            message.Content = content_TextBox.Text;

            DatabaseOperator.AddMessage(message);
        }

        //private string GetClassname(int id)
        //{
        //    if(admin != null)
        //        return DatabaseOperator.GetAD
        //}

        private int GetTargetRole()
        {
            if (admin_RadioButton.IsChecked == true) return 0;
            if (teacher_RadioButton.IsChecked == true) return 1;
            if (student_RadioButton.IsChecked == true) return 2;
            if (parent_RadioButton.IsChecked == true) return 3;
            return -1;
        }

        private bool IsClassName(string input)
        {
            return input.Any(char.IsDigit);
        }

        private int GetTargetId(string name, int role)
        {
            return role switch
            {
                0 => DatabaseOperator.GetAdminId(name),
                1 => DatabaseOperator.GetUserId(name, 1),
                2 => DatabaseOperator.GetUserId(name, 2),
                3 => DatabaseOperator.GetUserId(name, 3),
                _ => 0
            };
        }

    }
}
