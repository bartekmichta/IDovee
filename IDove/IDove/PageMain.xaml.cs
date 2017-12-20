﻿using System;
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
            
        }

        private void Fancier_Click(object sender, RoutedEventArgs e)
        {
            Fan fan = new Fan();
            this.NavigationService.Navigate(fan);
        }
    }
}
