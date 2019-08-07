using FencingDataModels;
using RestUtilities;
using System;
using System.Collections.Generic;

namespace FencingResultsIntoElasticsearch
{
    class Program
    {
        public static string indexName = "fencerranking";

        static void Main(string[] args)
        {

            foreach (string weapon in Enum.GetNames(typeof(Weapons)))
            {
                foreach (string sex in Enum.GetNames(typeof(Sex)))
                {
                    foreach (string category in Enum.GetNames(typeof(Category)))
                    {
                        getRankingPushToElastic(weapon, sex, category);
                    }
                }

            }
        }
        private static void getRankingPushToElastic(string weapon, string sex, string category)
        {
            TransformRankingResults transformRankingResults = new TransformRankingResults();

            List<RankingModel> serializedRankingList = transformRankingResults.getRankingsSerialize(weapon, sex, category);

            foreach (RankingModel serializedRanking in serializedRankingList)
            {
                pushToElastic(serializedRanking);
            }
        }

        public static void pushToElastic(RankingModel serializedRanking)
        {
            ElasticsearchUrlHelper elasticsearchUrlHelper = new ElasticsearchUrlHelper(indexName);

            RestCall restCall = new RestCall();

            string url = elasticsearchUrlHelper.getElasticsearchUrl();

            Console.WriteLine(restCall.doPost(url, serializedRanking));

        }
    }
}
