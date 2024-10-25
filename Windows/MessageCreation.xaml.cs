using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

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
            Console.WriteLine("Entering message creatin as Admin");
        }

        public MessageCreation(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            Console.WriteLine("Entering message creatin as Teacher");
        }

        public MessageCreation(Student student)
        {
            InitializeComponent();
            this.student = student;
            Console.WriteLine("Entering message creatin as Student");
        }

        public MessageCreation(Person parent)
        {
            InitializeComponent();
            this.parent = parent;
            Console.WriteLine("Entering message creatin as Parent");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == "return_Button")
            {
                Close();
                return;
            }

            var message = CreateMessage();
            if (message == null) return;

            DatabaseOperator.AddMessage(message);
        }

        private Message CreateMessage()
        {
            Message message = new()
            {
                Author_id = admin?.Id ?? teacher?.Id ?? student?.Id ?? parent?.Id ?? 0,
                School_role = GetSchoolRole(),
                Single_target = single_ToggleButton.IsChecked == true,
                Target_school_role = GetTargetRole()
            };

            if (message.Single_target)
            {
                if (!ValidateTarget(message)) return null;
            }

            message.Title = title_TextBox.Text;
            message.Content = content_TextBox.Text;

            if (string.IsNullOrEmpty(message.Title) || string.IsNullOrEmpty(message.Content))
            {
                MessageBox.Show("Fill Title and Content");
                return null;
            }

            return message;
        }

        private bool ValidateTarget(Message message)
        {
            string targetInput = name_TextBox.Text.Trim();
            bool isClassName = IsClassName(targetInput);

            if (isClassName)
            {
                List<string> classList = DatabaseOperator.GetClassesHeaders();

                if (classList.Contains(targetInput))
                {
                    message.Group_id = targetInput;
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid class name.");
                    return false;
                }
            }
            else
            {
                int userId = DatabaseOperator.GetUserId(targetInput);

                if (userId > 0)
                {
                    message.Target_id = GetTargetId(targetInput, message.Target_school_role);
                    return true;
                }
                else
                {
                    MessageBox.Show("User not found with the given name or email address.");
                    return false;
                }
            }
        }

        private int GetSchoolRole()
        {
            if (admin != null) return 0;
            else if (teacher != null) return 1;
            else if (student != null) return 2; 
            else if (parent  != null) return 3;
            else return -1;
        }

        //private int GetSchoolRole()
        //{
        //    return (admin, teacher, student, parent) switch
        //    {
        //        (not null, _, _, _) => 0, // admin
        //        (_, not null, _, _) => 1, // teacher
        //        (_, _, not null, _) => 2, // student
        //        (_, _, _, not null) => 3, // parent
        //        _ => -1                   // none
        //    };
        //}

        private int GetTargetRole()
        {
            if (admin_ToggleButton.IsChecked == true) return 0;
            else if (teacher_ToggleButton.IsChecked == true) return 1;
            else if (student_ToggleButton.IsChecked == true) return 2;
            else if (parent_ToggleButton.IsChecked == true) return 3;
            else return -1;
        }

        //private int GetTargetRole()
        //{
        //    return (admin_ToggleButton.IsChecked, teacher_ToggleButton.IsChecked, student_ToggleButton.IsChecked, parent_ToggleButton.IsChecked) switch
        //    {
        //        (true, _, _, _) => 0,
        //        (_, true, _, _) => 1,
        //        (_, _, true, _) => 2,
        //        (_, _, _, true) => 3,
        //        _ => -1,
        //    };
        //}

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

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton clickedButton = sender as ToggleButton;

            if (clickedButton == single_ToggleButton)
            {
                single_ToggleButton.IsChecked = true;
                multiple_ToggleButton.IsChecked = false;
            }
            else if (clickedButton == multiple_ToggleButton)
            {
                multiple_ToggleButton.IsChecked = true;
                single_ToggleButton.IsChecked = false;
            }
        }

        private void ToggleRoleButton(ToggleButton selected)
        {
            foreach (var button in new[] { admin_ToggleButton, teacher_ToggleButton, student_ToggleButton, parent_ToggleButton })
            {
                button.IsChecked = button == selected;
            }
        }

        private void RoleToggleButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton clickedButton = sender as ToggleButton;
            ToggleRoleButton(clickedButton);
        }

        private void ValidateMessageFields(Message message)
        {
            if (string.IsNullOrEmpty(message.Title))
                MessageBox.Show("Fill Title");
            else if (string.IsNullOrEmpty(message.Content))
                MessageBox.Show("Fill Content");
        }

    }
}
