using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlPageParser
{
    public class ParsePage
    {

        public List<List<KeyValuePair<string, string>>> getTableFromUrl(string pageUrl, string tableXPath)
        {
            HtmlDocument htmlDocument = getHtmlDocument(pageUrl);
            return getTable(htmlDocument, tableXPath);
        }

        public HtmlDocument getHtmlDocument(string pageURL)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = web.Load(pageURL);
            var parseErrors = htmlDoc.ParseErrors;

            if (parseErrors != null && parseErrors.Count() > 0)
            {
                // Handle any parse errors as required
                Console.WriteLine("Parse error");
                foreach (HtmlParseError parseError in htmlDoc.ParseErrors)
                {
                    Console.WriteLine("PARSE ERROR: " + parseError.Code.ToString());
                }

            }

            if (htmlDoc.DocumentNode == null)
            {
                return null;
            }

            return htmlDoc;
        }

        public List<List<KeyValuePair<string, string>>> getTable(HtmlDocument htmlDocument, string tableXPath)
        {
            List<List<KeyValuePair<string, string>>> searializedTable = new List<List<KeyValuePair<string, string>>>();
            var table = htmlDocument.DocumentNode.SelectSingleNode(tableXPath);
            var tableRows = table.SelectNodes("tr");
            var columns = tableRows[0].SelectNodes("th/text()");

            // handle the case where the table header txt is inside a link tag
            var acolums = tableRows[0].SelectNodes("th/a/text()");

            // appending as the current behavior that the columns with a link are the last columns in the table
            if (null != acolums)
            {
                for (int aIndex = 0; aIndex < acolums.Count; aIndex++) { columns.Append(acolums[aIndex]); }
            }

            for (int i = 1; i < tableRows.Count; i++)
            {
                List<KeyValuePair<string, string>> rowkeyvalue = new List<KeyValuePair<string, string>>();

                for (int e = 0; e < columns.Count; e++)
                {
                    var value = tableRows[i].SelectSingleNode($"td[{e + 1}]");
                    //Console.Write(columns[e].InnerText + ":" + value.InnerText);
                    if (!String.IsNullOrEmpty(columns[e].InnerText))
                    {
                        rowkeyvalue.Add(new KeyValuePair<string, string>(columns[e].InnerText.Trim(), value.InnerText.Trim()));
                    }
                    else
                    {
                        rowkeyvalue.Add(new KeyValuePair<string, string>(columns[e].GetDirectInnerText(), value.InnerText.Trim()));
                    }
                }

                searializedTable.Add(rowkeyvalue);
            }
            return searializedTable;
        }

    }
}
