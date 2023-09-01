using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JF.Desktop.Views.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            App.ChangeToRegisterPage();
        }

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            String login = loginBox.Text;
            String password = passwordBox.Password;

            using (HttpClient client = new())
            {
                var response = await client.GetAsync($"https://localhost:7056/index/user/getbyloginandpass?login={login}&password={password}");
                if (response.IsSuccessStatusCode)
                {
                    App.CurrentUser = await response.Content.ReadAsAsync<User>();
                    App.ChangeToBaseWindow();
                }
            }
        }
    }
}
