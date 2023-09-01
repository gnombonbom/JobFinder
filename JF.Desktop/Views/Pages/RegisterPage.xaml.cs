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
using JF.Domain.Models.Blank;
using JF.Domain.Models.Domain;


namespace JF.Desktop.Views.Pages
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        private UserRole _roles;
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckPassword();
        }

        private void CheckPassword()
        {
            if (passCheck.IsChecked == true)
            {
                ShowPassword();
                return;
            }
            HidePassword();
        }

        private void ShowPassword()
        {
            passBox.Visibility = Visibility.Hidden;
            passBoxVisible.Text = passBox.Password;
            passBoxVisible.Visibility = Visibility.Visible;
        }

        private void HidePassword()
        {
            passBoxVisible.Visibility = Visibility.Hidden;
            passBox.Password = passBoxVisible.Text;
            passBox.Visibility = Visibility.Visible;
            passBox.Focus();
        }

        private async void submitButton_Click(object sender, RoutedEventArgs e)
        {
            String password = passBox.Visibility == Visibility.Visible ? passBox.Password : passBoxVisible.Text;
            UserBlank blank = new()
            {
                Id = Guid.NewGuid(),
                FirstName = firstNameBox.Text,
                LastName = lastNameBox.Text,
                Patronymic = patroBox.Text,
                BirthDate = dateBox.SelectedDate,
                Education = (UserEducation?)(edCB.SelectedIndex + 1),
                Login = loginBox.Text,
                Password = password,
                Role = (UserRole?)(roleCB.SelectedIndex + 1),
                Phone = phoneBox.Text
            };

            Dictionary<String, String> model = new()
            {
                { "Id", $"{blank.Id}" },
                { "FirstName", $"{blank.FirstName}" },
                { "LastName", $"{blank.LastName}" },
                { "Patronymic", $"{blank.Patronymic}" },
                { "Birthdate", $"{blank.BirthDate}" },
                { "Education", $"{blank.Education}" },
                { "Login", $"{blank.Login}" },
                { "Password", $"{blank.Password}" },
                { "Phone", $"{blank.Phone}" },
                { "Role", $"{blank.Role}" },
            };
            FormUrlEncodedContent content = new(model);
            using (HttpClient client = new())
            {
                var response = await client.PostAsync("https://localhost:7056/index/user/save", content);
                if (response.IsSuccessStatusCode)
                {
                    App.ShowMessage("Регистрация произведена успешно");
                    App.ChangeToLoginPage();
                }
                else
                    App.ShowMessage("Не удалось произвести регистрацию");
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.ChangeToLoginPage();
        }
    }
}
