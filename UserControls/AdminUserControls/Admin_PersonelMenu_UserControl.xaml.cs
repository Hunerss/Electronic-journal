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

namespace Electronic_journal.UserControls.AdminUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Admin_PersonelMenu_UserControl.xaml
    /// </summary>
    public partial class Admin_PersonelMenu_UserControl : UserControl
    {
        MainWindow window;
        public Admin_PersonelMenu_UserControl(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<Student> students = DatabaseOperator.GetStudents();
            personel_DataGrid.ItemsSource = students;
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id")
                e.Cancel = true;
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
