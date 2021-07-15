using EazyTips.Entetys;
using EazyTips.Repository;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EazyTips.RestClient
{
    public class RestClient<T>
    {
        private string Url = "https://fec9f0077efa.ngrok.io";

        public async Task<int> checkLogin(string _phone, string _password)
        {
            Url += "/api/user/login";
            HttpClient client = new HttpClient();

            var JsonData = new
            {
                phone = _phone,
                password = _password
            };
            int id = -1;
            string jsonData = JsonConvert.SerializeObject(JsonData);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(Url, content);
            if(!response.IsSuccessStatusCode)
            {
                return id;
            }
            id = Convert.ToInt32(await response.Content.ReadAsStringAsync());
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
            User user = null;
            HttpResponseMessage respnse = await client.GetAsync(Url);

            if(respnse.IsSuccessStatusCode)
            {
                user = await respnse.Content.ReadAsAsync<User>();
            }

            return user;
        }

        public async Task<Card> GetCard(int UserId)
        {
            Url += $"/api/card/{UserId}";
            HttpClient client = new HttpClient();
            Card card = null;
            HttpResponseMessage respnse = await client.GetAsync(Url);

            if (respnse.IsSuccessStatusCode)
            {
                card = await respnse.Content.ReadAsAsync<Card>();
            }

            return card;
        }

        public async Task<Marketplace> GetMarketplace(int UserId)
        {
            Url += $"/api/marketplace/{UserId}";
            HttpClient client = new HttpClient();
            Marketplace marketplace = null;
            HttpResponseMessage respnse = await client.GetAsync(Url);

            if (respnse.IsSuccessStatusCode)
            {
                marketplace = await respnse.Content.ReadAsAsync<Marketplace>();
            }

            return marketplace;
        }

        public async Task<Transaction> GetTransaction(int UserId)
        {
            Url += $"/api/transaction/{UserId}";
            HttpClient client = new HttpClient();
            Transaction transaction = null;
            HttpResponseMessage respnse = await client.GetAsync(Url);

            if (respnse.IsSuccessStatusCode)
            {
                transaction = await respnse.Content.ReadAsAsync<Transaction>();
            }

            return transaction;
        }
    }
}
