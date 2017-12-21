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

namespace IDove
{
    /// <summary>
    /// Logika interakcji dla klasy FlgR.xaml
    /// </summary>
    public partial class FlgR : Page
    {
        public FlgR()
        {
            InitializeComponent();
            var ctx = new IDoveEntities();
            DataGrid.ItemsSource = ctx.FlightResult.ToList();
        }

        private void AddResult_Click(object sender, RoutedEventArgs e)
        {
            FlgRDetails flgR = new FlgRDetails();
            FR_Fancier.Navigate(flgR);
            DataGrid.Height = this.Height - 250;
        }

        private void ModifyResult_Click(object sender, RoutedEventArgs e)
        {
            FlgRDetails flgR = new FlgRDetails();
            FR_Fancier.Navigate(flgR);
            DataGrid.Height = this.Height - 250;
        }

        private void DeleteResult_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DataGrid.SelectedItem;
            if (selectedItem != null)
            {
                int id = (DataGrid.SelectedItem as FlightResult).IdFlightResult;
                var ctx = new IDoveEntities();
                FlightResult result = (from f in ctx.FlightResult where f.IdFlightResult == id select f).SingleOrDefault();
                ctx.FlightResult.Remove(result);
                ctx.SaveChanges();
                DataGrid.ItemsSource = ctx.FlightResult.ToList();
            }
        }
    }
}
