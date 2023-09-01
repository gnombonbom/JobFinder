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
using System.Windows.Shapes;

namespace JF.Desktop.Views.Windows
{
    /// <summary>
    /// Interaction logic for BaseWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        public BaseWindow()
        {
            InitializeComponent();
            App.ChangeToMainPage();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.CurrentUser is not null)
            {
                loginButton.Content = "Профиль";
                loginButton.Click -= loginButton_Click;
                loginButton.Click += profileButton_Click;
            }
            else
            {
                loginButton.Content = "Войти";
                loginButton.Click -= profileButton_Click;
                loginButton.Click += loginButton_Click;
            }
        }

        private void mainButton_Click(object sender, RoutedEventArgs e)
        {
            App.ChangeToMainPage();
        }

        private void vacancyButton_Click(object sender, RoutedEventArgs e)
        {
            App.ChangeToVacancyPage();
        }

        private void resumeButton_Click(object sender, RoutedEventArgs e)
        {
            App.ChangeToResumePage();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            App.ChangeToLoginWindow();
        }

        private void profileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
