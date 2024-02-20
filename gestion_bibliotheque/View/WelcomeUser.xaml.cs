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
using System.Windows.Shapes;

namespace gestion_bibliotheque.View
{
    /// <summary>
    /// Logique d'interaction pour WelcomeUser.xaml
    /// </summary>
    public partial class WelcomeUser : Window
    {
        public WelcomeUser()
        {
            InitializeComponent();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            View.location.IndexLocation indexLocation = new View.location.IndexLocation();
            indexLocation.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            View.retard.IndexRetard indexRetard = new View.retard.IndexRetard();
            indexRetard.Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View.livres.IndexLivre indexLivre = new livres.IndexLivre();
            indexLivre.Show();
            this.Close();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            View.genre.IndexGenre indexGenre = new genre.IndexGenre();
            indexGenre.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            View.edition.IndexEdition indexEdition = new edition.IndexEdition();
            indexEdition.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            View.auteur.IndexAuteur indexAuteur = new auteur.IndexAuteur();
            indexAuteur.Show();
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
