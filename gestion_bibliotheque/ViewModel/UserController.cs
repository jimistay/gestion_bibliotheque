using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_bibliotheque.ViewModel
{
    internal class UserController
    {
        public UserController()
        {
        }

        public static bool Connexion(string USER, string MDP)
        {
            string connectionString = "server=localhost;database=vva;uid=root;pwd=;";

            string query = "SELECT * FROM Compte WHERE USER = @User AND MDP = @Password AND DATEFERME > CURDATE()";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@User", USER);
                command.Parameters.AddWithValue("@Password", MDP);

                try
                {
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string typeCompte = reader["TYPECOMPTE"].ToString();

                            if (typeCompte == "adm")
                            {
                                return true; 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }

            return false; // Mot de passe incorrect, TYPECOMPTE n'est pas "adm", ou DATEFERME n'est pas inférieur à aujourd'hui
        }
    }
}
