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
    public class ParseTournamentCompetitors : ParseTournamentResultsBase
    {
        public ParseTournamentCompetitors(string filepath) : base(filepath)
        {

        }


        public List<TournamentCompetitors> getTournamentCompetitors()
        {
            List<TournamentCompetitors> tournamentCompetitorList = new List<TournamentCompetitors>();

            IEnumerable<XElement> tournamentCompetitorXElementList =
                from el in xdoc.Descendants("Tireur")
                where (string)el.Attribute("Nom") != null
                select el;

            foreach (XElement tournamentCompetitorInst in tournamentCompetitorXElementList)
            {
                TournamentCompetitors tournamentCompetitor = new TournamentCompetitors();

                foreach (XAttribute attribute in tournamentCompetitorInst.Attributes())
                {
                    switch (attribute.Name.ToString())
                    {
                        case "Classement":
                            tournamentCompetitor.Classement = attribute.Value;
                            break;
                        case "Club":
                            tournamentCompetitor.Club = attribute.Value;
                            break;
                        case "DateNaissance":
                            tournamentCompetitor.DateNaissance = attribute.Value;
                            break;
                        case "ID":
                            tournamentCompetitor.ID = attribute.Value;
                            break;
                        case "Lateralite":
                            tournamentCompetitor.Lateralite = attribute.Value;
                            break;
                        case "Licence":
                            tournamentCompetitor.Licence = attribute.Value;
                            break;
                        case "Ligue":
                            tournamentCompetitor.Ligue = attribute.Value;
                            break;
                        case "Nation":
                            tournamentCompetitor.Nation = attribute.Value;
                            break;
                        case "Nom":
                            tournamentCompetitor.Nom = attribute.Value;
                            break;
                        case "Prenom":
                            tournamentCompetitor.Prenom = attribute.Value;
                            break;
                        case "Sexe":
                            tournamentCompetitor.Sexe = attribute.Value;
                            break;
                        default:
                            throw new Exception("unknown key found " + attribute.Name);
                    }

                }
                tournamentCompetitorList.Add(tournamentCompetitor);
            }

            return tournamentCompetitorList;
        }
    }
}
