namespace ConsoleApplication1
{
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    public class Startup
    {
        private const string Url = @"http://api.feedzilla.com";

        static void Main()
        {
            var webClient = new WebClient();
            ConsumePublicApi(webClient, Url, "/v1/categories.json");

        }

        static void ConsumePublicApi(WebClient client, string address, string query)
        {
            var result = client.DownloadString(address + query);

            var response = JsonConvert.DeserializeObject(result);



        }
    }
}
