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
    /// Logika interakcji dla klasy PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() =>
            {
                var navWindow = Window.GetWindow(this) as NavigationWindow;
                if (navWindow != null) navWindow.ShowsNavigationUI = false;
            }));
        }

        private void BT_Region_Click(object sender, RoutedEventArgs e)
        {
            Reg region = new Reg();
            this.NavigationService.Navigate(region);
        }

        private void BT_Pigeons_Click(object sender, RoutedEventArgs e)
        {
            Pig pigeon = new Pig();
            this.NavigationService.Navigate(pigeon);
        }

        private void Fancier_Click(object sender, RoutedEventArgs e)
        {
            Fan fan = new Fan();
            this.NavigationService.Navigate(fan);
        }

        private void FlightResult_Click(object sender, RoutedEventArgs e)
        {
            FlgR flg = new FlgR();
            this.NavigationService.Navigate(flg);
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            PageMain pg = new PageMain();
            this.NavigationService.Navigate(pg);
        }

        private void Section_Click(object sender, RoutedEventArgs e)
        {
            Sec sec = new IDove.Sec();
            this.NavigationService.Navigate(sec);
        }
    }
}
