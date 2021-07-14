using EazyTips.Repository;
using EazyTips.RestClient;
using System.Threading.Tasks;

namespace EazyTips.Client
{
    public class UserService
    {
        RestClient<User> restClient = new RestClient<User>();

        public async Task<User> GetUserAsync(int id)
        {
            User user = await restClient.GetUser(id);
            return user;
        }
    }
}
