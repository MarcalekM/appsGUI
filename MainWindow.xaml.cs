using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace appsGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Alkalmazas> apps = Alkalmazas.LoadFromCsv("apps.csv");
        string name;
        public MainWindow()
        {
            InitializeComponent();
            foreach (var app in apps.DistinctBy(a => a.category.CategoryId)) Kategoriak.Items.Add(app.category.CategoryName);
            Kategoriak.SelectedIndex = 0;

            name = Kategoriak.SelectedItem.ToString();
        }

        private void Kategoriak_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var nevek = apps.Where(a => a.category.CategoryName.Equals(Kategoriak.SelectedItem.ToString()));
            AlkalmazasNevek.Items.Clear();
            foreach (var app in nevek) AlkalmazasNevek.Items.Add(app.ToString());
            AlkalmazasNevek.SelectedIndex = 0;
        }

        private void AlkalmazasNevek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var app = apps.Find(a => a.ToString().Equals(AlkalmazasNevek.SelectedItem.ToString()));
            Verzio.Content = app.currentVer;
            Besorolas.Content = app.contentRating.ContentRatingName;
            Megtekintes.Content = app.reviews;
            if(Kategoriak.SelectedItem.ToString().Equals(name)) Ajanlat.IsEnabled = true;
            else Ajanlat.IsEnabled = false;
            name = Kategoriak.SelectedItem.ToString();
        }

        private void Ajanlat_Click(object sender, RoutedEventArgs e)
        {
            AlkalmazasNevek.SelectedIndex = Random.Shared.Next(0, AlkalmazasNevek.Items.Count);
            Ajanlat.IsEnabled = false;
        }
    }
}