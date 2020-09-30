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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MovieNet.UI.Views.Movies
{
    /// <summary>
    /// Logique d'interaction pour MovieDetail.xaml
    /// </summary>
    public partial class MovieDetail : Page
    {
        public MovieDetail()
        {
            InitializeComponent();
        }

        private void OnSelected(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = e.Source as ListBoxItem;

            if (lbi != null)
            {
                Console.WriteLine(lbi.Content.ToString() + " is selected.");
            }
        }
    }
}
