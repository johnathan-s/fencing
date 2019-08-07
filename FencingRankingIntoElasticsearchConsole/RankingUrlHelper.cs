using System;
using System.Collections.Generic;
using System.Text;

namespace FencingRankingIntoElasticsearchConsole
{
    public class RankingUrlHelper
    {
        private string baseUrl = "https://fencing.nz/rankings.php?weapon=|weapon|&sex=|sex|&cat=|category|&submit=Get+Ranking";
        private string rankingUrl;

        public RankingUrlHelper(Weapons weapon, Sex sex, Category category)
        {
            setRankingUrl(weapon, sex, category);
        }

        public string getRankingUrl()
        {
            return this.rankingUrl;
        }

        public void setRankingUrl(Weapons weapon, Sex sex, Category category)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.baseUrl);
            sb.Replace("|weapon|", Enum.GetName(typeof(Weapons), weapon))
                .Replace("|sex|", Enum.GetName(typeof(Sex), sex))
                .Replace("|category|", Enum.GetName(typeof(Category), category));
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
