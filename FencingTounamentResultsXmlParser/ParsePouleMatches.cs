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
                poule.ID            = xPoule.Attribute("ID").Value;
                poule.Date          = xPoule.Attribute("Date").Value;
                poule.Heure         = xPoule.Attribute("Heure").Value;
                poule.Piste         = xPoule.Attribute("Piste").Value;
                poule.Statut        = xPoule.Attribute("Statut").Value;
                poule.pouleMatches  = new List<Match>();

                foreach(XElement xMatch in getMatches(xPoule))
                {
                    Match match = new Match();
                    match.ID = xMatch.Attribute("ID").Value;
                    match.matchResults = new List<MatchResult>();

                    foreach(XElement xMatchResult in getMatchResults(xMatch))
                    {
                        MatchResult matchResult = new MatchResult();
                        matchResult.REF     = xMatchResult.Attribute("REF").Value;
                        matchResult.Score   = xMatchResult.Attribute("Score").Value;
                        matchResult.Statut  = xMatchResult.Attribute("Statut").Value;
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
            return getxElementsFromRoot("Poule");
        }

        public IEnumerable<XElement> getMatches(XElement poule)
        {
            return getxElementsFromxElement(poule, "Match");
        }

        public IEnumerable<XElement> getMatchResults(XElement match)
        {
            return getxElementsFromxElement(match, "Tireur");
        }
    }
}
