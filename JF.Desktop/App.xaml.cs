using JF.Desktop.Views.Pages;
using JF.Desktop.Views.Windows;
using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace JF.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static User CurrentUser;
        public static BaseWindow Base = App.Current.MainWindow as BaseWindow;
        public static LoginWindow Login = new();

        public static void ChangeToMainPage()
        {
            Base.mainFrame.Content = new MainPage();
        }

        public static void ChangeToLoginPage()
        {
            Login.loginFrame.Content = new LoginPage();
        }

        public static void ChangeToRegisterPage()
        {
            Login.loginFrame.Content = new RegisterPage();
        }

        public static void ChangeToResumePage(String seacrch = "")
        {
            Base.mainFrame.Content = new ResumePage(seacrch);
        }

        public static void ChangeToVacancyPage(String search = "")
        {
            Base.mainFrame.Content = new VacancyPage(search);
        }

        public static void ChangeToCreateResumePage()
        {
            Base.mainFrame.Content = new CreateResumePage();
        }

        public static void ChangeToCreateVacancyPage()
        {
            Base.mainFrame.Content = new CreateVacancyPage();
        }

        public static void ChangeToLoginWindow()
        {
            Base.Visibility = Visibility.Hidden;
            Login.ShowDialog();
            Base.Visibility = Visibility.Visible;
        }

        public static void ChangeToBaseWindow()
        {
            Login.Hide();
        }

        public static void ShowMessage(String error, String title = "Информация", MessageBoxButton btn = MessageBoxButton.OK, MessageBoxImage image = MessageBoxImage.Asterisk)
        {
            MessageBox.Show(error, title, btn, image);
        }
    }
}
