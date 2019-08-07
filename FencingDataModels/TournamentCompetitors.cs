using System.Runtime.Serialization;

namespace FencingDataModels
{
    public class TournamentCompetitors
    {
        //<Tireur ID = "-1" Nom="AGUILAR" Prenom="Gio" DateNaissance="29.11.2001" Sexe="M" Lateralite="D"
        //Nation="NZL" Club="Mount Albert Grammar School Epee Fencing" Ligue="" Licence="20497" Classement="5" />

        [DataMember]
        public string ID;

        [DataMember]
        public string Nom;

        [DataMember]
        public string Prenom;

        [DataMember]
        public string DateNaissance;

        [DataMember]
        public string Sexe;

        [DataMember]
        public string Lateralite;

        [DataMember]
        public string Nation;

        [DataMember]
        public string Club;

        [DataMember]
        public string Ligue;

        [DataMember]
        public string Licence;

        [DataMember]
        public string Classement;
    }
}
