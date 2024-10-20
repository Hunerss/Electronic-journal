using Electronic_journal.Classes;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal
{
    /// <summary>
    /// Logika interakcji dla klasy PersonelMenu.xaml
    /// </summary>
    public partial class PersonelMenu : Window
    {
        private int role;
        private bool add;
        public PersonelMenu(int role, bool add)
        {
            InitializeComponent();
            this.role = role;
            this.add = add;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            admin_Grid.Visibility = Visibility.Collapsed;
            add_parent_Grid.Visibility = Visibility.Collapsed;
            add_student_Grid.Visibility = Visibility.Collapsed;
            add_teacher_Grid.Visibility = Visibility.Collapsed;
            remove_Grid.Visibility = Visibility.Collapsed;
            if (role == 0)
            {
                // admin menu
                admin_Grid.Visibility = Visibility.Visible;
                if (add)
                {
                    admin_header_TextBlock.Text = "Add";
                    admin_email.ToolTip = "Write email adres of admin who you want to add to database";
                    admin_password_header.Visibility = Visibility.Visible;
                    admin_password.Visibility = Visibility.Visible;
                }
                else
                {
                    admin_header_TextBlock.Text = "Remove";
                    admin_email.ToolTip = "Write email adres of admin who you want to remove from database";
                }
            }
            else
            {
                if (role == 1)
                {
                    // teacher menu
                    if (add)
                        add_teacher_Grid.Visibility = Visibility.Visible;
                    else
                    {
                        remove_header.Text = "Teacher";
                        remove_Grid.Visibility = Visibility.Visible;
                    }
                }
                else if (role == 2)
                {
                    // student menu
                    if (add)
                        add_student_Grid.Visibility = Visibility.Visible;
                    else
                    {
                        remove_header.Text = "Student";
                        remove_Grid.Visibility = Visibility.Visible;
                    }
                }
                else if (role == 3)
                {
                    // parent menu
                    if (add)
                        add_parent_Grid.Visibility = Visibility.Visible;
                    else
                    {
                        remove_header.Text = "Parent";
                        remove_Grid.Visibility = Visibility.Visible;
                    }
                }
                else
                    Console.WriteLine("Window_Loaded - Role variable overflow");
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string name = ((Button)sender).Name;
            if (name == "admin_submit")
            {
                if (add)
                {
                    if (admin_email.Text == "" || admin_password.Password == "")
                        MessageBox.Show("Fill all boxes");
                    else
                    {
                        if (DatabaseOperator.AddUser(0, 0, admin_email.Text, admin_password.Password))
                        {
                            MessageBox.Show("Admin added successfully");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Error while adding new admin");
                        }
                    }
                }
                else
                {
                    if (admin_email.Text == "")
                        MessageBox.Show("Fill all boxes");
                    else
                    {
                        if (DatabaseOperator.RemoveUser(admin_email.Text))
                        {
                            MessageBox.Show("Admin removed successfully");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Error while removing admin");
                        }
                    }
                }
            }
            else
            {
                if (name == "teacher_submit")
                {
                    DateTime? teacher_birthdate = teacher_birthday.SelectedDate;
                    if (teacher_name.Text == "" || teacher_surname.Text == "" || teacher_subject.Text == "" || !teacher_birthdate.HasValue || teacher_age.Text == "" || teacher_sex.Text == "")
                        MessageBox.Show("Fill all boxes");
                    else
                    {
                        string birthday = teacher_birthdate.Value.ToString("yyyyMMdd");
                        int classroom = teacher_classroom.Text == "" ? 0 : Convert.ToInt32(teacher_classroom.Text);
                        if (DatabaseOperator.AddTeacher(teacher_name.Text, teacher_surname.Text, teacher_subject.Text, teacher_class.Text, classroom, Convert.ToInt32(birthday), Convert.ToInt32(teacher_age.Text), Convert.ToByte(teacher_sex.Text)))
                        {
                            string email = teacher_name.Text + "." + teacher_surname.Text + "@school.edu.pl";
                            string password = teacher_name.Text + teacher_surname.Text + birthday;
                            int id = DatabaseOperator.GetTeacherId(teacher_name.Text, teacher_surname.Text, Convert.ToInt32(birthday));
                            if (DatabaseOperator.AddUser(1, id, email, password))
                            {
                                MessageBox.Show("Teacher added successfully");
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Error while creating user for new teacher");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error while adding new teacher");
                        }
                    }
                }
                else if (name == "student_submit")
                {
                    DateTime? parent1_birthdate = parent1_birthday.SelectedDate;
                    DateTime? parent2_birthdate = parent2_birthday.SelectedDate;
                    DateTime? student_birthdate = student_birthday.SelectedDate;

                    if (parent1_name.Text == "" || parent1_surname.Text == "" || !parent1_birthdate.HasValue || parent1_sex.Text == "" ||
                       parent2_name.Text == "" || parent2_surname.Text == "" || !parent2_birthdate.HasValue || parent2_sex.Text == "" ||
                       student_name.Text == "" || student_surname.Text == "" || student_class.Text == "" || !student_birthdate.HasValue ||
                       student_age.Text == "" || student_sex.Text == "")
                    {
                        MessageBox.Show("Fill all boxes");
                    }
                    else
                    {
                        string parent1_birthday2 = parent1_birthdate.Value.ToString("yyyyMMdd");
                        string parent2_birthday2 = parent2_birthdate.Value.ToString("yyyyMMdd");
                        string student_birthday2 = student_birthdate.Value.ToString("yyyyMMdd");

                        if (DatabaseOperator.AddParent(parent1_name.Text, parent1_surname.Text, Convert.ToInt32(parent1_birthday2), Convert.ToByte(parent1_sex.Text)))
                        {
                            if (DatabaseOperator.AddParent(parent2_name.Text, parent2_surname.Text, Convert.ToInt32(parent2_birthday2), Convert.ToByte(parent2_sex.Text)))
                            {
                                int parent1_id = DatabaseOperator.GetParentId(parent1_name.Text, parent1_surname.Text, Convert.ToInt32(parent1_birthday2));
                                int parent2_id = DatabaseOperator.GetParentId(parent2_name.Text, parent2_surname.Text, Convert.ToInt32(parent2_birthday2));

                                if (DatabaseOperator.AddStudent(student_name.Text, student_surname.Text, student_class.Text, Convert.ToInt32(student_birthday2), Convert.ToInt32(student_age.Text), Convert.ToByte(student_sex.Text), parent1_id, parent2_id))
                                {
                                    string parent1_email = parent1_name.Text + "." + parent1_surname.Text + "@school.edu.pl";
                                    string parent2_email = parent2_name.Text + "." + parent2_surname.Text + "@school.edu.pl";
                                    string student_email = student_name.Text + "." + student_surname.Text + "@school.edu.pl";

                                    string parent1_password = parent1_name.Text + parent1_surname.Text + parent1_birthday2;
                                    string parent2_password = parent2_name.Text + parent2_surname.Text + parent2_birthday2;
                                    string student_password = student_name.Text + student_surname.Text + student_birthday2;

                                    int student_id = DatabaseOperator.GetStudentId(student_name.Text, student_surname.Text, Convert.ToInt32(student_birthday2));

                                    if (DatabaseOperator.AddUser(3, parent1_id, parent1_email, parent1_password))
                                    {
                                        if (DatabaseOperator.AddUser(3, parent2_id, parent2_email, parent2_password))
                                        {
                                            if (DatabaseOperator.AddUser(2, student_id, student_email, student_password))
                                            {
                                                MessageBox.Show("Student Added successfully");
                                                Close();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Error while creating user for student");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Error while creating user for parent 1");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error while creating user for parent 1");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error while adding student");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error while adding parent 2");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error while adding parent 1");
                        }
                    }
                }
                else if (name == "parent_submit")
                {
                    DateTime? parent_birthdate = parent_birthday.SelectedDate;
                    if (parent_name.Text == "" || parent_surname.Text == "" || !parent_birthdate.HasValue || parent_sex.Text == "")
                        MessageBox.Show("Fill all boxes");
                    else
                    {
                        string birthday = parent_birthdate.Value.ToString("yyyyMMdd");
                        if (DatabaseOperator.AddParent(parent_name.Text, parent_surname.Text, Convert.ToInt32(birthday), Convert.ToByte(parent_sex.Text)))
                        {
                            string email = parent_name.Text + "." + parent_surname.Text + "@school.edu.pl";
                            string password = parent_name.Text + parent_surname.Text + birthday;
                            int id = DatabaseOperator.GetParentId(parent_name.Text, parent_surname.Text, Convert.ToInt32(birthday));
                            if (DatabaseOperator.AddUser(3, id, email, password))
                            {
                                MessageBox.Show("Parent added successfully");
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Error while creating user for new parent");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error while adding new parent");
                        }
                    }
                }
                else if (name == "remove_submit")
                {
                    if (remove_name.Text == "" || remove_surname.Text == "" || remove_birthday.Text == "")
                        MessageBox.Show("Fill all boxes");
                    else
                    {
                        if(role == 1)
                        {
                            int id = DatabaseOperator.GetTeacherId(remove_name.Text, remove_surname.Text, Convert.ToInt32(remove_birthday.Text));
                            if (DatabaseOperator.RemoveTeacher(id))
                            {
                                MessageBox.Show("Teacher removed successfully");
                                Close();
                            }
                            else
                                MessageBox.Show("Error while removing teacher");
                        }
                        else if (role == 2)
                        {
                            int id = DatabaseOperator.GetStudentId(remove_name.Text, remove_surname.Text, Convert.ToInt32(remove_birthday.Text));
                            if (DatabaseOperator.RemoveStudent(id))
                            {
                                MessageBox.Show("Student removed successfully");
                                Close();
                            }
                            else
                                MessageBox.Show("Error while removing student");
                        }
                        else if (role == 3)
                        {
                            int id = DatabaseOperator.GetParentId(remove_name.Text, remove_surname.Text, Convert.ToInt32(remove_birthday.Text));
                            if (DatabaseOperator.RemoveParent(id))
                            {
                                MessageBox.Show("Parent removed successfully");
                                Close();
                            }
                            else
                                MessageBox.Show("Error while removing parent");
                        }
                        else
                            Console.WriteLine("Submit_Click - role value error");
                    }
                }
                else
                {
                    Console.WriteLine("Submit_Click - name error");
                }
            }
        }
    
    
    
    }
}
