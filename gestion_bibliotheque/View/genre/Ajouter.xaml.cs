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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gestion_bibliotheque.View.genre
{
    /// <summary>
    /// Logique d'interaction pour Ajouter.xaml
    /// </summary>
    public partial class Ajouter : Page
    {
        private GenreController genreController;
        public Ajouter()
        {
            InitializeComponent();
            genreController = new GenreController();
        }

        private void AjouterGnere_Click(object sender, RoutedEventArgs e)
        {
            string nom = NomTextBox.Text;

            genreController.AjouterGenre(nom);
        }
    }
}
