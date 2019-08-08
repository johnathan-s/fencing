using System;
using System.Collections.Generic;
using System.Text;

namespace FencingDataModels
{
    public class Match
    {
        public string ID { get; set; }
        public List<MatchResult> matchResults{ get; set; }
    }
}
