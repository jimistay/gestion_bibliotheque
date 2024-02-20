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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static gestion_bibliotheque.ViewModel.GenreController;

namespace gestion_bibliotheque.View.genre
{
    public partial class Modifier : Page
    {
        private int GENRE_ID;
        private GenreController genreController;

        public Modifier(int genreId, string nouveauNom)
        {
            InitializeComponent();
            GENRE_ID = genreId;
            NomGenreTextBox.Text = nouveauNom;
            genreController = new GenreController(); // Ajout de cette ligne pour créer une instance de GenreController
        }

        private void ValiderButton_Click(object sender, RoutedEventArgs e)
        {
            if (genreController.ModifierGenre(GENRE_ID, NomGenreTextBox.Text))
            {
                MessageBox.Show("Modification effectuée");
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification");
            }
        }
    }
}