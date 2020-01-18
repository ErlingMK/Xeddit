using System;
using System.Threading.Tasks;

namespace Xeddit.Services.Authentication.Abstractions
{
    internal interface IBrowser
    {
        Task GetAsync(Uri uri);
    }
}