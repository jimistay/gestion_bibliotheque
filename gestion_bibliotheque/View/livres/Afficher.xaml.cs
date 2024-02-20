using gestion_bibliotheque.classes;
using gestion_bibliotheque.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
    /// Logique d'interaction pour Afficher.xaml
    /// </summary>
    public partial class Afficher : Page
    {
        private LivreController livreController;

        private GenreController genreController;
        private AuteurController auteurController;  // Déclarez le contrôleur d'auteur ici
        private EditionController editionController;

        private ObservableCollection<Livre> Livres;
        private CollectionViewSource collectionViewSource;

        // Pour la confirmation de suppression qui s'affiche 2 fois 
        private bool isSupprimerButtonEventHandled = false;
        private bool isSuppressionConfirmed = false;

        public Afficher()
        {
            InitializeComponent();
            
            livreController = new LivreController();
            genreController = new GenreController();
            auteurController = new AuteurController();
            editionController = new EditionController();

            ObservableCollection<Livre> livres = livreController.GetLivres();

            // Récupérez le chemin du répertoire du projet au moment de l'exécution
            string repertoireProjet = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));

            // Ajoutez une propriété CouvertureImage à chaque livre avec le chemin d'accès complet
            foreach (Livre livre in livres)
            {
                livre.CouvertureImage = System.IO.Path.Combine(repertoireProjet, "Images", livre.COUVERTURE);
            }

            // Affectez la liste à la source de la ListBox
            ListLivre.ItemsSource = livres;

            foreach (var livre in livres)
            {
                var button = new Button { Content = "Supprimer" };
                button.DataContext = livre;
                button.Click += SupprimerButton_Click;
            }
            // Remplacez ces lignes par vos propres méthodes de récupération des données
            ComboBoxGenre.ItemsSource = genreController.GetGenres().Select(g => g.NOM_GENRE);
            ComboBoxAuteur.ItemsSource = auteurController.GetAuteurs().Select(a => a.NOM_AUTEUR);
            ComboBoxEdition.ItemsSource = editionController.GetEditions().Select(e => e.NOM_EDITION);
            // Initialisation des gestionnaires d'événements pour les filtres
            CheckBoxDisponible.Checked += FiltreChanged;
            CheckBoxDisponible.Unchecked += FiltreChanged;
            DatePickerDate.SelectedDateChanged += FiltreChanged;
            TextBoxTitre.TextChanged += FiltreChanged;
            ComboBoxGenre.SelectionChanged += FiltreChanged;
            ComboBoxAuteur.SelectionChanged += FiltreChanged;
            ComboBoxEdition.SelectionChanged += FiltreChanged;

            collectionViewSource = new CollectionViewSource
            {
                Source = livres
            };

            ListLivre.ItemsSource = collectionViewSource.View;

        }
        private void FiltreChanged(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }
        // Ajoutez des méthodes pour récupérer les ID correspondants aux noms sélectionnés
        private int GetGenreId(string genreName)
        {
            // Implémentez la logique pour récupérer l'ID du genre
            // en fonction du nom (utilisez votre modèle de données ou contrôleur approprié).
            Genre genre = genreController.GetGenres().FirstOrDefault(g => g.NOM_GENRE == genreName);
            return genre != null ? genre.GENRE_ID : 0;
        }

        private int GetAuteurId(string auteurName)
        {
            // Implémentez la logique pour récupérer l'ID de l'auteur
            // en fonction du nom (utilisez votre modèle de données ou contrôleur approprié).
            Auteur auteur = auteurController.GetAuteurs().FirstOrDefault(a => a.NOM_AUTEUR == auteurName);
            return auteur != null ? auteur.AUTEUR_ID : 0;
        }

        private int GetEditionId(string editionName)
        {
            // Implémentez la logique pour récupérer l'ID de l'édition
            // en fonction du nom (utilisez votre modèle de données ou contrôleur approprié).
            Edition edition = editionController.GetEditions().FirstOrDefault(e => e.NOM_EDITION == editionName);
            return edition != null ? edition.EDITION_ID : 0;
        }
        private void ApplyFilters()
        {
            ICollectionView view = collectionViewSource.View;

            if (view != null)
            {
                view.Filter = item =>
                {
                    Livre livre = item as Livre;

                    // Filtre par disponibilité
                    bool disponibleFilter = CheckBoxDisponible.IsChecked ?? false;
                    if (disponibleFilter && !livre.DISPONIBLE)
                        return false;
                    if (!disponibleFilter && livre.DISPONIBLE)
                        return false;

                    // Filtre par date
                    DateTime? selectedDate = DatePickerDate.SelectedDate;
                    if (selectedDate.HasValue && livre.DATE_PUBLICATION.Date != selectedDate.Value.Date)
                        return false;

                    // Filtre par titre
                    string titreFilter = TextBoxTitre.Text;
                    if (!string.IsNullOrEmpty(titreFilter) && !livre.TITRE.Contains(titreFilter, StringComparison.OrdinalIgnoreCase))
                        return false;

                    // Filtre par genre
                    int selectedGenreId = GetGenreId(ComboBoxGenre.SelectedItem as string);
                    if (selectedGenreId != 0 && livre.GENRE_ID != selectedGenreId)
                        return false;

                    // Filtre par auteur
                    int selectedAuteurId = GetAuteurId(ComboBoxAuteur.SelectedItem as string);
                    if (selectedAuteurId != 0 && livre.AUTEUR_ID != selectedAuteurId)
                        return false;

                    // Filtre par édition
                    int selectedEditionId = GetEditionId(ComboBoxEdition.SelectedItem as string);
                    if (selectedEditionId != 0 && livre.EDITION_ID != selectedEditionId)
                        return false;

                    return true;
                };
            }
        }
        /*
        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (button.DataContext != null && button.DataContext is Livre)
            {
                Livre livre = (Livre)button.DataContext;

                button.IsEnabled = false;

                if (!isSuppressionConfirmed)
                {
                    if (!livreController.LivrePossedeLocation(livre.LIVRE_ID))
                    {
                        bool confirmationSuppression = livreController.ConfirmerSuppressionLivre();

                        if (confirmationSuppression)
                        {
                            livreController.SupprimerLivre(livre.LIVRE_ID, livre.COUVERTURE);
                            ListLivre.ItemsSource = livreController.GetLivres();
                            MessageBox.Show("Le livre a été supprimé avec succès.", "Suppression réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Impossible de supprimer le livre. Il a une location en cours.", "Suppression impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                    isSuppressionConfirmed = true;
                }

                button.IsEnabled = true;
            }
        }

        */

        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if (button.DataContext != null && button.DataContext is Livre)
            {
                Livre livre = (Livre)button.DataContext;

                button.IsEnabled = false;

                if (!livreController.LivrePossedeLocation(livre.LIVRE_ID))
                {
                    bool confirmationSuppression = livreController.ConfirmerSuppressionLivre();

                    if (confirmationSuppression)
                    {
                        livreController.SupprimerLivre(livre.LIVRE_ID, livre.COUVERTURE);
                        ListLivre.ItemsSource = livreController.GetLivres();
                        MessageBox.Show("Le livre a été supprimé avec succès.", "Suppression réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Impossible de supprimer le livre. Il a une location en cours.", "Suppression impossible", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                isSuppressionConfirmed = true;

                button.IsEnabled = true;
            }
        }

        //MODIFIER 
        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            Livre selectedLivre = (Livre)ListLivre.SelectedItem;

            if (selectedLivre != null)
            {
                // Utiliser le navigateur pour afficher la page Modifier avec les informations du livre sélectionné
                NavigationService.Navigate(new Modifier(selectedLivre.LIVRE_ID, selectedLivre.TITRE, selectedLivre.DATE_PUBLICATION, selectedLivre.DISPONIBLE));
            }
        }

        private void MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {
            ModifierButton_Click(sender, e);
        }

    }
}
