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
    /// Logika interakcji dla klasy PageMain.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
            var ctx = new IDoveEntities();
            DataGridPigeon.ItemsSource = ctx.Pigeons.ToList<Pigeons>();
            DataGridView.ItemsSource = ctx.V_Pigeon.ToList();
        }

        /*
        private void AddPigeon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new IDoveEntities())
                {
                    var pigeons = new Pigeons
                    {
                        IdPigeon = IdPigeon.Text,
                        IdDovecote = IdDovecote.Text,
                        Color = Color.Text,
                        Country = Country.Text,
                        Yearbook = Yerabook.Text
                    };

                    ctx.Pigeons.Add(pigeons);
                    ctx.SaveChanges();
                    DataGridPigeon.ItemsSource = ctx.Pigeons.ToList();
                }
            }
            catch(System.FormatException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                MessageBox.Show("Nie można dodać rekordu, gdyż wartość klucza głównego IdPigeon istnieje już w bazie dancyh\n"+ex.ToString());
            }
        }

        private void ChangePigeon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new IDoveEntities())
                {
                    var stList = ctx.Pigeons.ToList<Pigeons>();
                    Pigeons pigeonModyf = stList.Where(s => s.IdPigeon == IdPigeon.Text).FirstOrDefault<Pigeons>();
                    pigeonModyf.IdPigeon = IdPigeon.Text;
                    pigeonModyf.IdDovecote = IdDovecote.Text;
                    pigeonModyf.Color = Color.Text;
                    pigeonModyf.Country = Country.Text;
                    pigeonModyf.Yearbook = Yerabook.Text;
                    ctx.SaveChanges();
                    DataGridPigeon.ItemsSource = ctx.Pigeons.ToList();
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void DeletePigeon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new IDoveEntities())
                {
                    var stList = ctx.Pigeons.ToList<Pigeons>();
                    ctx.Pigeons.Remove(stList.Where(s => s.IdPigeon == IdPigeon.Text).FirstOrDefault<Pigeons>());
                    ctx.SaveChanges();
                    DataGridPigeon.ItemsSource = ctx.Pigeons.ToList();
                }
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }*/
        private void AddPigeon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new IDoveEntities())
                {
                    ctx.InsertPigeon(IdPigeon.Text, IdDovecote.Text, PigeonNumber.Text, Color.Text, Country.Text, Yerabook.Text);
                    ctx.SaveChanges();
                    DataGridPigeon.ItemsSource = ctx.Pigeons.ToList();
                }
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            {
                MessageBox.Show("Podana wartość IdPigeon istnieje już w bazie !!","ERROR");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Niepoprawne dane gołebia", "ERROR");
            }
            
            
                
        }
        private void ChangePigeon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new IDoveEntities())
                {
                    ctx.ModifyPigeon(IdPigeon.Text, IdDovecote.Text, PigeonNumber.Text, Color.Text, Country.Text, Yerabook.Text);
                    ctx.SaveChanges();
                    DataGridPigeon.ItemsSource = ctx.Pigeons.ToList();
                }
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            {
                MessageBox.Show("Wprowadz poprawną wartość IdPigeon do edycji !!", "ERROR");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Niepoprawne dane gołebia", "ERROR");
            }
        }
        private void DeletePigeon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var ctx = new IDoveEntities())
                {
                    ctx.DeletePigeon(IdPigeon.Text);
                    ctx.SaveChanges();
                    DataGridPigeon.ItemsSource = ctx.Pigeons.ToList();
                }
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            {
                MessageBox.Show("Podaj poprawną wartość IdPigeon !!", "ERROR");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wprowadzono niepoprawne dane gółębia do usunięcia", "ERROR");
            }
        }

        private void IdPigeon_TextChanged(object sender, TextChangedEventArgs e)

        {
            
        }

    }
}
