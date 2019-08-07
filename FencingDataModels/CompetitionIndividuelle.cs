using System.Runtime.Serialization;

namespace FencingDataModels
{
    public class CompetitionIndividuelle
    {
        //<CompetitionIndividuelle Version = "3.3" Championnat="FNZ" ID="" Annee="2018/2019" Arme="E" Sexe="M" Domaine="N" Federation="NZL" 
        //Organisateur="Mid South" Categorie="S" Date="14.07.2019" TitreLong="Presidents Cup 2019" DateFichierXML="14.07.2019 02:45">

        [DataMember]
        public string Version;

        [DataMember]
        public string Championnat;

        [DataMember]
        public string ID;

        [DataMember]
        public string Annee;

        [DataMember]
        public string Arme;

        [DataMember]
        public string Sexe;

        [DataMember]
        public string Domaine;

        [DataMember]
        public string Federation;

        [DataMember]
        public string Organisateur;

        [DataMember]
        public string Categorie;

        [DataMember]
        public string Date;

        [DataMember]
        public string TitreLong;

        [DataMember]
        public string DateFichierXML;
    }
}
