using gestion_bibliotheque.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace gestion_bibliotheque.ViewModel
{
    class LivreController
    {
         
        private const string ConnectionString = "server=localhost;database=vva;uid=root;pwd=;";


        //Afficher les livres dispo et non 
        public ObservableCollection<Livre> GetLivres()
        {
            ObservableCollection<Livre> livres = new ObservableCollection<Livre>();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    
                    string query = "SELECT LIVRE_ID, TITRE, DATE_PUBLICATION, DISPONIBLE, COUVERTURE, GENRE_ID, AUTEUR_ID, EDITION_ID FROM livre";
                    //string query = "SELECT livre.*, genre_livre.NOM_GENRE FROM livre INNER JOIN genre_livre ON livre.GENRE_ID = genre_livre.GENRE_ID";


                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Livre livre = new Livre
                            {
                                LIVRE_ID = reader.GetInt32("LIVRE_ID"),
                                TITRE = reader.GetString("TITRE"),
                                DATE_PUBLICATION = reader.GetDateTime("DATE_PUBLICATION"),
                                DISPONIBLE = reader.GetBoolean("DISPONIBLE"),
                                COUVERTURE = reader.IsDBNull(reader.GetOrdinal("COUVERTURE")) ? null : reader.GetString("COUVERTURE"),
                                GENRE_ID = reader.GetInt16("GENRE_ID"),
                                AUTEUR_ID = reader.GetInt16("AUTEUR_ID"),
                                EDITION_ID = reader.GetInt16("EDITION_ID"),
                                //CouvertureImage = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CheminVersVotreDossierImages", reader.GetString("COUVERTURE")),
                              
                            };

                            livres.Add(livre);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la récupération des auteurs : " + ex.Message);
                }
            }

            return livres;
        }

        //AFFICHER SEULEMENT LES LIVRES DISPO (pour la location liste déroulante des livres -> car 1 seul exemplaire d'un livre)
        public List<Livre> GetLivresDisponibles()
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM livre WHERE DISPONIBLE = true";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            List<Livre> livres = new List<Livre>();

                            while (reader.Read())
                            {
                                Livre livre = new Livre
                                {
                                    // Initialisez les propriétés du livre à partir des données du lecteur
                                    LIVRE_ID = reader.GetInt32(reader.GetOrdinal("LIVRE_ID")),
                                    TITRE = reader.GetString(reader.GetOrdinal("TITRE")),
                                    // ...
                                };

                                livres.Add(livre);
                            }

                            return livres;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la récupération des livres : " + ex.Message);
                    return new List<Livre>(); // ou lancez une exception appropriée
                }
            }
        }

        //LORSQU ON AJOUTE une location on passe le DISPONIBLE EN false afin de ne pas l'afficher comme dosponible 
        public void MettreLivreIndisponible(int livreId)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE livre SET DISPONIBLE = false WHERE LIVRE_ID = @LivreId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LivreId", livreId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la mise à jour du statut DISPONIBLE du livre : " + ex.Message);
                    // Gérer l'erreur comme nécessaire
                }
            }
        }
        //L'inverse d'en haut 
        public void MettreLivreDisponible(int livreId)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE livre SET DISPONIBLE = true WHERE LIVRE_ID = @LivreId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LivreId", livreId);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la mise à jour du statut DISPONIBLE du livre : " + ex.Message);
                    // Gérer l'erreur comme nécessaire
                }
            }
        }


        //AJOUTER
        /*
        public void AjouterLivre(Livre livre)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO livre (TITRE, DATE_PUBLICATION, DISPONIBLE, COUVERTURE, GENRE_ID, AUTEUR_ID, EDITION_ID) " +
                                   "VALUES (@Titre, @DatePublication, @Disponible, @Couverture, @GenreId, @AuteurId, @EditionId)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Titre", livre.TITRE);
                        command.Parameters.AddWithValue("@DatePublication", livre.DATE_PUBLICATION);
                        command.Parameters.AddWithValue("@Disponible", livre.DISPONIBLE);
                        command.Parameters.AddWithValue("@Couverture", livre.COUVERTURE);
                        command.Parameters.AddWithValue("@GenreId", livre.GENRE_ID);
                        command.Parameters.AddWithValue("@AuteurId", livre.AUTEUR_ID);
                        command.Parameters.AddWithValue("@EditionId", livre.EDITION_ID);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de l'ajout du livre : " + ex.Message);
                }
            }
        }
        */
        public void AjouterLivre(Livre livre)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO livre (TITRE, DATE_PUBLICATION, DISPONIBLE, COUVERTURE, GENRE_ID, AUTEUR_ID, EDITION_ID) " +
                                   "VALUES (@Titre, @DatePublication, true, @Couverture, @GenreId, @AuteurId, @EditionId)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Titre", livre.TITRE);
                        command.Parameters.AddWithValue("@DatePublication", livre.DATE_PUBLICATION);
                        command.Parameters.AddWithValue("@Couverture", livre.COUVERTURE);
                        command.Parameters.AddWithValue("@GenreId", livre.GENRE_ID);
                        command.Parameters.AddWithValue("@AuteurId", livre.AUTEUR_ID);
                        command.Parameters.AddWithValue("@EditionId", livre.EDITION_ID);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de l'ajout du livre : " + ex.Message);
                }
            }
        }
        //SUPPRIMER

        public void SupprimerLivre(int livreId, string nomFichierCouverture)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                // Utiliser une requête DELETE pour supprimer le genre spécifique
                string query = "DELETE FROM livre WHERE LIVRE_ID = @LivreId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Utiliser des paramètres pour éviter les attaques par injection SQL
                    command.Parameters.AddWithValue("@LivreId", livreId);

                    // Exécuter la commande
                    command.ExecuteNonQuery();
                }
            }

            // Appeler la méthode pour supprimer l'image associée au livre
            SupprimerImageLivre(nomFichierCouverture);
        }
        //VERIFIER SI UN LIVRE A UNE LOCATION EN COURS 
        public bool LivrePossedeLocation(int livreId)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                // Utiliser une requête SELECT pour vérifier si le livre a une location en cours
                string query = "SELECT COUNT(*) FROM location_livre WHERE LIVRE_ID = @LivreId AND DATE_R_REELLE IS NULL";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Utiliser des paramètres pour éviter les attaques par injection SQL
                    command.Parameters.AddWithValue("@LivreId", livreId);

                    // Exécuter la commande et vérifier s'il y a des résultats
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
        public void SupprimerImageLivre(string nomFichier)
        {
            // Récupérez le chemin du répertoire du projet au moment de l'exécution
            string repertoireProjet = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));

            // Créez le chemin du fichier dans le répertoire "Images" du projet
            string cheminImage = System.IO.Path.Combine(repertoireProjet, "Images", nomFichier);

            // Assurez-vous que le fichier existe avant de le supprimer
            if (System.IO.File.Exists(cheminImage))
            {
                try
                {
                    // Assurez-vous que toutes les références au fichier sont fermées
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    // Supprimez le fichier image
                    System.IO.File.Delete(cheminImage);
                }
                catch (Exception ex)
                {
                    // Gérez l'exception (par exemple, loguez l'erreur)
                    Console.WriteLine($"Erreur lors de la suppression du fichier : {ex.Message}");
                }
            }
        }

        //EN SUPPRIMANT LA CONFIRMATION
        public bool ConfirmerSuppressionLivre()
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer ce livre ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

            return result == MessageBoxResult.Yes;
        }

        /*
        //MODIFIER
        public bool ModifierLivre(int livreId, string titre, DateTime datePublication, bool disponible)
        {
            string query = "UPDATE livre SET TITRE = @Titre, DATE_PUBLICATION = @DatePublication, DISPONIBLE = @Disponible WHERE LIVRE_ID = @LivreId";
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titre", titre);
                    command.Parameters.AddWithValue("@DatePublication", datePublication);
                    command.Parameters.AddWithValue("@Disponible", disponible);
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
        public Livre GetLivreById(int livreId)
        {
            // Remplacez cela par votre logique pour obtenir les détails du livre par ID
            // Assurez-vous de retourner une instance de Livre ou null si non trouvé
            // Exemple :
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM livre WHERE LIVRE_ID = @LivreId";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LivreId", livreId);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Livre livre = new Livre
                            {
                                LIVRE_ID = reader.GetInt32(reader.GetOrdinal("LIVRE_ID")),
                                TITRE = reader.GetString(reader.GetOrdinal("TITRE")),
                                DISPONIBLE = reader.GetBoolean(reader.GetOrdinal("DISPONIBLE"))
                            };
                            return livre;
                        }
                        return null;
                    }
                }
            }
        }

        */


        /*
        public bool ModifierLivre(int livreId, string titre, DateTime datePublication, bool disponible)
        {
            string query = "UPDATE livre SET TITRE = @Titre, DATE_PUBLICATION = @DatePublication, DISPONIBLE = @Disponible WHERE LIVRE_ID = @LivreId";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Titre", titre);
                    command.Parameters.AddWithValue("@DatePublication", datePublication);
                    command.Parameters.AddWithValue("@Disponible", disponible);

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
        */

        public bool ModifierLivre(int livreId, string titre, DateTime datePublication, bool disponible)
        {
            string query = "UPDATE livre SET TITRE = @Titre, DATE_PUBLICATION = @DatePublication, DISPONIBLE = @Disponible WHERE LIVRE_ID = @LivreId";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Titre", titre);
                            command.Parameters.AddWithValue("@DatePublication", datePublication);
                            command.Parameters.AddWithValue("@Disponible", disponible);
                            command.Parameters.AddWithValue("@LivreId", livreId);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                return true;
                            }
                            else
                            {
                                transaction.Rollback();
                                return false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Erreur lors de la modification : " + ex.ToString());
                        return false;
                    }
                }
            }
        }
    }
}
