using System;
using System.Runtime.Serialization;

namespace FencingDataModels
{
    [DataContract]
    public class TournamentMatchModel
    {
        [DataMember]
        public string TournamentName { get; set; }

        [DataMember]
        public DateTime TournamentDate { get; set; }

        [DataMember]
        public string matchType { get; set; }

        [DataMember]
        public string matchId { get; set; }

        [DataMember]
        public string matchTitle { get; set; }

        [DataMember]
        public string rightSurname { get; set; }

        [DataMember]
        public string rightProname { get; set; }

        [DataMember]
        public int rightScore { get; set; }

        [DataMember]
        public string rightStatus { get; set; }

        [DataMember]
        public string leftSurname { get; set; }

        [DataMember]
        public string leftProname { get; set; }

        [DataMember]
        public int leftScore { get; set; }

        [DataMember]
        public string leftStatus { get; set; }

    }
}
