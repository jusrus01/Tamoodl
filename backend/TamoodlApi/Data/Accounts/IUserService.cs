using System.Threading.Tasks;
using TamoodlApi.Models;

namespace TamoodlApi.Data.Accounts
{
    public interface IUserService
    {
        Task<TokenResponseModel> GetTokenAsync(TokenRequestModel model);
        Task<bool> CreateStudent(RegisterStudentModel model);
    }
}