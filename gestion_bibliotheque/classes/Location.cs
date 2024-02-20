using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_bibliotheque.classes
{
    public class Location 
    {
        public int LOCATION_ID { get; set; }
        public  DateTime DATE_LOCATION { get; set; }
        public  DateTime DATE_R_ATTENDUE { get; set; }
        public  DateTime? DATE_R_REELLE { get; set; }
        public string USER { get; set; }
        public string LIVRE_ID { get; set; }


        // le nombre de jours de retard
        public int JoursRetard
        {
            get
            {
                if (DATE_R_REELLE == null && DATE_R_ATTENDUE < DateTime.Today)
                {
                    // la différence avec DATE_R_ATTENDUE
                    TimeSpan difference = DateTime.Today - DATE_R_ATTENDUE;
                    return difference.Days;
                }
                else
                {
                    return 0;
                }
            }
        }
        
    }
}
