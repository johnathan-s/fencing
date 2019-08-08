using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using FencingDataModels;

namespace FencingTournamentResultsXmlParser
{
    public class ParsePouleMatches : ParseTournamentResultsBase
    {
        public ParsePouleMatches(string filepath) : base(filepath)
        {
        }

        public List<Poule> getPouleMatches()
        {
            List<Poule> poules = new List<Poule>();

            foreach(XElement xPoule in getPoules())
            {
                Poule poule         = new Poule();
                poule.ID            = xPoule.Attribute("ID").ToString();
                poule.Date          = xPoule.Attribute("Date").ToString();
                poule.Heure         = xPoule.Attribute("Heure").ToString();
                poule.Piste         = xPoule.Attribute("Piste").ToString();
                poule.Statut        = xPoule.Attribute("Statut").ToString();
                poule.pouleMatches  = new List<Match>();

                foreach(XElement xMatch in getMatches(xPoule))
                {
                    Match match = new Match();
                    match.ID = xMatch.Attribute("ID").ToString();
                    match.matchResults = new List<MatchResult>();

                    foreach(XElement xMatchResult in getMatchResults(xMatch))
                    {
                        MatchResult matchResult = new MatchResult();
                        matchResult.REF     = xMatchResult.Attribute("REF").ToString();
                        matchResult.Score   = xMatchResult.Attribute("Score").ToString();
                        matchResult.Statut  = xMatchResult.Attribute("Statut").ToString();
                        match.matchResults.Add(matchResult);
                    }
                    poule.pouleMatches.Add(match);
                }
                poules.Add(poule);
            }
            return poules;
        }

        public IEnumerable<XElement> getPoules()
        {
            IEnumerable<XElement> xPoules =
                from el in xdoc.Descendants("Poule")
                select el;
            return xPoules;
        }

        public IEnumerable<XElement> getMatches(XElement poule)
        {
            IEnumerable<XElement> xMatches =
                from el in poule.Descendants("Match")
                select el;
            return xMatches;
        }

        public IEnumerable<XElement> getMatchResults(XElement match)
        {
            IEnumerable<XElement> xMatcheResults =
                from el in match.Descendants("Tireur")
                select el;
            return xMatcheResults;
        }
    }
}
