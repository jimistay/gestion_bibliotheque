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

namespace gestion_bibliotheque.View.livres
{
    /// <summary>
    /// Logique d'interaction pour Modifier.xaml
    /// </summary>
    /// 
    /*
    public partial class Modifier : Page
    {
        private int LIVRE_ID;
        private LivreController livreController;

        private string TITRE;
        private DateTime DATE_PUBLICATION;
        private bool DISPONIBLE;
        public Modifier(int livreId, string titre, DateTime datePublication, bool dispo)
        {
            InitializeComponent();
            LIVRE_ID = livreId;
            TITRE = titre;
            DATE_PUBLICATION = datePublication;
            DISPONIBLE = dispo;

            livreController = new LivreController();

            // Remplir les champs avec les données actuelles du livre
            RemplirChampsLivre();
        }

        private void SelectionnerImage_Click(object sender, RoutedEventArgs e)
        {
            // Mettez ici le code pour gérer le clic sur le bouton "Sélectionner Image"
            // Par exemple, vous pourriez ouvrir une boîte de dialogue pour sélectionner une image.
        }
        private void RemplirChampsLivre()
        {
            // Utilisez la méthode du contrôleur pour récupérer les informations du livre
            Livre livre = livreController.GetLivreById(LIVRE_ID);

            // Remplir les champs avec les données du livre
            TitreTextBox.Text = livre.TITRE;
            DatePublicationTextBox.SelectedDate = livre.DATE_PUBLICATION;
            DisponibleTextBox.IsChecked = livre.DISPONIBLE;
        }

        private void ValiderButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtenez les valeurs actuelles des champs
            string titre = TitreTextBox.Text;
            DateTime datePublication = DatePublicationTextBox.SelectedDate ?? DateTime.MinValue;
            bool disponible = DisponibleTextBox.IsChecked ?? false;
            // Appelez la méthode du contrôleur pour effectuer la modification
            if (livreController.ModifierLivre(LIVRE_ID, titre, datePublication, disponible))
            {
                MessageBox.Show("Modification effectuée avec succès.", "Modification réussie", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification du livre.", "Modification échouée", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    */



    /*
    public partial class Modifier : Page
    {
        private int LIVRE_ID;
        private LivreController livreController;

        public Modifier(int livreId, string titre, DateTime? datePublication, bool? disponible)
        {
            InitializeComponent();
            LIVRE_ID = livreId;
            TitreTextBox.Text = titre;
            DatePublicationTextBox.SelectedDate = datePublication;
            DisponibleTextBox.IsChecked = disponible;

            livreController = new LivreController(); // Ajout de cette ligne pour créer une instance de GenreController
        }

        private void ValiderButton_Click(object sender, RoutedEventArgs e)
        {
            // Convertir les valeurs nullable en valeurs non-nullable
            DateTime datePublication = DatePublicationTextBox.SelectedDate ?? DateTime.MinValue;
            bool disponible = DisponibleTextBox.IsChecked ?? false;

            if (livreController.ModifierLivre(LIVRE_ID, TitreTextBox.Text, datePublication, disponible))
            {
                MessageBox.Show("Modification effectuée");
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification");
            }
        }

    }
    */

    public partial class Modifier : Page
    {
        private int LIVRE_ID;
        private LivreController livreController;

        public Modifier(int livreId, string titre, DateTime? datePublication, bool? disponible)
        {
            InitializeComponent();
            LIVRE_ID = livreId;
            TitreTextBox.Text = titre;
            DatePublicationTextBox.SelectedDate = datePublication;
            DisponibleTextBox.IsChecked = disponible;

            livreController = new LivreController();
        }

        private void ValiderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Convertir les valeurs nullable en valeurs non-nullable
                DateTime datePublication = DatePublicationTextBox.SelectedDate ?? DateTime.MinValue;
                bool disponible = DisponibleTextBox.IsChecked ?? false;

                if (livreController.ModifierLivre(LIVRE_ID, TitreTextBox.Text, datePublication, disponible))
                {
                    MessageBox.Show("Modification effectuée avec succès.", "Modification réussie", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Erreur lors de la modification du livre.", "Modification échouée", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur inattendue : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
