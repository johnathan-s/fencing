using System;
using System.Collections.Generic;
using System.Text;

namespace FencingDataModels
{
    public class Tableau
    {
        //<Tableau ID="A32" Titre="Tableau of 32" Taille="32">
        public string ID { get; set; }

        public string Taille { get; set; }

        public string Titre { get; set; }

        public List<Match> matches { get; set; }
    }
}
