using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace montaspro.nicolo._4i.gelati
{

//
//
//
//programma fatto da Montaspro Nicolò e Bartolucci Alessandro
//
//
//
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gelati Gelati;
        Ingredienti Ingredienti;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                Gelati = new("Gelati.csv");
                dgGelati.ItemsSource = Gelati;

                statusbar.Text = $"Ho letto dal file {Gelati.Count} persone";


                Ingredienti = new("Ingredienti.csv");
                statusbar.Text = $"Ho letto dal file" +
                     $"{Gelati.Count} Gelati e " +
                     $"{Ingredienti.Count} Ingredinti";

            }

            catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message);
            }
        }
        private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {


                Gelato p = e.AddedItems[0] as Gelato;
                if (p != null)
                {
                    statusbar.Text = $" Hai selezionato {p.Nome} {p.Descrizione}";

                    Ingredienti IngredientiFiltrati = new();
                    foreach (var item in Ingredienti)
                        if (item.idGelato == p.idGelato)
                            IngredientiFiltrati.Add(item);

                    dgIngredienti.ItemsSource = IngredientiFiltrati;
                }
            }

        }   

        

        private void dgIngredienti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
