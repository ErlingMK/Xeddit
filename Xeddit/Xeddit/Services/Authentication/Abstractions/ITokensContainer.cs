namespace Xeddit.Services.Authentication.Abstractions
{
    public interface ITokensContainer
    {
        Tokens Tokens { get; set; }
    }
}