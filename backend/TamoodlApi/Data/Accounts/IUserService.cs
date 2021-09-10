using System.Threading.Tasks;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Accounts
{
    public interface IUserService
    {
        Task<string> GetTokenAsync(TokenRequestModel model);
    }
}