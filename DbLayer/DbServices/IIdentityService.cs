using System.Threading.Tasks;
using Models.Authentication;

namespace DbLayer.DbServices
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string Username, string Password);
    }
}