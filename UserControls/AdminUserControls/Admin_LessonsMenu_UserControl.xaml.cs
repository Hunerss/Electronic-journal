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

namespace Electronic_journal.UserControls.Admin
{
    /// <summary>
    /// Logika interakcji dla klasy Admin_LessonsMenu_UserControl.xaml
    /// </summary>
    public partial class Admin_LessonsMenu_UserControl : UserControl
    {
        MainWindow window;

        public Admin_LessonsMenu_UserControl(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void Add_menuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remove_menuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Modify_menuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
