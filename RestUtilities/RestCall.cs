using RestSharp;


namespace RestUtilities
{
    public class RestCall
    {

        public string doPost(string requestUrl, object body)
        {
            var client = new RestClient(requestUrl);

            var request = new RestRequest(requestUrl, Method.POST);

            request.RequestFormat = DataFormat.Json;

            request.AddHeader("accept", "application/json");

            request.AddJsonBody(body);

            // execute the request
            IRestResponse response = client.Execute(request);

            System.Console.WriteLine("response code: " + response.StatusCode);

            var content = response.Content; // raw content as string

            return content;
        }

        public string doGet(string requestUrl)
        {
            var client = new RestClient(requestUrl);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest(requestUrl, Method.GET);

            // execute the request
            IRestResponse response = client.Execute(request);

            System.Console.WriteLine("response code: " + response.StatusCode);

            var content = response.Content; // raw content as string

            return content;
        }
    }
}
