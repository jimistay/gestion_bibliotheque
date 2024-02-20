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
    /// Logique d'interaction pour Modifier.xaml
    /// </summary>
    public partial class Modifier : Page
    {
        private int AUTEUR_ID;
        private AuteurController auteurController;
        
        public Modifier(int ateurId, string nouveauNom, string nouveauPrenom)
        {
            InitializeComponent();
            AUTEUR_ID = ateurId;
            NomAuteurTextBox.Text = nouveauNom;
            PrenomAuteurTextBox.Text = nouveauPrenom;

            auteurController = new AuteurController();// Ajout de cette ligne pour créer une instance de AuteurController 
        }

        private void ValiderButton_Click(object sender, RoutedEventArgs e)
        {
            if (auteurController.ModifierAuteur(AUTEUR_ID, NomAuteurTextBox.Text, PrenomAuteurTextBox.Text))
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
