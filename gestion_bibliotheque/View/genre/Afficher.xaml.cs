using gestion_bibliotheque.classes;
using gestion_bibliotheque.ViewModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace gestion_bibliotheque.View.genre
{
    /// <summary>
    /// Logique d'interaction pour Afficher.xaml
    /// </summary>
    /// 
   
    public partial class Afficher : Page
    {
        private GenreController genreController;

        public Afficher()
        {
            InitializeComponent();
            genreController = new GenreController();
            ListGenre.ItemsSource = genreController.GetGenres();
        }

        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer le genre associé au bouton cliqué
            Button button = (Button)sender;
            Genre genre = (Genre)button.DataContext;

            // Appeler la méthode de suppression dans le contrôleur
            genreController.SupprimerGenre(genre.GENRE_ID);

            // Rafraîchir la liste des genres
            ListGenre.ItemsSource = genreController.GetGenres();
        }

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            Genre selected = (Genre)ListGenre.SelectedItem;
            if (selected != null)
            {
                // Utiliser le navigateur pour afficher la page Modifier avec les informations du genre sélectionné
                NavigationService.Navigate(new Modifier(selected.GENRE_ID, selected.NOM_GENRE));
            }
        }

        private void MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {
            ModifierButton_Click(sender, e);
        }
    }
}
