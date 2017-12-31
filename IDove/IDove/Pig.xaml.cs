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
    /// Logika interakcji dla klasy Pig.xaml
    /// </summary>
    public partial class Pig : Page
    {
        public Pig()
        {
            InitializeComponent();
            var ctx = new IDoveEntities();
            DataGrid.ItemsSource = ctx.Pigeon.ToList();
        }

        private void AddPigeon_Click(object sender, RoutedEventArgs e)
        {
            Pig p = new Pig();
            FR_Fancier.Navigate(p);
            DataGrid.Height = this.Height - 250;
        }

        private void ModifyPigeon_Click(object sender, RoutedEventArgs e)
        {
            Pig p = new Pig();
            FR_Fancier.Navigate(p);
            DataGrid.Height = this.Height - 250;
        }

        private void DeletePigeon_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DataGrid.SelectedItem;
            if (selectedItem != null)
            {
                string pig_id = (DataGrid.SelectedItem as Pigeon).IdPigeon;
                var ctx = new IDoveEntities();
                Pigeon pig = (from p in ctx.Pigeon where p.IdPigeon == pig_id select p).SingleOrDefault();
                ctx.Pigeon.Remove(pig);
                ctx.SaveChanges();
                DataGrid.ItemsSource = ctx.Pigeon.ToList();
            }
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            PageMain pg = new PageMain();
            this.NavigationService.Navigate(pg);
        }
    }
}
