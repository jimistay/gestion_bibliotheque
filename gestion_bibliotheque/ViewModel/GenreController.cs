using gestion_bibliotheque.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace gestion_bibliotheque.ViewModel
{
    class GenreController
    {
        private const string ConnectionString = "server=localhost;database=vva;uid=root;pwd=;";


        //AFFICHAGE 
        public ObservableCollection<Genre> GetGenres()
        {
            ObservableCollection<Genre> genres = new ObservableCollection<Genre>();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT GENRE_ID, NOM_GENRE FROM genre_livre ORDER BY NOM_GENRE ASC";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Genre genre = new Genre
                            {
                                GENRE_ID = reader.GetInt32("GENRE_ID"),
                                NOM_GENRE = reader.GetString("NOM_GENRE")
                            };
                            genres.Add(genre);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Gérer l'exception 
                    Console.WriteLine("Erreur lors de la récupération des genres : " + ex.Message);
                }
            }

            return genres;
        }

        //SUPPRIMER 
        public void SupprimerGenre(int genreId)
        {
            // Demander confirmation avant de supprimer
            if (ConfirmerSuppressionGenre())
            {
                // Vérifier si un livre est associé à ce genre
                if (GenrePossedeLivre(genreId))
                {
                    MessageBox.Show("Un livre est associé à ce genre. Vous ne pouvez pas supprimer ce genre.", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Arrêter le processus de suppression
                }

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Utiliser une requête DELETE pour supprimer le genre spécifique
                    string query = "DELETE FROM genre_livre WHERE GENRE_ID = @GenreId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Utiliser des paramètres pour éviter les attaques par injection SQL
                        command.Parameters.AddWithValue("@GenreId", genreId);

                        // Exécuter la commande
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        // Vérifier si un livre est associé à un genre
        public bool GenrePossedeLivre(int genreId)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                // Utiliser une requête SELECT pour vérifier si un livre est associé à ce genre
                string query = "SELECT COUNT(*) FROM livre WHERE GENRE_ID = @GenreId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Utiliser des paramètres pour éviter les attaques par injection SQL
                    command.Parameters.AddWithValue("@GenreId", genreId);

                    // Obtenir le nombre de livres associés à ce genre
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Retourner vrai si un livre est associé, faux sinon
                    return count > 0;
                }
            }
        }

        //EN SUPPRIMANT LA CONFIRMATION
        public bool ConfirmerSuppressionGenre()
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce genre ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

            return result == MessageBoxResult.Yes;
        }


        //AJOUTER 
        public void AjouterGenre(string nom)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO genre_livre (NOM_GENRE) VALUES (@Nom)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Utiliser des paramètres pour éviter les attaques par injection SQL
                        command.Parameters.AddWithValue("@Nom", nom);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Genre ajouté avec succès!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout du genre : " + ex.Message);
                }
            }
        }

        //MODIFIER 
        public bool ModifierGenre(int id, string nomGenre)
        {
            string query = "UPDATE genre_livre SET NOM_GENRE = @NomGenre WHERE GENRE_ID = @Id";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomGenre", nomGenre);
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
