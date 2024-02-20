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
    /// Logique d'interaction pour Modifier.xaml
    /// </summary>
    public partial class Modifier : Page
    {
        private int EDITION_ID;
        private EditionController editionController;
            
        public Modifier(int editionId, string nouveauNom)
        {
            InitializeComponent();
            EDITION_ID = editionId;
            NomEditionTextBox.Text = nouveauNom;
            editionController = new EditionController();// Ajout de cette ligne pour créer une instance de EditionController 
        }

        private void ValiderButton_Click(object sender, RoutedEventArgs e)
        {
            if (editionController.ModifierEdition(EDITION_ID, NomEditionTextBox.Text))
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
