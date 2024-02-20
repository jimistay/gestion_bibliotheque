using gestion_bibliotheque.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace gestion_bibliotheque.ViewModel
{
    class AuteurController
    {
        private const string ConnectionString = "server=localhost;database=vva;uid=root;pwd=;";

        //AFFICHER ->Afficher.xaml
        public ObservableCollection<Auteur> GetAuteurs()
        {
            ObservableCollection<Auteur> auteurs = new ObservableCollection<Auteur>();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    //SELECT `NOM_AUTEUR`,`PRENOM_AUTEUR` FROM `auteur_livre`
                    string query = "SELECT AUTEUR_ID,NOM_AUTEUR, PRENOM_AUTEUR FROM auteur_livre ORDER BY NOM_AUTEUR ASC";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Auteur auteur = new Auteur
                            {
                                AUTEUR_ID = reader.GetInt32("AUTEUR_ID"),
                                NOM_AUTEUR = reader.GetString("NOM_AUTEUR"),
                                PRENOM_AUTEUR = reader.GetString("PRENOM_AUTEUR")
                            };
                            auteurs.Add(auteur);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la récupération des auteurs : " + ex.Message);
                }
            }

            return auteurs;
        }


        //SUPPRIMER -> Afficher.xaml 
        public void SupprimerAuteur(int auteurId)
        {
            if (ConfirmerSuppressionAuteur())
            {
                if (AuteurPossedeLivre(auteurId))
                {
                    MessageBox.Show("Un livre est associé à cet auteur. Vous ne pouvez pas supprimer cet auteur.", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; 
                }

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM auteur_livre WHERE AUTEUR_ID = @AuteurId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AuteurId", auteurId);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        // Vérifier si un livre est associé à un auteur ->Ici pour la fonction d'en haut 
        public bool AuteurPossedeLivre(int auteurId)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM livre WHERE AUTEUR_ID = @AuteurId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AuteurId", auteurId);

                    // donne le nb livres associés à un auteur
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Retourner true si le livre est associé
                    return count > 0;
                }
            }
        }

        //EN SUPPRIMANT LA CONFIRMATION -> Ici en haut
        public bool ConfirmerSuppressionAuteur()
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer cet auteur ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

            return result == MessageBoxResult.Yes;
        }


        //AJOUTER -> Ajouter.xaml
        public void AjouterAuteur(string nom, string prenom)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO auteur_livre (NOM_AUTEUR, PRENOM_AUTEUR) VALUES (@Nom, @Prenom)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nom", nom);
                        command.Parameters.AddWithValue("@Prenom", prenom);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Auteur ajouté avec succès!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout de l'auteur : " + ex.Message);
                }
            }
        }

        //MODIFIER Modifier.xaml
        public bool ModifierAuteur(int id, string nomAuteur, string prenomAuteur)
        {
            string query = "UPDATE auteur_livre SET NOM_AUTEUR = @NomAuteur, PRENOM_AUTEUR = @PrenomAuteur WHERE AUTEUR_ID = @Id";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomAuteur", nomAuteur);
                    command.Parameters.AddWithValue("@PrenomAuteur", prenomAuteur);
                    command.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erreur : " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}