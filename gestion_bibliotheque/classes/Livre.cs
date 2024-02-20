using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace gestion_bibliotheque.classes
{
    public class Livre 
    {
        public int LIVRE_ID { get; set; }
        public string TITRE { get; set; }
        public DateTime DATE_PUBLICATION { get; set; }
        public bool DISPONIBLE { get; set; }
        public string COUVERTURE { get; set; }
        public int GENRE_ID { get; set; }
        public int AUTEUR_ID { get; set; }
        public int EDITION_ID { get; set; }
        public string CouvertureImage { get; set; }

    }
}
