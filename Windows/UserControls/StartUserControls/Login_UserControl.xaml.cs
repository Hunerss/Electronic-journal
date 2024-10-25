using Electronic_journal.Classes;
using Electronic_journal.Classes.DataClasses;
using Electronic_journal.UserControls.AdminUserControls;
using Electronic_journal.UserControls.StudentUserControls;
using Electronic_journal.UserControls.TeacherUserControls;
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
using static System.Net.Mime.MediaTypeNames;

namespace Electronic_journal.UserControls.StartUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Login_UserControl.xaml
    /// </summary>
    public partial class Login_UserControl : UserControl
    {
        MainWindow window;

        private List<int> emptyInputs;
        public Login_UserControl(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            emptyInputs = [];
        }

        private void Navigation(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            if (userName == "return_Button")
            {
                window.frame.NavigationService.GoBack();
            }
            else if (userName == "login_Button")
            {
                if (CheckInputs())
                {
                    DatabaseOperator databaseOperator = new();
                    string login = login_TextBox.Text, password = password_TextBox.Password;
                    if (DatabaseOperator.Login(login, password))
                    {
                        MessageBox.Show("Correct login or password");
                        int id = DatabaseOperator.GetRole(login, password);
                        if (id == 0)
                        {
                            Admin admin = new()
                            {
                                Id = DatabaseOperator.GetAdminId(login),
                                Email = login,
                                Password = DatabaseOperator.HashPassword(password)
                            };
                            window.frame.NavigationService.Navigate(new Admin_Menu_UserControl(window, admin));
                        }
                        else if (id == 1)
                        {
                            Teacher teacher = DatabaseOperator.GetTeacher(login, password);
                            window.frame.NavigationService.Navigate(new Teacher_Menu_UserControl(window, teacher));
                        }
                        else
                        {
                            Student student = DatabaseOperator.GetStudent(login, password);
                            window.frame.NavigationService.Navigate(new Student_Menu_UserControl(window, student));
                        }


                    }
                    else
                    {
                        MessageBox.Show("Wrong login or password");
                        Console.WriteLine("Login_UserContorl - log in - error log");
                    }
                }
                else
                {
                    if (emptyInputs.Contains(0))
                    {
                        MessageBox.Show("Fill Login input");
                    }
                    if (emptyInputs.Contains(1))
                    {
                        MessageBox.Show("Fill Password input");
                    }
                }
            }
            else
            {
                Console.WriteLine("Login_UserControl - Button Error");
            }
        }

        private bool CheckInputs()
        {
            emptyInputs.Clear();
            if (login_TextBox.Text == "")
            {
                emptyInputs.Add(0);
            }
            if (password_TextBox.Password == "")
            {
                emptyInputs.Add(1);
            }
            if (emptyInputs.Count > 0)
                return false;
            return true;
        }

    }
}
