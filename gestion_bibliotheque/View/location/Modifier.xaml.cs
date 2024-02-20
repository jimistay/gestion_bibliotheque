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
    /// Logique d'interaction pour Modifier.xaml
    /// </summary>
    public partial class Modifier : Page
    {
        private LocationController locationController;
        private LivreController livreController;
        private CompteController compteController;
        private Location locationAModifier;

        public Modifier(string livreId, string utilisateur)
        {
            InitializeComponent();
            locationController = new LocationController();
            livreController = new LivreController();
            compteController = new CompteController();

            // Récupérer la location à partir des informations passées en paramètres
            locationAModifier = locationController.GetLocationByLivreEtUtilisateur(livreId, utilisateur);

            // Remplir LivreComboBox avec les titres des livres
            LivreComboBox.ItemsSource = livreController.GetLivres();

            // Remplir UtilisateurComboBox avec les utilisateurs
            UtilisateurComboBox.ItemsSource = compteController.GetUtilisateurs();

            // Sélectionner le livre et l'utilisateur de la location à modifier
            LivreComboBox.SelectedValue = locationAModifier.LIVRE_ID;
            UtilisateurComboBox.SelectedValue = locationAModifier.USER;
        }

        private void ValiderButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer les nouvelles valeurs sélectionnées dans les ComboBox
            Livre selectedLivre = (Livre)LivreComboBox.SelectedItem;
            Compte selectedCompte = (Compte)UtilisateurComboBox.SelectedItem;

            // Mettre à jour les propriétés de la location à modifier
            locationAModifier.LIVRE_ID = selectedLivre.LIVRE_ID.ToString();
            locationAModifier.USER = selectedCompte.USER;

            // Appeler la méthode de votre LocationController pour mettre à jour la location dans la base de données
            if (locationController.ModifierLocation(locationAModifier))
            {
                // Afficher un message de réussite ou gérer les erreurs si nécessaire
                MessageBox.Show("La location a été modifiée avec succès!", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                // Gérer les erreurs en cas d'échec de la modification
                MessageBox.Show("Erreur lors de la modification de la location. Veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
