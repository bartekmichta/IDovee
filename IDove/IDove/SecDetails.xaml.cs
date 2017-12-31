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
    /// Interaction logic for SecDetails.xaml
    /// </summary>
    public partial class SecDetails : Page
    {

        private readonly Sec Secpage;
        public SecDetails()
        {
            InitializeComponent();
        }

        private void ClearTextbox()
        {
            TX_IdBranch.Text = null;
            TX_Name.Text = null;
        }
        private void BT_AddSection_Click(object sender, RoutedEventArgs e)
        {
            Section section = new IDove.Section()
            {
                IdBranch = TX_IdBranch.Text,
                Name = TX_Name.Text

            };
            using (var ctx = new IDoveEntities())
            {
                ctx.Section.Add(section);
                ctx.SaveChanges();
                ClearTextbox();

            }
        }
    }
}
