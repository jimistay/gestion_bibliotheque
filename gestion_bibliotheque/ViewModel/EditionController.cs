using gestion_bibliotheque.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace gestion_bibliotheque.ViewModel
{
    class EditionController
    {
        private const string ConnectionString = "server=localhost;database=vva;uid=root;pwd=;";

        //AFFICHER
        public ObservableCollection<Edition> GetEditions()
        {
            ObservableCollection<Edition> editions = new ObservableCollection<Edition>();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT EDITION_ID, NOM_EDITION FROM edition_livre ORDER BY NOM_EDITION ASC";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Edition edition = new Edition
                            {
                                EDITION_ID = reader.GetInt32("EDITION_ID"),
                                NOM_EDITION = reader.GetString("NOM_EDITION")
                            };
                            editions.Add(edition);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la récupération des auteurs : " + ex.Message);
                }
            }

            return editions;
        }

        //SUPPRIMER
        public void SupprimerEdition(int editionId)
        {
            if (ConfirmerSuppressionEdition())
            {
                // Vérifier si un livre est associé à cette édition
                if (EditionPossedeLivre(editionId))
                {
                    MessageBox.Show("Un livre est associé à cette édition. Vous ne pouvez pas supprimer cette édition.", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Arrêter le processus de suppression
                }

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Utiliser une requête DELETE pour supprimer le genre spécifique
                    string query = "DELETE FROM edition_livre WHERE EDITION_ID = @EditionId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Utiliser des paramètres pour éviter les attaques par injection SQL
                        command.Parameters.AddWithValue("@EditionId", editionId);

                        // Exécuter la commande
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        //EN SUPPRIMANT LA CONFIRMATION
        public bool ConfirmerSuppressionEdition()
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer cette édition ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

            return result == MessageBoxResult.Yes;
        }
        // Vérifier si un livre est associé à une édition
        public bool EditionPossedeLivre(int editionId)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                // Utiliser une requête SELECT pour vérifier si un livre est associé à cette édition
                string query = "SELECT COUNT(*) FROM livre WHERE EDITION_ID = @EditionId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Utiliser des paramètres pour éviter les attaques par injection SQL
                    command.Parameters.AddWithValue("@EditionId", editionId);

                    // Obtenir le nombre de livres associés à cette édition
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Retourner vrai si un livre est associé, faux sinon
                    return count > 0;
                }
            }
        }
        //AJOUTER
        public void AjouterEdition(string nom)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO edition_livre (NOM_EDITION) VALUES (@Nom)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@Nom", nom);

                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Edition ajoutée avec succès!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'ajout de l'édition : " + ex.Message);
                }
            }
        }

        //MODIFIER 
        public bool ModifierEdition(int id, string nomEdition)
        {
            string query = "UPDATE edition_livre SET NOM_EDITION = @NomEdition WHERE EDITION_ID = @Id";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NomEdition", nomEdition);
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
