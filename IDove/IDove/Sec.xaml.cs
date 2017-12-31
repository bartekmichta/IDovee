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
using System.Windows.Threading;

namespace IDove
{
    /// <summary>
    /// Interaction logic for Section.xaml
    /// </summary>
    public partial class Sec : Page
    {
        public Sec()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() =>
            {
                var navWindow = Window.GetWindow(this) as NavigationWindow;
                if (navWindow != null) navWindow.ShowsNavigationUI = false;
            }));
            InitializeComponent();
            var ctx = new IDoveEntities();
            DataGridRegion.ItemsSource = ctx.Section.ToList();
        }


        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            PageMain pg = new PageMain();
            this.NavigationService.Navigate(pg);
        }

        private void AddSection_Click(object sender, RoutedEventArgs e)
        {
            SecDetails sec = new SecDetails();
            FR_Section.Navigate(sec);
            
        }

        private void ModifySection_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteSection_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
