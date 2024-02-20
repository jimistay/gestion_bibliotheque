using gestion_bibliotheque.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using gestion_bibliotheque.classes;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace gestion_bibliotheque.View.retard
{
    /// <summary>
    /// Logique d'interaction pour IndexRetard.xaml
    /// </summary>
    public partial class IndexRetard : Window
    {
        private RetardController retardController;
        public IndexRetard()
        {
            InitializeComponent();
            retardController = new RetardController();
            ListRetards.ItemsSource = retardController.GetRetards();

            //DataContext = retardController;
           
        }


        private void EnvoyerMailButton_Click(object sender, RoutedEventArgs e)
        {
            Location selected = (Location)ListRetards.SelectedItem;
            if (selected != null)
            {
                Mail mailPage = new Mail(selected.DATE_LOCATION, selected.DATE_R_ATTENDUE, selected.JoursRetard, selected.LIVRE_ID, selected.USER);
                this.Hide(); // Masquer la fenêtre actuelle
                mailPage.Owner = this; // Définir la fenêtre parent de la page Mail
                mailPage.Show();
            }
        }


        private void MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {
            EnvoyerMailButton_Click(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WelcomeUser user = new WelcomeUser();
            user.Show();
            this.Close();
        }


      
    }
}
