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

namespace gestion_bibliotheque.View.location
{
    /// <summary>
    /// Logique d'interaction pour AjouterRetour.xaml
    /// </summary>
    public partial class AjouterRetour : Page
    {
        private int locationId;
        private LivreController livreController;
        private CompteController compteController;

        public AjouterRetour(int locationId, DateTime dateLocation, DateTime dateRetourAttendue, DateTime? dateRetourReelle, string livreId, string user)
        {
            InitializeComponent();
            livreController = new LivreController();
            compteController = new CompteController();
            this.locationId = locationId;

            // Remplir LivreComboBox avec les titres des livres
            LivreComboBox.ItemsSource = livreController.GetLivres();

            // Remplir UtilisateurComboBox avec les utilisateurs
            UtilisateurComboBox.ItemsSource = compteController.GetUtilisateurs();

            // Définir les informations de la location dans les contrôles de la page
            DateLocationTextBox.SelectedDate = dateLocation;

            // Définir les informations de la location dans les contrôles de la page
            DateLocationTextBox.SelectedDate = dateLocation;
            LivreComboBox.SelectedValue = livreId; // Assurez-vous que le type de livreId est compatible avec la SelectedValuePath
            UtilisateurComboBox.SelectedValue = user;
        }

        public void InitializeLocationId(int locationId, DateTime dateLocation, DateTime dateRetourAttendue, DateTime? dateRetourReelle, string livreId, string user)
        {
            this.locationId = locationId;
            // Ajoutez le code pour initialiser la page avec l'ID de la location si nécessaire
            // Utilisez ces informations pour initialiser les contrôles dans votre page AjouterRetour.xaml
            DateLocationTextBox.SelectedDate = dateLocation;
        }

        private void AjouterRetour_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer la date de retour réelle depuis le DatePicker
            DateTime dateRetourReelle = DateLocationTextBox.SelectedDate ?? DateTime.Now; // Utilisez DateTime.Now si aucune date n'est sélectionnée

            // Récupérer les valeurs sélectionnées dans les ComboBox
            //int livreId = (int)LivreComboBox.SelectedValue;
            int livreId = Convert.ToInt32(LivreComboBox.SelectedValue);
            string userId = (string)UtilisateurComboBox.SelectedValue;

            // Appeler la méthode Retour du LocationController
            LocationController locationController = new LocationController();
            locationController.Retour(locationId, dateRetourReelle);

            // Mettre à jour le statut DISPONIBLE du livre à TRUE
            livreController.MettreLivreDisponible(livreId);

            // Ajouter la date de retour attendue à la table location_livre
            locationController.AjouterDateRetourReelle(locationId, dateRetourReelle); // Ajoutez une méthode dans votre LocationController pour gérer l'insertion
        }

    }
}
