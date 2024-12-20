﻿using Electronic_journal.Classes.DataClasses;
using Electronic_journal.UserControls.GeneralUserControls;
using Electronic_journal.Windows.UserControls.GeneralUserControls;
using Electronic_journal.Windows.UserControls.ParentUserControls;
using System.Windows;
using System.Windows.Controls;

namespace Electronic_journal.UserControls.ParentUserControls
{
    public partial class Parent_Menu_UserControl : UserControl
    {
        MainWindow window;
        Person parent;

        public Parent_Menu_UserControl(MainWindow window, Person parent)
        {
            InitializeComponent();
            this.window = window;
            this.parent = parent;
            Console.WriteLine(parent.Id);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            parent_header.Text = "Welcome - " + parent.Name + " " + parent.Surname;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string userName = ((Button)sender).Name.ToString();
            switch (userName)
            {
                case "lessons_button":
                    window.frame.NavigationService.Navigate(new General_Lessons_UserControl(window, parent));
                    break;
                case "messages_button":
                    window.frame.NavigationService.Navigate(new General_Messages_UserControl(window, parent));
                    break;
                case "grades_button":
                    window.frame.NavigationService.Navigate(new Parent_Grades_UserControl(window, parent));
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
