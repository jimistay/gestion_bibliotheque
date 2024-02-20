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

namespace gestion_bibliotheque.View.edition
{
    /// <summary>
    /// Logique d'interaction pour Afficher.xaml
    /// </summary>
    public partial class Afficher : Page
    {
        private EditionController editionController; 
        public Afficher()
        {
            InitializeComponent();
            editionController = new EditionController();
            ListEditions.ItemsSource = editionController.GetEditions();
        }

        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer l'auteur associé au bouton cliqué
            Button button = (Button)sender;
            Edition edition = (Edition)button.DataContext;

            // Appeler la méthode de suppression dans le contrôleur
            editionController.SupprimerEdition(edition.EDITION_ID);

            // Rafraîchir la liste des auteurs
            ListEditions.ItemsSource = editionController.GetEditions();
        }
        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            Edition selected = (Edition)ListEditions.SelectedItem;
            if (selected != null)
            {
                // Utiliser le navigateur pour afficher la page Modifier avec les informations du genre sélectionné
                NavigationService.Navigate(new Modifier(selected.EDITION_ID, selected.NOM_EDITION));
            }
        }

        private void MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {
            ModifierButton_Click(sender, e);
        }
    }
}
