using gestion_bibliotheque.View;
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

namespace gestion_bibliotheque
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.UserController.Connexion(USER.Text, MDP.Text))
            {
                WelcomeUser welcome = new View.WelcomeUser();
                welcome.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect");
            }

        }
    }
}
