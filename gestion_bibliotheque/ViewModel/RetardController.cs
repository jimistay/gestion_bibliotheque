using MySql.Data.MySqlClient;
using gestion_bibliotheque.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_bibliotheque.ViewModel
{
    
    internal class RetardController
    {
        private const string ConnectionString = "server=localhost;database=vva;uid=root;pwd=";
        public ObservableCollection<Location> GetRetards()
        {
            ObservableCollection<Location> retards = new ObservableCollection<Location>();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                // Requête SQL pour récupérer les enregistrements avec DATE_R_REELLE non nulle et DATE_R_ATTENDUE supérieure à aujourd'hui
                string query = "SELECT * FROM location_livre WHERE DATE_R_REELLE IS NULL AND DATE_R_ATTENDUE < CURDATE()";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Location retard = new Location
                            {
                                LOCATION_ID = Convert.ToInt32(reader["LOCATION_ID"]),
                                DATE_LOCATION = Convert.ToDateTime(reader["DATE_LOCATION"]),
                                DATE_R_ATTENDUE = Convert.ToDateTime(reader["DATE_R_ATTENDUE"]),
                                LIVRE_ID = reader["LIVRE_ID"].ToString(),
                                USER = reader["USER"].ToString(),
                                DATE_R_REELLE = reader["DATE_R_REELLE"] != DBNull.Value ? (DateTime?)reader["DATE_R_REELLE"] : null
                            };

                            retards.Add(retard);
                        }
                    }
                }
            }

            return retards;
        }

       

    }

}
