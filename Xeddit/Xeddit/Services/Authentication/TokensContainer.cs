using System;
using System.Collections.Generic;
using System.Text;

namespace Xeddit.Services.Authentication
{
    public interface ITokensContainer
    {
        Tokens Tokens { get; set; }
    }

    public class TokensContainer : ITokensContainer
    {
        public Tokens Tokens { get; set; }
    }
}
