﻿using EazyTips.Repository;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EazyTips.RestClient
{
    public class RestClient<T>
    {
        private string Url = "http://a5cecfcb30a5.ngrok.io/";
        //private const string LoginUrl = "http://a5cecfcb30a5.ngrok.io/api/user/login";
        //private const string RegistrUrl = "http://a5cecfcb30a5.ngrok.io/api/user/registration";

        public async Task<bool> checkLogin(string _phone, string _password)
        {
            Url += "api/user/login";
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

        public async Task<bool> userRegistration(string _phone, string _password)
        {
            Url = "api/user/registration";
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
    }
}
