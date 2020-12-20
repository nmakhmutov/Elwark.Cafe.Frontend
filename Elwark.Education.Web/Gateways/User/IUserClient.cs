using System.Threading.Tasks;
using Elwark.Education.Web.Gateways.Models.User;

namespace Elwark.Education.Web.Gateways.User
{
    public interface IUserClient
    {
        Task CreateAsync();
        
        Task<ApiResponse<SubscriptionSummary[]>> GetSubscriptionsAsync();
        
        Task<ApiResponse<Profile>> GetProfileAsync();
    }
}