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
    /// Logika interakcji dla klasy FanDetails.xaml
    /// </summary>
    public partial class FanDetails : Page
    {
        public FanDetails()
        {
            InitializeComponent();
        }

        private void TX_Complete_Click(object sender, RoutedEventArgs e)
        {
            Fancier fancier = new Fancier()
            {
                IdFancier = TX_IdFancier.Text,
                IdSection = Convert.ToInt32(TX_IdSection.Text),
                IdDovecote = Convert.ToInt32(TX_IdDovecote.Text),
                FirstName = TX_FName.Text,
                LastName = TX_LName.Text,
                Adress = TX_Adress.Text,
                City = TX_City.Text,
                Mail = TX_Mail.Text,
                Telephone_Number = TX_Tel.Text
            };
            using (var ctx = new IDoveEntities())
            {
                ctx.Fancier.Add(fancier);
                ctx.SaveChanges();
            }
        }
    }
}
