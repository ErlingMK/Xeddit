using System.Threading.Tasks;

namespace Xeddit.Services.Authentication.Abstractions
{
    public interface IAuthorizationRequest
    {
        Task StartAuthRequest();
    }
}