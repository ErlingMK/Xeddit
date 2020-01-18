using System.Threading.Tasks;

namespace Xeddit.Services.Authentication.Abstractions
{
    public interface ITokenRequest
    {
        bool ApplicationOnly { get; set; }
        Task<Tokens> GetJwt(string code = null);
    }
}