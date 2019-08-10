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

                tournamentCompetitor.Classement = tournamentCompetitorInst.Attribute("Classement").Value;
                tournamentCompetitor.Club = tournamentCompetitorInst.Attribute("Club").Value;
                tournamentCompetitor.DateNaissance = tournamentCompetitorInst.Attribute("DateNaissance").Value;
                tournamentCompetitor.ID = tournamentCompetitorInst.Attribute("ID").Value;
                tournamentCompetitor.Lateralite = tournamentCompetitorInst.Attribute("Lateralite").Value;
                tournamentCompetitor.Licence = tournamentCompetitorInst.Attribute("Licence").Value;
                tournamentCompetitor.Ligue = tournamentCompetitorInst.Attribute("Ligue").Value;
                tournamentCompetitor.Nation = tournamentCompetitorInst.Attribute("Nation").Value;
                tournamentCompetitor.Nom = tournamentCompetitorInst.Attribute("Nom").Value;
                tournamentCompetitor.Prenom = tournamentCompetitorInst.Attribute("Prenom").Value;
                tournamentCompetitor.Sexe = tournamentCompetitorInst.Attribute("Sexe").Value;
                tournamentCompetitorList.Add(tournamentCompetitor);
            }
            return tournamentCompetitorList;
        }
    }
}
