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
    public class ParseTableauMatches : ParseTournamentResultsBase
    {
        public ParseTableauMatches(string filepath) : base(filepath)
        {
        }

        public List<SuiteDeTableaux> getSuiteDeTableauxMatches()
        {
            List<SuiteDeTableaux> suiteDeTableauxes= new List<SuiteDeTableaux>();

            foreach (XElement xSuiteDeTableaux in getSuiteDeTableaux())
            {
                SuiteDeTableaux suiteDeTableaux = new SuiteDeTableaux();
                suiteDeTableaux.ID              = xSuiteDeTableaux.Attribute("ID").Value;
                suiteDeTableaux.Lettre          = xSuiteDeTableaux.Attribute("Lettre").Value;
                suiteDeTableaux.NbDeTableaux    = xSuiteDeTableaux.Attribute("NbDeTableaux").Value;
                suiteDeTableaux.Titre           = xSuiteDeTableaux.Attribute("Titre").Value;

                suiteDeTableaux.tableaus        = new List<Tableau>();

                foreach(XElement xTableau in getTableaus(xSuiteDeTableaux))
                {
                    Tableau tableau     = new Tableau();
                    tableau.ID          = xTableau.Attribute("ID").Value;
                    tableau.Taille      = xTableau.Attribute("Taille").Value;
                    tableau.Titre       = xTableau.Attribute("Titre").Value;
                    tableau.matches     = new List<Match>();

                    foreach (XElement xMatch in getMatches(xTableau))
                    {
                        Match match = new Match();
                        match.ID = xMatch.Attribute("ID").ToString();
                        match.matchResults = new List<MatchResult>();

                        foreach (XElement xMatchResult in getMatchResults(xMatch))
                        {
                            MatchResult matchResult     = new MatchResult();
                            matchResult.REF             = xMatchResult.Attribute("REF").Value;
                            matchResult.Score           = xMatchResult.Attribute("Score").Value;
                            matchResult.Statut          = xMatchResult.Attribute("Statut").Value;
                            match.matchResults.Add(matchResult);
                        }
                        tableau.matches.Add(match);
                    }
                    suiteDeTableaux.tableaus.Add(tableau);
                }
                suiteDeTableauxes.Add(suiteDeTableaux);
            }
            return suiteDeTableauxes;
        }

        public IEnumerable<XElement> getSuiteDeTableaux()
        {
            return getxElementsFromRoot("SuiteDeTableaux");
        }

        public IEnumerable<XElement> getTableaus(XElement xSuiteDeTableaux)
        {
            return getxElementsFromxElement(xSuiteDeTableaux, "Tableau");
        }

        public IEnumerable<XElement> getMatches(XElement xTableau)
        {
            return getxElementsFromxElement(xTableau, "Match");
        }

        public IEnumerable<XElement> getMatchResults(XElement match)
        {
            return getxElementsFromxElement(match, "Tireur");
        }
    }
}
