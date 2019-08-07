using System.Runtime.Serialization;

namespace FencingDataModels
{
    public class RankingModel
    {
        //key: Rank value: 1 key: Name value: Garelja, Daniel key: Num of Comps value: 5 
        // key: Rank value: 1 key: Name value: Garelja, Daniel key: Num of Comps value: 5 key: Total Points value: 806 key: Avg Points value: 161 

        [DataMember]
        public int Rank;

        [DataMember]
        public string Name;

        [DataMember]
        public int NumOfComps;

        [DataMember]
        public int TotalPoints;

        [DataMember]
        public int AveragePoints;

        [DataMember]
        public string RankingDate;

        [DataMember]
        public string Weapon;

        [DataMember]
        public string Category;

        [DataMember]
        public string Sex;
    }
}
