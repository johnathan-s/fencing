using System;
using System.Text;

namespace FencingResultsIntoElasticsearch
{
    public class RankingUrlHelper
    {
        private string baseUrl = "https://fencing.nz/rankings.php?weapon=|weapon|&sex=|sex|&cat=|category|&submit=Get+Ranking";
        private string rankingUrl;

        public RankingUrlHelper(Weapons weapon, Sex sex, Category category)
        {
            setRankingUrl(Enum.GetName(typeof(Weapons), weapon), Enum.GetName(typeof(Sex), sex), Enum.GetName(typeof(Category), category));
        }

        public RankingUrlHelper(string weapon, string sex, string category)
        {
            setRankingUrl(weapon, sex, category);
        }

        public string getRankingUrl()
        {
            return this.rankingUrl;
        }

        public void setRankingUrl(string weapon, string sex, string category)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.baseUrl);
            sb.Replace("|weapon|", weapon)
                .Replace("|sex|", sex)
                .Replace("|category|", category);
            this.rankingUrl = sb.ToString();
            return;
        }

    }

    public enum Weapons
    {
        Foil,
        Epee,
        Sabre
    }

    public enum Sex
    {
        Mens,
        Womens
    }

    public enum Category
    {
        open,
        u23,
        u20,
        sch,
        u17,
        u15,
        vet
    }
}

