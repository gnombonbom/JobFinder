using JF.Domain;
using JF.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace JF.Desktop.Views.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<String> jobsValues = new();
        public MainPage()
        {
            InitializeComponent();
            jobsValues = Extensions.GetValuesOfJob();
            searchCB.ItemsSource = jobsValues;
        }

        private void seatchCB_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchCB.IsDropDownOpen = true;
            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);
            CollectionView cv = ((CollectionView)CollectionViewSource.GetDefaultView(searchCB.ItemsSource));
            cv.Filter = s => ((String)s).IndexOf(searchCB.Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        private void searchCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String searchValue = (String)searchCB.SelectedValue;
            App.ChangeToVacancyPage(searchValue);
        }
    }
}
