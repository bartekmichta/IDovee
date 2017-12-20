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
    /// Logika interakcji dla klasy Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() =>
            {
                var navWindow = Window.GetWindow(this) as NavigationWindow;
                if (navWindow != null) navWindow.ShowsNavigationUI = false;
            }));
            InitializeComponent();
            var ctx = new IDoveEntities();
            DataGridRegion.ItemsSource = ctx.Region.ToList();
        }

       



    }
}
