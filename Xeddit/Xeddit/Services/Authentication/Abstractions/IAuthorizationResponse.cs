namespace Xeddit.Services.Authentication.Abstractions
{
    public interface IAuthorizationResponse
    {
        string Code { get; }
        string State { get; }
        bool ErrorOccured { get; }
        bool UserDeniedAccess { get; }
    }
}