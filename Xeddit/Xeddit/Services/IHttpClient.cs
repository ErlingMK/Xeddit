using System;
using System.Threading.Tasks;

namespace Xeddit.Services
{
    internal interface IHttpClient
    {
        Task GetAsync(Uri uri);
        Task PostAsync(Uri uri);
        Task PutAsync(Uri uri);
        Task DeleteAsync(Uri uri);
    }
}