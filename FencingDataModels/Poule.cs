using System;
using System.Collections.Generic;
using System.Text;

namespace FencingDataModels
{
    public class Poule
    {
        //public string Piste="1" Date="14.07.2019" Heure="09:00" Statut="O">
        public string ID { get; set; }

        public string Piste { get; set; }

        public string Date { get; set; }

        public string Heure { get; set; }

        public string Statut { get; set; }
       
        public List<Match> pouleMatches { get; set; }
    }
}
