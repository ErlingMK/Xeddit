using System;
using System.Collections.Generic;
using System.Text;
using Xeddit.Services.Authentication.Abstractions;

namespace Xeddit.Services.Authentication
{
    public class TokensContainer : ITokensContainer
    {
        public Tokens Tokens { get; set; }
    }
}
