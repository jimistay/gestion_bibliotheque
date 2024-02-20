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

namespace gestion_bibliotheque.View.livres
{
    /// <summary>
    /// Logique d'interaction pour IndexLivre.xaml
    /// </summary>
    public partial class IndexLivre : Window
    {
        public IndexLivre()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Afficher();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WelcomeUser welcomeUser = new WelcomeUser();
            welcomeUser.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new Ajouter();
        }

      
    }
}
