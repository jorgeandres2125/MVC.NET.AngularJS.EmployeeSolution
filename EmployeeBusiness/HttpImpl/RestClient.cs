using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBusiness.HttpImpl
{
    public class RestClient
    {
        private JArray jsonEmployees;
        private string urlClient;
        public RestClient(string url)
        {
            urlClient = url;
        }

        public async Task RecuestEmployees()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                var stringTask = client.GetStringAsync(urlClient);
                var msgResponse = await stringTask;
                jsonEmployees = (JArray)JsonConvert.DeserializeObject(msgResponse);
            }
        }

        public JArray getJsonEmployees() {
            return jsonEmployees;
        }
    }
}
