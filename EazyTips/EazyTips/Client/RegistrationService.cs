using EazyTips.Repository;
using EazyTips.RestClient;
using System.Threading.Tasks;

namespace EazyTips.Client
{
    public class RegistrationService
    {
        RestClient<User> restClient = new RestClient<User>();

        public async Task<bool> RegistrationSuccess(string Phone, string Password)
        {
            bool check = await restClient.userRegistration(Phone, Password);
            return check;
        }
    }
}
