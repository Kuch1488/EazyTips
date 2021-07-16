using EazyTips.Entetys;
using EazyTips.RestClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EazyTips.Client
{
    public class CardService
    {
        RestClient<Card> restClient = new RestClient<Card>();

        public async Task<List<Card>> GetUserCards(int UserId)
        {
            List<Card> card = await restClient.GetCards(UserId);
            return card;
        }
    }
}
