using RestSharp;
using System.Diagnostics;

namespace RestUtilities
{
    public class RestCall : IRestCall
    {
        private RestClient client;
        private string requestUrl;

        public RestCall(string url)
        {
            requestUrl = url;
            client = new RestClient(url);
        }

        public string DoPost(object body)
        {
            var request = new RestRequest(requestUrl, Method.POST);

            request.RequestFormat = DataFormat.Json;

            request.AddHeader("accept", "application/json");

            request.AddJsonBody(body);

            // execute the request
            IRestResponse response = client.Execute(request);

            Debug.WriteLine("response code: " + response.StatusCode);

            return response.Content; // raw content as string
        }

        public string DoGet()
        {
            var request = new RestRequest(requestUrl, Method.GET);

            IRestResponse response = client.Execute(request);

            Debug.WriteLine("response code: " + response.StatusCode);

            return response.Content; // raw content as string
        }

    }
}
