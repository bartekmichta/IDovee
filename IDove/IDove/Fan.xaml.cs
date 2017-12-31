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
    public partial class Fan : Page
    {
        public static Fancier fancier; //obiekt przekazywany do FanDetails
        public static int targetButton=0; // numer z którego korzysta FanDetails odnośnie zdarzenia 

        public Fan()
        {
            InitializeComponent();
            var ctx = new IDoveEntities();
            DataGrid.ItemsSource = ctx.Fancier.ToList();
        }
        
        private void AddFancier_Click(object sender, RoutedEventArgs e)
        {
            targetButton = 1;
            FanDetails f = new FanDetails(this);
            FR_Fancier.Navigate(f);
        }

        private void ModifyFancier_Click(object sender, RoutedEventArgs e)
        {
            targetButton = 2;
            var selectedItem = DataGrid.SelectedItem;
            if (selectedItem != null)
            {
                string IdFancier = (DataGrid.SelectedItem as Fancier).IdFancier;
                int IdSection = (DataGrid.SelectedItem as Fancier).IdSection;
                int IdDovecote = (DataGrid.SelectedItem as Fancier).IdDovecote;
                string FirstName = (DataGrid.SelectedItem as Fancier).FirstName;
                string LastName = (DataGrid.SelectedItem as Fancier).LastName;
                string Adress = (DataGrid.SelectedItem as Fancier).Adress;
                string City = (DataGrid.SelectedItem as Fancier).City;
                string Mail = (DataGrid.SelectedItem as Fancier).Mail;
                string Telephone_Number = (DataGrid.SelectedItem as Fancier).Telephone_Number;

                fancier = new Fancier(IdFancier, IdSection, IdDovecote, FirstName, LastName, Adress, City, Mail, Telephone_Number);
                FanDetails f = new FanDetails(this);
                FR_Fancier.Navigate(f);
            }
        }

        private void DeletePigeon_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = DataGrid.SelectedItem;
            if (selectedItem != null)
            {
                string fan_id = (DataGrid.SelectedItem as Fancier).IdFancier;
                var ctx = new IDoveEntities();
                Fancier fan = (from f in ctx.Fancier where f.IdFancier == fan_id select f).SingleOrDefault();
                ctx.Fancier.Remove(fan);
                ctx.SaveChanges();
                DataGrid.ItemsSource = ctx.Fancier.ToList();
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            targetButton = 3;
            var selectedItem = DataGrid.SelectedItem;
            if (selectedItem != null)
            {
                string IdFancier = (DataGrid.SelectedItem as Fancier).IdFancier;
                int IdSection = (DataGrid.SelectedItem as Fancier).IdSection;
                int IdDovecote = (DataGrid.SelectedItem as Fancier).IdDovecote;
                string FirstName = (DataGrid.SelectedItem as Fancier).FirstName;
                string LastName = (DataGrid.SelectedItem as Fancier).LastName;
                string Adress = (DataGrid.SelectedItem as Fancier).Adress;
                string City = (DataGrid.SelectedItem as Fancier).City;
                string Mail = (DataGrid.SelectedItem as Fancier).Mail;
                string Telephone_Number = (DataGrid.SelectedItem as Fancier).Telephone_Number;

                fancier = new Fancier(IdFancier, IdSection, IdDovecote, FirstName, LastName, Adress, City, Mail, Telephone_Number);
                FanDetails f = new FanDetails();
                FR_Fancier.Navigate(f);
            }
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            PageMain pg = new PageMain();
            this.NavigationService.Navigate(pg);
        }
    }
}
