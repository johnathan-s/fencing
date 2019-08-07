using FencingDataModels;
using HtmlPageParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace FencingResultsIntoElasticsearch
{
    public class TransformRankingResults
    {
        private string tableXPath = "//td[@class='centerboxtext']/table";

        private ParsePage parsePage = new ParsePage();

        public List<List<KeyValuePair<string, string>>> getRankings(string weapon, string sex, string category)
        {
            RankingUrlHelper rankingUrlHelper = new RankingUrlHelper(weapon, sex, category);

            string url = rankingUrlHelper.getRankingUrl();

            return this.parsePage.getTableFromUrl(url, tableXPath);
        }

        public List<RankingModel> transformRankingsSerialized(List<List<KeyValuePair<string, string>>> tableRankings, string weapon, string sex, string category)
        {
            List<RankingModel> rankingModelList = new List<RankingModel>();

            // key: Rank value: 1 key: Name value: Garelja, Daniel key: Num of Comps value: 5 key: Total Points value: 806 key: Avg Points value: 161

            foreach (List<KeyValuePair<string, string>> rankingrow in tableRankings)
            {
                RankingModel rankingModel = new RankingModel();

                rankingModel.Weapon = weapon.ToLower();
                rankingModel.Category = category.ToLower();
                rankingModel.Sex = sex.ToLower();
                rankingModel.RankingDate = DateTime.Today.ToString("yyyy-MM-dd");

                foreach (KeyValuePair<string, string> rowCell in rankingrow)
                {

                    switch (rowCell.Key)
                    {
                        case "Rank":
                            rankingModel.Rank = int.Parse(rowCell.Value);
                            break;
                        case "Name":
                            rankingModel.Name = rowCell.Value.ToLower().Replace(",", "");
                            break;
                        case "Num of Comps":
                            rankingModel.NumOfComps = int.Parse(rowCell.Value);
                            break;
                        case "Total Points":
                            rankingModel.TotalPoints = int.Parse(rowCell.Value);
                            break;
                        case "Avg Points":
                            rankingModel.AveragePoints = int.Parse(rowCell.Value);
                            break;
                        default:
                            throw new Exception("unknown key found " + rowCell.Key);
                    }
                }
                rankingModelList.Add(rankingModel);
            }
            return rankingModelList;
        }

        public string serializeRankingModel(RankingModel rankingModel)
        {
            var stream1 = new MemoryStream();

            var ser = new DataContractJsonSerializer(typeof(RankingModel));

            ser.WriteObject(stream1, rankingModel);

            stream1.Position = 0;

            var sr = new StreamReader(stream1);

            string serializedResult = sr.ReadToEnd();

            sr.Close();

            sr.Dispose();

            return serializedResult;
        }

        public List<RankingModel> getRankingsSerialize(string weapon, string sex, string category)
        {
            List<List<KeyValuePair<string, string>>> serializedTable = getRankings(weapon, sex, category);

            return transformRankingsSerialized(serializedTable, weapon, sex, category);
        }
    }
}
