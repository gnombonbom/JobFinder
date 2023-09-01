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
    /// Interaction logic for ResumePage.xaml
    /// </summary>
    public partial class ResumePage : Page
    {
        public List<Resume> resume = new();
        private String _searchValue = "";

        public ResumePage(String search = "")
        {
            InitializeComponent();
            _searchValue = search;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadResume();
            if (App.CurrentUser == null)
            {
                createButton.Visibility = Visibility.Hidden;
                return;
            }
            if (App.CurrentUser.Role == UserRole.Worker)
                createButton.Visibility = Visibility.Visible;
            if (App.CurrentUser.Role == UserRole.Hirer)
                createButton.Visibility = Visibility.Hidden;
        }

        private void searchCB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchCB.Text == "")
            {
                searchCB.IsDropDownOpen = false;
                return;
            }

            searchCB.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = ((CollectionView)CollectionViewSource.GetDefaultView(searchCB.ItemsSource));
            cv.Filter = s => ((String)s).IndexOf(searchCB.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private async void LoadResume()
        {
            using (HttpClient client = new())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:7056/index/Resume/GetAllResume");
                if (response.IsSuccessStatusCode)
                {
                    resume = await response.Content.ReadAsAsync<List<Resume>>();
                }
                listBox.ItemsSource = resume;
            }
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            App.ChangeToCreateResumePage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String search = searchCB.Text;
            String salary = salaryBox.Text == "" ? "0" : salaryBox.Text;
            String town = townBox.Text;
            Otrasli otr = (Otrasli)(otraslCB.SelectedIndex + 1);
            Graphs pr = (Graphs)(graphCB.SelectedIndex + 1);

            listBox.ItemsSource = resume.Where(r => r.Name.Contains(search) && r.Salary <= Convert.ToInt32(salary)  && r.Otrasl.ToString().Contains(otr.ToString()) && r.Graph.ToString().Contains(pr.ToString()));
        }
    }
}
