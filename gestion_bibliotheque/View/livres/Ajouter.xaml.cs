using gestion_bibliotheque.classes;
using gestion_bibliotheque.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

namespace gestion_bibliotheque.View.livres
{
    /// <summary>
    /// Logique d'interaction pour Ajouter.xaml
    /// </summary>
    public partial class Ajouter : Page
    {
        private LivreController livreController;
        private GenreController genreController;
        private AuteurController auteurController;
        private EditionController editionController;
        public Ajouter()
        {
            InitializeComponent();

            // Initialisez les contrôleurs ici
            livreController = new LivreController();
            genreController = new GenreController();
            auteurController = new AuteurController();
            editionController = new EditionController();

            // Remplissez les ComboBox avec les données nécessaires
            AuteurComboBox.ItemsSource = auteurController.GetAuteurs();
            GenreComboBox.ItemsSource = genreController.GetGenres();
            EditionComboBox.ItemsSource = editionController.GetEditions();
        }

       
        private void AjouterLivre_Click(object sender, RoutedEventArgs e)
        {
            // Récupérez les objets sélectionnés dans les ComboBox
            Auteur auteurSelectionne = (Auteur)AuteurComboBox.SelectedItem;
            Genre genreSelectionne = (Genre)GenreComboBox.SelectedItem;
            Edition editionSelectionnee = (Edition)EditionComboBox.SelectedItem;

            // Vérifiez si les éléments sont sélectionnés
            if (auteurSelectionne == null || genreSelectionne == null || editionSelectionnee == null)
            {
                MessageBox.Show("Veuillez sélectionner un auteur, un genre et une édition.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Créez un nouvel objet Livre avec les données saisies
            Livre nouveauLivre = new Livre
            {
                TITRE = TitreTextBox.Text,
                DATE_PUBLICATION = DatePublicationTextBox.SelectedDate ?? DateTime.Now,
               // DISPONIBLE = DisponibleTextBox.IsChecked ?? false,
                COUVERTURE = CouvertureTextBox.Text,
                AUTEUR_ID = auteurSelectionne.AUTEUR_ID,
                GENRE_ID = genreSelectionne.GENRE_ID,
                EDITION_ID = editionSelectionnee.EDITION_ID
            };

            // Récupérez le chemin du fichier sélectionné
            string cheminFichierCouverture = CouvertureTextBox.Text;

            if (!string.IsNullOrEmpty(cheminFichierCouverture) && System.IO.File.Exists(cheminFichierCouverture))
            {
                // Générez un nouveau nom de fichier unique
                string nomFichierUnique = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(cheminFichierCouverture);

                // Obtenez le chemin du répertoire du projet au moment de l'exécution
                string repertoireProjet = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));

                // Créez le chemin du fichier dans le répertoire "Images" du projet
                string cheminDestination = System.IO.Path.Combine(repertoireProjet, "Images", nomFichierUnique);

                // Assurez-vous que le répertoire de destination existe
                string repertoireDestination = System.IO.Path.GetDirectoryName(cheminDestination);
                if (!System.IO.Directory.Exists(repertoireDestination))
                {
                    System.IO.Directory.CreateDirectory(repertoireDestination);
                }

                // Copiez le fichier vers le répertoire de destination
                System.IO.File.Copy(cheminFichierCouverture, cheminDestination, true);

                // Utilisez le nom du fichier comme valeur de la propriété COUVERTURE
                nouveauLivre.COUVERTURE = nomFichierUnique;
            }
            
            // Appelez la méthode dans le contrôleur pour ajouter le livre
            livreController.AjouterLivre(nouveauLivre);

            // Affichez un message pour indiquer que le livre a été ajouté
            MessageBox.Show("Livre ajouté avec succès!");

            // Effacez les champs après l'ajout
            EffacerChamps();
            
        }
        
        private void EffacerChamps()
        {
            TitreTextBox.Text = "";
            DatePublicationTextBox.SelectedDate = DateTime.Now;
            //DisponibleTextBox.IsChecked = false;
            CouvertureTextBox.Text = "";
            AuteurComboBox.SelectedIndex = -1;
            GenreComboBox.SelectedIndex = -1;
            EditionComboBox.SelectedIndex = -1;
        }

        private void SelectionnerImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Fichiers images (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|Tous les fichiers (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Affichez le chemin du fichier dans le TextBox
                CouvertureTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}
