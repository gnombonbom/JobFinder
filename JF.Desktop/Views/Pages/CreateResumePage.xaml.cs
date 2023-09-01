using JF.Domain;
using JF.Domain.Models.Blank;
using Newtonsoft.Json;
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
    /// Interaction logic for CreateResumePage.xaml
    /// </summary>
    public partial class CreateResumePage : Page
    {
        private List<String> _jobValues = Extensions.GetValuesOfJob();
        private List<String> _otrasliValues = Extensions.GetValuesOfOtrasli();
        private List<String> _graphValues = Extensions.GetValuesOfGraphs();
        public CreateResumePage()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            App.ChangeToResumePage();
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

        private async void submitButton_Click(object sender, RoutedEventArgs e)
        {
            TextRange tr = new(descBox.Document.ContentStart, descBox.Document.ContentEnd);
            ResumeBlank blank = new()
            {
                Id = Guid.NewGuid(),
                UserId = App.CurrentUser.Id,
                Description = tr.Text,
                Email = emailBox.Text,
                Phone = phoneBox.Text,
                Status = Domain.Models.Domain.Status.Inprocess,
                Salary = Convert.ToInt32(salaryBox.Text),
                Graph = (Domain.Models.Domain.Graphs)(grCB.SelectedIndex + 1),
                Otrasl = (Domain.Models.Domain.Otrasli)(otrCB.SelectedIndex + 1),
                Name = nameBox.Text
            };
            Dictionary<String, String> model = new()
            {
                { "Id", $"{blank.Id}"},
                { "UserId", $"{blank.UserId}"},
                { "Description", $"{blank.Description}"},
                { "Email", $"{blank.Email}"},
                { "Phone", $"{blank.Phone}"},
                { "Status", $"{blank.Status}"},
                { "Salary", $"{blank.Salary}"},
                { "Graph", $"{blank.Graph}"},
                { "Otrasl", $"{blank.Otrasl}"},
                { "Name", $"{blank.Name}"},
            };
            FormUrlEncodedContent content = new(model);
            using (HttpClient client = new())
            {
                var response = await client.PostAsync("https://localhost:7056/index/resume/SaveResume", content);
                App.ShowMessage("Резюме создано");
                App.ChangeToResumePage();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            grCB.ItemsSource = _graphValues;
            otrCB.ItemsSource = _otrasliValues;
            nameBox.ItemsSource = _jobValues;
        }
    }
}
