using Electronic_journal.UserControls.Start;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.UserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Register_UserControl.xaml
    /// </summary>
    public partial class Register_UserControl : UserControl
    {
        MainWindow window;

        private List<int> emptyInputs;

        int specialCode;
        public Register_UserControl(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
            emptyInputs = [];
            specialCode = 0;
        }

        private void Navigation(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            if (userName == "return_Button")
            {
                window.frame.NavigationService.GoBack();
            }
            else if (userName == "register_Button")
            {
                if (CheckInputs())
                {

                }
                else
                {
                    if (emptyInputs.Contains(0))
                    {
                        MessageBox.Show("Fill Name input");
                    }
                    if (emptyInputs.Contains(1))
                    {
                        MessageBox.Show("Fill Surname input");
                    }
                    if (emptyInputs.Contains(2))
                    {
                        MessageBox.Show("Fill Email input");
                    }
                    if (emptyInputs.Contains(3))
                    {
                        MessageBox.Show("Fill Password input");
                    }
                    if (emptyInputs.Contains(4))
                    {
                        MessageBox.Show("Fill Licence agreement");
                    }
                }
            }
            else if (userName == "read_Button")
            {
                window.frame.NavigationService.Navigate(new Licence_UserControl(window));
            }
            else
            {
                Console.WriteLine("Register_UserControl - Button Error");
            }
        }

        private bool CheckInputs()
        {
            emptyInputs.Clear();
            if (name_TextBox.Text == "")
            {
                emptyInputs.Add(0);
            }
            if (surname_TextBox.Text == "")
            {
                emptyInputs.Add(1);
            }
            if (email_TextBox.Text == "")
            {
                emptyInputs.Add(2);
            }
            if (password_PasswordBox.Password == "")
            {
                emptyInputs.Add(3);
            }
            if (licence_CheckBox.IsChecked == false)
            {
                emptyInputs.Add(4);
            }
            if(emptyInputs.Count > 0)
                return false;
            return true;
        }

        private void Role_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            specialCode = 0;
            if (role_ComboBox.SelectedIndex == 1)
            {
                specialCode = 310177;
                specialCode_TextBlock.Visibility = Visibility.Visible;
                specialCode_TextBox.Visibility = Visibility.Visible;
            }
            else if(role_ComboBox.SelectedIndex == 2)
            {
                specialCode = 171317;
                specialCode_TextBlock.Visibility = Visibility.Visible;
                specialCode_TextBox.Visibility = Visibility.Visible;
            }
        }
    }
}
