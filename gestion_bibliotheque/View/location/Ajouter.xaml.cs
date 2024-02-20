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

namespace gestion_bibliotheque.View.location
{
    /// <summary>
    /// Logique d'interaction pour Ajouter.xaml
    /// </summary>
    public partial class Ajouter : Page
    {
        private LocationController locationController;
        private LivreController livreController;
        private CompteController compteController;

        public Ajouter()
        {
            InitializeComponent();
            locationController = new LocationController();
            livreController = new LivreController();
            compteController = new CompteController();

            // Remplir LivreComboBox avec les titres des livres
            LivreComboBox.ItemsSource = livreController.GetLivresDisponibles();

            // Remplir UtilisateurComboBox avec les utilisateurs
            UtilisateurComboBox.ItemsSource = compteController.GetUtilisateurs();

            // Définir la date d'aujourd'hui dans DateLocationTextBox
            DateLocationTextBox.SelectedDate = DateTime.Now;

            // Définir la date d'aujourd'hui plus deux semaines dans DateLocationAttendueTextBox
            DateLocationAttendueTextBox.SelectedDate = DateTime.Now.AddDays(14);

            // Désactiver les modifications manuelles dans les DatePickers
            DateLocationTextBox.IsEnabled = false;
            DateLocationAttendueTextBox.IsEnabled = false;
        }

        private void AjouterLocation_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer la date actuelle pour DATE_LOCATION
            DateTime dateLocation = DateTime.Now;

            // Récupérer les autres valeurs des contrôles de votre UI
            DateTime dateAttendue = DateLocationAttendueTextBox.SelectedDate ?? DateTime.MinValue;
            Livre selectedLivre = (Livre)LivreComboBox.SelectedItem;
            Compte selectedCompte = (Compte)UtilisateurComboBox.SelectedItem;

            // Convertir LIVRE_ID en chaîne
            string livreId = selectedLivre.LIVRE_ID.ToString();

            // Créer une nouvelle instance de la classe Location avec les valeurs récupérées
            Location nouvelleLocation = new Location
            {
                DATE_LOCATION = dateLocation,
                DATE_R_ATTENDUE = dateAttendue,
                LIVRE_ID = livreId,
                USER = selectedCompte.USER
            };

            // Appeler la méthode de votre LocationController pour ajouter la nouvelle location à la base de données
            locationController.AjouterLocation(nouvelleLocation);
            // Mettre à jour le statut DISPONIBLE du livre à FALSE
            livreController.MettreLivreIndisponible(selectedLivre.LIVRE_ID);

            // Afficher un message de réussite ou gérer les erreurs si nécessaire
            MessageBox.Show("La location a été ajoutée avec succès!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
