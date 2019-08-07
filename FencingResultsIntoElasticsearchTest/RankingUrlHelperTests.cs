using FencingResultsIntoElasticsearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace FencingResultsIntoElasticsearchTest
{
    [TestClass]
    public class RankingUrlHelperTests
    {
        [TestMethod]
        public void Constructor_ValidteUrlIsCorrectTest()
        {
            RankingUrlHelper rankingUrlHelper = new RankingUrlHelper(Weapons.Epee, Sex.Mens, Category.open);

            string rankingUrl = rankingUrlHelper.getRankingUrl();

            Assert.IsTrue(rankingUrl.Equals("https://fencing.nz/rankings.php?weapon=Epee&sex=Mens&cat=open&submit=Get+Ranking"));
        }

        [TestMethod]
        public void Constructor_ValidateUrlIsCorrectForEachEnumbValueTest()
        {
            foreach (string weapon in Enum.GetNames(typeof(Weapons)))
            {
                foreach (string sex in Enum.GetNames(typeof(Sex)))
                {
                    foreach (string category in Enum.GetNames(typeof(Category)))
                    {
                        RankingUrlHelper rankingUrlHelper = new RankingUrlHelper(weapon, sex, category);

                        string rankingUrl = rankingUrlHelper.getRankingUrl();

                        Console.WriteLine(rankingUrl);

                        Assert.IsTrue(rankingUrl.StartsWith("https://fencing.nz/rankings.php"));
                    }
                }

            }
        }
    }
}
