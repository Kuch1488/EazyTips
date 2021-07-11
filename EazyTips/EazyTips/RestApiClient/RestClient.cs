using System.Net.Http;
using System.Threading.Tasks;

namespace EazyTips.RestClient
{
    public class RestClient<T>
    {
        private const string LoginUrl = "https://localhost:44334/api/user/login";

        public async Task<bool> checkLogin(string Phone, string Password)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(LoginUrl + "phone=" + Phone + "password=" + Password);
            return response.IsSuccessStatusCode;
        }
    }
}
