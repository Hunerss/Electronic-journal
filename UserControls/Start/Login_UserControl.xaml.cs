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

namespace Electronic_journal.UserControls
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
