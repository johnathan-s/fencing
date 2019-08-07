using System;
using System.Text;

namespace FencingResultsIntoElasticsearch
{
    public class ElasticsearchUrlHelper
    {
        private string elasticsearchUrl;
        public ElasticsearchUrlHelper(string indexName)
        {
            setElasicsearchUrl(indexName);
        }


        public void setElasicsearchUrl(string indexName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("http://localhost:9200/")
                .Append(indexName)
                .Append("/_doc/")
                .Append(Guid.NewGuid().ToString());
            this.elasticsearchUrl = sb.ToString();
        }

        public string getElasticsearchUrl()
        {
            return this.elasticsearchUrl;
        }
    }
}
