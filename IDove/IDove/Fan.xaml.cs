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
    /// Logika interakcji dla klasy Fan.xaml
    /// </summary>
    public partial class Fan : Page
    {
        public Fan()
        {
            InitializeComponent();
            var ctx = new IDoveEntities();
            DataGridFancier.ItemsSource = ctx.Fancier.ToList();
        }

        private void AddPigeon_Click(object sender, RoutedEventArgs e)
        {
            FanDetails f = new FanDetails();
            FR_Fancier.Navigate(f);
            DataGridFancier.Height = this.Height - 250;
        }

        private void ModifyFancier_Click(object sender, RoutedEventArgs e)
        {
            FanDetails f = new FanDetails();
            FR_Fancier.Navigate(f);
            DataGridFancier.Height = this.Height - 250;
        }

        private void DeletePigeon_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DataGridFancier.SelectedItem;
            if (selectedItem != null)
            {
                int fan_id = (DataGridFancier.SelectedItem as Fancier).IdFancier;
                var ctx = new IDoveEntities();
                Fancier fan = (from f in ctx.Fancier where f.IdFancier == fan_id select f).SingleOrDefault();
                ctx.Fancier.Remove(fan);
                ctx.SaveChanges();
                DataGridFancier.ItemsSource = ctx.Fancier.ToList();
            }
        }
    }
}
