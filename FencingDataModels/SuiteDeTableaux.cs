using System;
using System.Collections.Generic;
using System.Text;

namespace FencingDataModels
{
    public class SuiteDeTableaux
    {
        //<SuiteDeTableaux ID="SuiteTab_A" NbDeTableaux="5" Lettre="A" Titre="Main tableau of 32">
        public string ID { get; set; }

        public string NbDeTableaux { get; set; }

        public string Lettre { get; set; }

        public string Titre { get; set; }
        public List<Tableau> tableaus { get; set; }
    }
}
