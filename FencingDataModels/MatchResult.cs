using System;
using System.Collections.Generic;
using System.Text;

namespace FencingDataModels
{
    public class MatchResult
    {
        //<Tireur REF = "-27" Score="5" Statut="V" />
        public string REF { get; set; }

        public string Score { get; set; }

        public string Statut { get; set; }
    }
}
