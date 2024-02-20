using gestion_bibliotheque.classes;
using gestion_bibliotheque.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace gestion_bibliotheque.View.location
{
    /// <summary>
    /// Logique d'interaction pour Afficher.xaml
    /// </summary>
    /// 
   
    public partial class Afficher : Page
    {
        private LocationController locationController;
        private CompteController compteController;
        public Afficher()
        {
            InitializeComponent();
            locationController = new LocationController();
            compteController = new CompteController();
            ListLocations.ItemsSource = locationController.GetLocations();

            // Remplacez ces lignes par vos propres méthodes de récupération des données
            ComboBoxUser.ItemsSource = compteController.GetUtilisateurs().Select(g => g.NOMCPTE);

            ComboBoxUser.SelectionChanged += FiltreChanged;

            // Activer la navigation pour la page AjouterRetour
            if (NavigationService != null)
            {
                NavigationService.LoadCompleted += NavigationService_LoadCompleted;
            }
        }
        private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            // Vérifier si la page chargée est AjouterRetour.xaml
            if (e?.Content is AjouterRetour ajouterRetourPage)
            {
                // Récupérer l'ID de la location à partir de la navigation
                if (e.ExtraData is int locationId)
                {
                    // Utiliser l'ID de la location pour initialiser la page AjouterRetour avec des valeurs par défaut
                    DateTime defaultDate = DateTime.Now; // Valeur par défaut pour dateLocation
                    ajouterRetourPage?.InitializeLocationId(locationId, defaultDate, defaultDate, null, null, null);
                }
            }
        }
        private void FiltreChanged(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }
        private string GetUserName(string userName)
        {
            // Implémentez la logique pour récupérer le nom de l'utilisateur
            // en fonction du nom (utilisez votre modèle de données ou contrôleur approprié).
            Compte user = compteController.GetUtilisateurs().FirstOrDefault(u => u.NOMCPTE == userName);
            return user != null ? user.USER : null;
        }
        private void ApplyFilters()
        {
            string selectedUser = ComboBoxUser.SelectedItem as string;
            bool retourEffectueChecked = RetourEffectueCheckBox.IsChecked ?? false;

            IEnumerable<Location> filteredLocations = locationController.GetLocations();

            if (!string.IsNullOrEmpty(selectedUser))
            {
                // Filtrer la liste des locations en fonction de l'utilisateur sélectionné
                filteredLocations = filteredLocations.Where(location => location.USER == GetUserName(selectedUser));
            }

            if (retourEffectueChecked)
            {
                // Filtrer la liste des locations en fonction de la présence de DATE_R_REELLE
                filteredLocations = filteredLocations.Where(location => location.DATE_R_REELLE != null);
            }
            else
            {
                // Si la case à cocher est décochée, inclure également les locations avec DATE_R_REELLE null
                filteredLocations = filteredLocations.Where(location => location.DATE_R_REELLE == null);
            }

            // Mettre à jour la source de données de ListLocations avec la liste filtrée
            ListLocations.ItemsSource = filteredLocations.ToList();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ApplyFilters();
        }
        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer l'auteur associé au bouton cliqué
            Button button = (Button)sender;
            Location location = (Location)button.DataContext;

            // Appeler la méthode de suppression dans le contrôleur
            locationController.SupprimerLocation(location.LOCATION_ID);

            // Rafraîchir la liste des auteurs
            ListLocations.ItemsSource = locationController.GetLocations();
        }

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            Location selected = (Location)ListLocations.SelectedItem;
            if (selected != null)
            {
                // Utiliser le navigateur pour afficher la page Modifier avec les informations du genre sélectionné
                NavigationService.Navigate(new Modifier(selected.LIVRE_ID, selected.USER));
            }
        }

        private void MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {
            ModifierButton_Click(sender, e);
        }
        private void RetourButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer la location associée au bouton cliqué
            Button button = (Button)sender;
            Location location = (Location)button.DataContext;

            // Créer une instance de la page AjouterRetour en lui passant les informations de la location
            AjouterRetour ajouterRetourPage = new AjouterRetour(location.LOCATION_ID, location.DATE_LOCATION, location.DATE_R_ATTENDUE, location.DATE_R_REELLE, location.LIVRE_ID, location.USER);

            // Utiliser le navigateur pour afficher la page AjouterRetour avec les informations de la location sélectionnée
            NavigationService.Navigate(ajouterRetourPage);
        }

    }
}
