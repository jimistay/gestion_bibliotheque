using gestion_bibliotheque.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_bibliotheque.ViewModel
{
    internal class CompteController
    {
        private const string ConnectionString = "server=localhost;database=vva;uid=root;pwd=;";

        //Location 
        public ObservableCollection<Compte> GetUtilisateurs()
        {
            ObservableCollection<Compte> utilisateurs = new ObservableCollection<Compte>();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM compte";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Compte utilisateur = new Compte
                            {
                                USER = reader.GetString("USER"),
                                MDP = reader.GetString("MDP"),
                                NOMCPTE = reader.GetString("NOMCPTE"),
                            };
                            utilisateurs.Add(utilisateur);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de la récupération des utilisateurs : " + ex.Message);
                }
            }

            return utilisateurs;
        }


    }
}
