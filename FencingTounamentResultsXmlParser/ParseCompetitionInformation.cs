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
    public class ParseCompetitionInformation : ParseTournamentResultsBase
    {
        public ParseCompetitionInformation(string filepath) : base(filepath)
        {

        }

        public CompetitionIndividuelle getCompetitionIndividuelle()
        {
            var xAttributes = xdoc.Attributes();

            CompetitionIndividuelle competitionIndividuelle = new CompetitionIndividuelle();

            foreach (XAttribute attribute in xAttributes)
            {
                switch (attribute.Name.ToString())
                {
                    case "Annee":
                        competitionIndividuelle.Annee = attribute.Value;
                        break;
                    case "Arme":
                        competitionIndividuelle.Arme = attribute.Value;
                        break;
                    case "Categorie":
                        competitionIndividuelle.Categorie = attribute.Value;
                        break;
                    case "Championnat":
                        competitionIndividuelle.Championnat = attribute.Value;
                        break;
                    case "Date":
                        competitionIndividuelle.Date = attribute.Value;
                        break;
                    case "DateFichierXML":
                        competitionIndividuelle.DateFichierXML = attribute.Value;
                        break;
                    case "Domaine":
                        competitionIndividuelle.Domaine = attribute.Value;
                        break;
                    case "Federation":
                        competitionIndividuelle.Federation = attribute.Value;
                        break;
                    case "ID":
                        competitionIndividuelle.ID = attribute.Value;
                        break;
                    case "Organisateur":
                        competitionIndividuelle.Organisateur = attribute.Value;
                        break;
                    case "Sexe":
                        competitionIndividuelle.Sexe = attribute.Value;
                        break;
                    case "TitreLong":
                        competitionIndividuelle.TitreLong = attribute.Value;
                        break;
                    case "Version":
                        competitionIndividuelle.Version = attribute.Value;
                        break;
                    default:
                        throw new Exception("unknown key found " + attribute.Name);
                }
            }

            return competitionIndividuelle;
        }
    }
}
