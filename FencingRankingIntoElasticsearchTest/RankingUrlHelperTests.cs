using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FencingRankingIntoElasticsearchConsole;

namespace FencingRankingIntoElasticsearchConsoleTest
{
    [TestClass]
    public class RankingUrlHelperTests
    {
        

        [TestMethod]
        public void ConstructorTest1()
        {
            RankingUrlHelper rankingUrlHelper = new RankingUrlHelper(Weapons.Epee, Sex.Mens, Category.open);
    }
    }
}
