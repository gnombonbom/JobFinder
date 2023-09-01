using JF.Domain;
using JF.Domain.Models.Blank;
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
    /// Interaction logic for CreateVacancyPage.xaml
    /// </summary>
    public partial class CreateVacancyPage : Page
    {
        private List<String> _jobValues = Extensions.GetValuesOfJob();
        private List<String> _otrasliValues = Extensions.GetValuesOfOtrasli();
        private List<String> _graphValues = Extensions.GetValuesOfGraphs();
        public CreateVacancyPage()
        {
            InitializeComponent();

            nameBox.ItemsSource = _jobValues;
            otrCB.ItemsSource = _otrasliValues;
            grCB.ItemsSource = _graphValues;
        }

        private void searchCB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (nameBox.Text == "")
            {
                nameBox.IsDropDownOpen = false;
                return;
            }

            nameBox.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = ((CollectionView)CollectionViewSource.GetDefaultView(nameBox.ItemsSource));
            cv.Filter = s => ((String)s).IndexOf(nameBox.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.ChangeToVacancyPage();
        }

        private async void submitButton_Click(object sender, RoutedEventArgs e)
        {
            TextRange tr = new(descBox.Document.ContentStart, descBox.Document.ContentEnd);
            VacancyBlank blank = new()
            {
                Id = Guid.NewGuid(),
                Name = nameBox.Text,
                Description = tr.Text,
                Graph = (Graphs?)grCB.SelectedIndex + 1,
                Otrasl = (Otrasli?)otrCB.SelectedIndex + 1,
                Salary = Convert.ToInt32(salaryBox.Text),
                Town = areaBox.Text,
                UserId = App.CurrentUser.Id,
                CompanyName = companyBox.Text
            };

            Dictionary<String, String> model = new()
            {
                { "Id", $"{blank.Id}" },
                { "Name", $"{blank.Name}" },
                { "Description", $"{blank.Description}" },
                { "Graph", $"{blank.Graph}" },
                { "Otrasl", $"{blank.Otrasl}" },
                { "Salary", $"{blank.Salary}" },
                { "Town", $"{blank.Town}" },
                { "UserId", $"{blank.UserId}" },
                { "CompanyName", $"{blank.CompanyName}" },
            };
            FormUrlEncodedContent content = new(model);
            using (HttpClient client = new())
            {
                var response = await client.PostAsync("https://localhost:7056/index/vacancy/SaveVacancy", content);
                App.ShowMessage("Вакансия создана");
                App.ChangeToVacancyPage();
            }
        }
    }
}
