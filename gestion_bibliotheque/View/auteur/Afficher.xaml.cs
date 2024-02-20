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

namespace gestion_bibliotheque.View.auteur
{
    /// <summary>
    /// Logique d'interaction pour Afficher.xaml
    /// </summary>
    public partial class Afficher : Page
    {
        private AuteurController auteurController;
        public Afficher()
        {
            InitializeComponent();
            auteurController = new AuteurController();
            ListAuteurs.ItemsSource = auteurController.GetAuteurs();
        }

        private void SupprimerButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer l'auteur associé au bouton cliqué
            Button button = (Button)sender;
            Auteur auteur = (Auteur)button.DataContext;

            // Appeler la méthode de suppression dans le contrôleur
            auteurController.SupprimerAuteur(auteur.AUTEUR_ID);

            // Rafraîchir la liste des auteurs
            ListAuteurs.ItemsSource = auteurController.GetAuteurs();
        }
     

        private void ModifierButton_Click(object sender, RoutedEventArgs e)
        {
            Auteur selected = (Auteur)ListAuteurs.SelectedItem;
            if (selected != null)
            {
                // afficher la page Modifier.xaml avec les info passés en params
                NavigationService.Navigate(new Modifier(selected.AUTEUR_ID, selected.NOM_AUTEUR, selected.PRENOM_AUTEUR));
            }
        }

        private void MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {
            ModifierButton_Click(sender, e);
        }
    }
}
