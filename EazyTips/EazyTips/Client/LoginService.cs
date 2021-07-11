using EazyTips.Repository;
using EazyTips.RestClient;
using System.Threading.Tasks;

namespace EazyTips.Client
{
    public class LoginService
    {
        RestClient<User> restClient = new RestClient<User>();

        public async Task<bool> CheckLoginIfExists(string Phone, string Password)
        {
            bool check = await restClient.checkLogin(Phone, Password);
            return check;
        }
    }
}
