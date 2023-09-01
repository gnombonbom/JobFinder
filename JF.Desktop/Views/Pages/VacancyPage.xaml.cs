using JF.Domain;
using JF.Domain.Models.Domain;
using Microsoft.Win32;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
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
    /// Interaction logic for VacancyPage.xaml
    /// </summary>
    public partial class VacancyPage : Page
    {
        private String _search = "";
        private List<String> _jobValues = Extensions.GetValuesOfJob();
        private List<String> _otrasliValues = Extensions.GetValuesOfOtrasli();
        private List<String> _graphValues = Extensions.GetValuesOfGraphs();
        private List<Vacancy> _vacancies = new();
        private List<Vacancy> _selectedVacancy = new();
        public VacancyPage(String search = "")
        {
            InitializeComponent();
            _search = search;
            searchCB.ItemsSource = _jobValues;
            otraslCB.ItemsSource = _otrasliValues;
            graphCB.ItemsSource = _graphValues;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.ChangeToCreateVacancyPage();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            searchCB.Text = _search;
            using (HttpClient client = new())
            {
                HttpResponseMessage response = await client.GetAsync($"https://localhost:7056/index/Vacancy/GetAll");
                if (response.IsSuccessStatusCode)
                {
                    _vacancies = await response.Content.ReadAsAsync<List<Vacancy>>();
                }
                _selectedVacancy = _vacancies.Where(v => v.Name.Contains(_search)).ToList();
                listBox.ItemsSource = _selectedVacancy;
            }

            if (App.CurrentUser == null)
            {
                createButton.Visibility = Visibility.Hidden;
                return;
            }
            if (App.CurrentUser.Role == UserRole.Worker)
                createButton.Visibility = Visibility.Visible;
            if (App.CurrentUser.Role != UserRole.Worker)
                createButton.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            String search = searchCB.Text;
            String salary = salaryBox.Text == "" ? "0" : salaryBox.Text;
            String town = townBox.Text;
            Otrasli otr = (Otrasli)(otraslCB.SelectedIndex + 1);
            Graphs pr = (Graphs)(graphCB.SelectedIndex + 1);

            _selectedVacancy = _vacancies.Where(v => v.Name.Contains(search) && v.Salary >= Convert.ToInt32(salary) && v.Town.Contains(town) && v.Otrasl.ToString().Contains(otr.ToString()) && v.Graph.ToString().Contains(pr.ToString())).ToList();
            listBox.ItemsSource = _selectedVacancy;
        }

        private void pdfButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new();
            sfd.Filter = "PDF - файл|*.pdf|Все файлы|*.*";
            Boolean? result = sfd.ShowDialog();
            if (result == true)
            {
                String path = sfd.FileName;
                CreatePDF(path);
                App.ShowMessage("Сохранение выполнено");
            }
        }

        private void CreatePDF(String path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            PdfDocument document = new();
            document.Info.Title = "Список вакансий";

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            //header
            gfx.DrawString("Список вакансий", new XFont("Arial", 40, XFontStyle.Bold), XBrushes.Black, new XPoint(200, 70));
            gfx.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(100, 100), new XPoint(500, 100));

            //table header
            gfx.DrawString("Вакансия", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(100, 280));
            gfx.DrawString("Зарплата", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(325, 280));
            gfx.DrawString("Адрес компании", new XFont("Arial", 15, XFontStyle.Bold), XBrushes.Black, new XPoint(400, 280));

            gfx.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(50, 290), new XPoint(550, 290));

            Int32 currentYpos_values = 303;
            Int32 currentYpos_lines = 310;

            if (_selectedVacancy.Count <= 20)
            {
                foreach (Vacancy vac in _selectedVacancy)
                {
                    gfx.DrawString(vac.Name, new XFont("Arial", 14), XBrushes.Black, new XPoint(100, currentYpos_values));
                    gfx.DrawString(vac.Salary.ToString(), new XFont("Arial", 14), XBrushes.Black, new XPoint(325, currentYpos_values));
                    gfx.DrawString(vac.Town, new XFont("Arial", 14), XBrushes.Black, new XPoint(400, currentYpos_values));

                    gfx.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(50, currentYpos_lines), new XPoint(550, currentYpos_lines));

                    currentYpos_lines += 20;
                    currentYpos_values += 20;
                }
            }
            else
            {
                for (Int32 i = 0; i < 15; i++)
                {
                    gfx.DrawString(_selectedVacancy[i].Name, new XFont("Arial", 14), XBrushes.Black, new XPoint(100, currentYpos_values));
                    gfx.DrawString(_selectedVacancy[i].Salary.ToString(), new XFont("Arial", 14), XBrushes.Black, new XPoint(325, currentYpos_values));
                    gfx.DrawString(_selectedVacancy[i].Town, new XFont("Arial", 14), XBrushes.Black, new XPoint(400, currentYpos_values));

                    gfx.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(50, currentYpos_lines), new XPoint(550, currentYpos_lines));

                    currentYpos_lines += 20;
                    currentYpos_values += 20;
                    _selectedVacancy.Remove(_selectedVacancy[i]);
                }

                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);

                currentYpos_values = 33;
                currentYpos_lines = 40;

                for (Int32 i = 0; i < _selectedVacancy.Count; i++)
                {
                    if (i != 0 && i % 30 == 0)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);

                        currentYpos_values = 33;
                        currentYpos_lines = 40;
                    }

                    gfx.DrawString(_selectedVacancy[i].Name, new XFont("Arial", 14), XBrushes.Black, new XPoint(100, currentYpos_values));
                    gfx.DrawString(_selectedVacancy[i].Salary.ToString(), new XFont("Arial", 14), XBrushes.Black, new XPoint(325, currentYpos_values));
                    gfx.DrawString(_selectedVacancy[i].Town, new XFont("Arial", 14), XBrushes.Black, new XPoint(400, currentYpos_values));

                    gfx.DrawLine(new XPen(XColor.FromArgb(50, 30, 200)), new XPoint(50, currentYpos_lines), new XPoint(550, currentYpos_lines));

                    currentYpos_lines += 20;
                    currentYpos_values += 20;

                }
            }

            document.Save(path);
        }


    }
}
