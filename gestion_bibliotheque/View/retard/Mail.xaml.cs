using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using gestion_bibliotheque.classes;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using gestion_bibliotheque.ViewModel;

namespace gestion_bibliotheque.View.retard
{
    /// <summary>
    /// Logique d'interaction pour Mail.xaml
    /// </summary>
    public partial class Mail : Window
    {
      
        public Mail(DateTime dateAttendue, DateTime dateAttendueR, int lesJoursRetard, string idLivre, string user)
        {
            InitializeComponent();

            // Assigner les valeurs aux TextBlocks
            DateLocation.Text = $"Vous avez loue un livre le : {dateAttendue}";
            DateRetourAttendue.Text = $"La date limite pour le rendre était attendue pour le : {dateAttendueR}";
            JoursRetard.Text = $"Vous avez actuellement des jours de retard : {lesJoursRetard}";
            IdLivre.Text = $"ID du livre : {idLivre}";
            Utilisateur.Text = $"Bonjour cher utilisateur de la bibliothèque VVA : {user}";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IndexRetard indexRetard = new IndexRetard();
            indexRetard.Show();
            this.Close();
        }
    }
}
