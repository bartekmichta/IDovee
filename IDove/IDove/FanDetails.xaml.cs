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
    public partial class FanDetails : Page
    {
        private readonly Fan Fanpage; //do odświeżania datagrid w page Fan

        public FanDetails(Fan page)
        {
            InitializeComponent();
            Fanpage = page;
        }
        public FanDetails()
        {
            InitializeComponent();
        }

        private void ClearTextbox()
        {
            TX_Adress.Text = String.Empty;
            TX_City.Text = String.Empty;
            TX_FName.Text = String.Empty;
            TX_IdDovecote.Text = String.Empty;
            TX_IdFancier.Text = String.Empty;
            TX_IdSection.Text = String.Empty;
            TX_LName.Text = String.Empty;
            TX_Mail.Text = String.Empty;
            TX_Tel.Text = String.Empty;
        }

        private void TX_Complete_Click(object sender, RoutedEventArgs e)
        {
            switch (Fan.targetButton)
            {
                case 1:
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
                            ClearTextbox();
                            Fanpage.DataGrid.ItemsSource = ctx.Fancier.ToList(); //odświeżanie datagrid 
                        }
                    }break;
                    case 2:
                    {
                        using (var ctx = new IDoveEntities())
                        {
                            var stList = ctx.Fancier.ToList<Fancier>();
                            Fancier fanciermodyf = stList.Where(f => f.IdFancier == (TX_IdFancier.Text)).FirstOrDefault<Fancier>();
                            fanciermodyf.FirstName = TX_FName.Text;
                            fanciermodyf.LastName = TX_LName.Text;
                            fanciermodyf.Adress = TX_Adress.Text;
                            fanciermodyf.City = TX_City.Text;
                            fanciermodyf.Mail = TX_Mail.Text;
                            fanciermodyf.Telephone_Number = TX_Tel.Text;
                            fanciermodyf.IdDovecote = Convert.ToInt32(TX_IdDovecote.Text);
                            fanciermodyf.IdSection = Convert.ToInt32(TX_IdSection.Text);
                            ctx.SaveChanges();
                            ClearTextbox();
                            TX_IdFancier.IsEnabled = true;
                            Fanpage.DataGrid.ItemsSource = ctx.Fancier.ToList();
                        }

                    }
                    break;
            }
        }
    
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            switch (Fan.targetButton)
            {
                case 1:
                    {

                    }
                    break;
                case 2:
                    {
                        TX_IdFancier.Text = Fan.fancier.IdFancier;
                        TX_IdFancier.IsEnabled = false;
                        TX_FName.Text = Fan.fancier.FirstName;
                        TX_LName.Text = Fan.fancier.LastName;
                        TX_Adress.Text = Fan.fancier.Adress;
                        TX_City.Text = Fan.fancier.City;
                        TX_Tel.Text = Fan.fancier.Telephone_Number;
                        TX_IdSection.Text = Convert.ToString(Fan.fancier.IdSection);
                        TX_IdDovecote.Text = Convert.ToString(Fan.fancier.IdDovecote);
                        TX_Mail.Text = Fan.fancier.Mail;
                        
                    }
                    break;
                case 3:
                    {
                        if (Fan.fancier != null)
                        {
                            TX_IdFancier.Text = Fan.fancier.IdFancier;
                            TX_IdFancier.IsEnabled = false;
                            TX_FName.Text = Fan.fancier.FirstName;
                            TX_FName.IsEnabled = false;
                            TX_LName.Text = Fan.fancier.LastName;
                            TX_LName.IsEnabled = false;
                            TX_Adress.Text = Fan.fancier.Adress;
                            TX_Adress.IsEnabled = false;
                            TX_City.Text = Fan.fancier.City;
                            TX_City.IsEnabled = false;
                            TX_Tel.Text = Fan.fancier.Telephone_Number;
                            TX_Tel.IsEnabled = false;
                            TX_IdSection.Text = Convert.ToString(Fan.fancier.IdSection);
                            TX_IdSection.IsEnabled = false;
                            TX_IdDovecote.Text = Convert.ToString(Fan.fancier.IdDovecote);
                            TX_IdDovecote.IsEnabled = false;
                            TX_Mail.Text = Fan.fancier.Mail;
                            TX_Mail.IsEnabled = false;
                        }
                    }
                    break;
            }
        }
    }
}

            

