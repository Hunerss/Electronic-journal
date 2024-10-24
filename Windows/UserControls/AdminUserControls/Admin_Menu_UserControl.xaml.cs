﻿using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.UserControls.AdminUserControls
{
    /// <summary>
    /// Logika interakcji dla klasy Admin_MainMenu_UserControl.xaml
    /// </summary>
    public partial class Admin_Menu_UserControl : UserControl
    {
        MainWindow window;

        public Admin_Menu_UserControl(MainWindow window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            switch (userName)
            {
                case "personel_button":
                    window.frame.NavigationService.Navigate(new Admin_PersonelMenu_UserControl(window));
                    break;
                case "classes_button":
                    window.frame.NavigationService.Navigate(new Admin_ClassesMenu_UserControl(window));
                    break;
                case "lesson_button":
                    window.frame.NavigationService.Navigate(new Admin_LessonsMenu_UserControl(window));
                    break;
                case "logout_button":
                    window.frame.NavigationService.GoBack();
                    break;
                default:
                    Console.WriteLine("RoleSelction_UserControl - Button Error");
                    break;
            }
        }
    }
}
