using EazyTips.Repository;
using Newtonsoft.Json;
using System;
using System.Dynamic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EazyTips.RestClient
{
    public class RestClient<T>
    {
        private string Url = "http://9a408c439104.ngrok.io";

        public async Task<int> checkLogin(string _phone, string _password)
        {
            Url += "/api/user/login";
            HttpClient client = new HttpClient();

            var JsonData = new
            {
                phone = _phone,
                password = _password
            };
            string jsonData = JsonConvert.SerializeObject(JsonData);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(Url, content);
            int id = Convert.ToInt32(await response.Content.ReadAsStringAsync());
            return id;
        }

        public async Task<bool> userRegistration(string _phone, string _password)
        {
            Url += "/api/user/registration";
            HttpClient client = new HttpClient();

            var JsonData = new
            {
                phone = _phone,
                password = _password
            };
            string jsonData = JsonConvert.SerializeObject(JsonData);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(Url, content);
            
            return response.IsSuccessStatusCode;
        }

        public async Task<User> GetUser(int idUser)
        {
            Url += $"/api/user/{idUser}";
            HttpClient client = new HttpClient();

            HttpResponseMessage respnse = await client.GetAsync(Url);

            if(respnse.Content is object && respnse.Content.Headers.ContentType.MediaType == "application/json")
            {
                string contentStream = await respnse.Content.ReadAsStringAsync();
                StreamReader streamReader = new StreamReader(contentStream);
                JsonTextReader textReader = new JsonTextReader(streamReader);
                JsonSerializer jsonSerializer = new JsonSerializer();

                try
                {
                    return jsonSerializer.Deserialize<User>(textReader);
                }
                catch (JsonReaderException)
                {
                    throw;
                }
            }

            return null;
        }
    }
}
