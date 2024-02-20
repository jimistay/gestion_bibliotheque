using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_bibliotheque.classes
{
    internal class Compte
    {
        public string USER { get; set; }
        public string MDP { get; set; }
        public string NOMCPTE { get; set; }
        public string PRENOMCPTE { get; set; }
        public string DATEINSCRIP { get; set; }
        public string DATEFERME { get; set; }
        public string TYPECOMPTE { get; set; }
    }
}
