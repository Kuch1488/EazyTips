using EazyTips.Entetys;
using EazyTips.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EazyTips.RestClient
{
    public class RestClient<T>
    {
        private string Url = "https://cafbb8aabcba.ngrok.io";

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

        public async Task<List<Card>> GetCards(int UserId)
        {
            Url += $"/api/card/{UserId}";
            HttpClient client = new HttpClient();
            List<Card> cards = new List<Card>();
            string respnse = await client.GetStringAsync(Url);

            if (respnse != null)
            {
                cards = JsonConvert.DeserializeObject<List<Card>>(respnse);
            }

            return cards;
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

        public async Task<User> EditUser(User user)
        {
            Url += $"api/user/edit";
            HttpClient client = new HttpClient();
            var JsonData = new
            {
                name = user.Name,
                email = user.Email,
                phone = user.Phone,
                fullname = user.FullName
            };
            string jsonData = JsonConvert.SerializeObject(JsonData);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(Url, content);

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }

            return user;
        }
    }
}
