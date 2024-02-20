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
    class LocationController
    {
        private const string ConnectionString = "server=localhost;database=vva;uid=root;pwd=;";

        public ObservableCollection<Location> GetLocations()
        {
            ObservableCollection<Location> locations = new ObservableCollection<Location>();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM location_livre";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Location location = new Location
                            {
                                LOCATION_ID = reader.GetInt32("LOCATION_ID"),
                                //COUVERTURE = reader.IsDBNull(reader.GetOrdinal("COUVERTURE")) ? null : reader.GetString("COUVERTURE")
                                DATE_LOCATION = reader.GetDateTime("DATE_LOCATION"),
                                DATE_R_ATTENDUE = reader.GetDateTime("DATE_R_ATTENDUE"),
                                DATE_R_REELLE = reader.IsDBNull(reader.GetOrdinal("DATE_R_REELLE")) ? (DateTime?)null : reader.GetDateTime("DATE_R_REELLE"),
                                LIVRE_ID = reader.GetString("LIVRE_ID"),
                                USER = reader.GetString("USER")
                            };
                            locations.Add(location);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la récupération des auteurs : " + ex.Message);
                }
            }

            return locations;
        }
        //SUPPRIMER
        public void SupprimerLocation(int locationId)
        {
            if (ConfirmerSuppressionLocation())
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Vérifier si la DATE_R_REELLE n'est pas nulle pour cette location
                    string checkQuery = "SELECT DATE_R_REELLE FROM location_livre WHERE LOCATION_ID = @LocationId AND DATE_R_REELLE IS NOT NULL";

                    using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@LocationId", locationId);
                        object dateReelle = checkCommand.ExecuteScalar();

                        // Vérifier si la DATE_R_REELLE n'est pas nulle
                        if (dateReelle != null && dateReelle != DBNull.Value)
                        {
                            // Supprimer la location si la DATE_R_REELLE n'est pas nulle
                            string deleteQuery = "DELETE FROM location_livre WHERE LOCATION_ID = @LocationId";

                            using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@LocationId", locationId);
                                int rowsAffected = deleteCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Suppression réussie.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Aucune ligne supprimée. Vérifiez l'ID de la location.", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cette location est encore en cours. Suppression annulée.", "Erreur de suppression", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }
        //EN SUPPRIMANT LA CONFIRMATION
        public bool ConfirmerSuppressionLocation()
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce genre ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

            return result == MessageBoxResult.Yes;
        }


        public void AjouterLocation(Location nouvelleLocation)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO location_livre (DATE_LOCATION, DATE_R_ATTENDUE, LIVRE_ID, USER) VALUES (@DateLocation, @DateAttendue, @LivreId, @UtilisateurId)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateLocation", nouvelleLocation.DATE_LOCATION);
                        command.Parameters.AddWithValue("@DateAttendue", nouvelleLocation.DATE_R_ATTENDUE);
                        command.Parameters.AddWithValue("@LivreId", nouvelleLocation.LIVRE_ID);
                        command.Parameters.AddWithValue("@UtilisateurId", nouvelleLocation.USER);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de l'ajout de la location : " + ex.Message);
                   
                }
            }
        }

        //MODIFIER 
        public bool ModifierLocation(Location location)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE location_livre SET LIVRE_ID = @LivreId, USER = @Utilisateur WHERE LOCATION_ID = @LocationId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Utiliser des paramètres pour éviter les attaques par injection SQL
                        command.Parameters.AddWithValue("@LivreId", location.LIVRE_ID);
                        command.Parameters.AddWithValue("@Utilisateur", location.USER);
                        command.Parameters.AddWithValue("@LocationId", location.LOCATION_ID);

                        // Exécuter la commande
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la modification de la location : " + ex.Message);
                    return false;
                }
            }
        }

        public Location GetLocationByLivreEtUtilisateur(string livreId, string utilisateur)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM location_livre WHERE LIVRE_ID = @LivreId AND USER = @Utilisateur";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LivreId", livreId);
                        command.Parameters.AddWithValue("@Utilisateur", utilisateur);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Location location = new Location
                                {
                                    LOCATION_ID = reader.GetInt32("LOCATION_ID"),
                                    DATE_LOCATION = reader.GetDateTime("DATE_LOCATION"),
                                    DATE_R_ATTENDUE = reader.GetDateTime("DATE_R_ATTENDUE"),
                                    DATE_R_REELLE = reader.IsDBNull(reader.GetOrdinal("DATE_R_REELLE")) ? (DateTime?)null : reader.GetDateTime("DATE_R_REELLE"),
                                    LIVRE_ID = reader.GetString("LIVRE_ID"),
                                    USER = reader.GetString("USER")
                                };

                                return location;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la récupération de la location : " + ex.Message);
                }

                return null;
            }
        }

        
        public void Retour(int locationId, DateTime dateReelle)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE location_livre SET DATE_R_REELLE = @DateReelle WHERE LOCATION_ID = @LocationId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DateReelle", dateReelle);
                        command.Parameters.AddWithValue("@LocationId", locationId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la mise à jour de DATE_R_REELLE : " + ex.Message);
                }
            }
        }
        public void AjouterDateRetourReelle(int locationId, DateTime dateRetourReelle)
        {
            // Assumez que vous avez une méthode d'accès à la base de données pour effectuer l'insertion
            // Remplacez cela par la logique réelle d'insertion dans votre base de données
            string query = "UPDATE location_livre SET DATE_R_REELLE = @DateRetourReelle WHERE LOCATION_ID = @LocationId";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LocationId", locationId);
                    command.Parameters.AddWithValue("@DateRetourReelle", dateRetourReelle);

                    connection.Open();
                    command.ExecuteNonQuery();

                    // Afficher un message de confirmation
                    System.Windows.MessageBox.Show("Enregistrement effectué avec succès!", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
