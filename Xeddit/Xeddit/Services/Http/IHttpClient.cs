﻿using System;
using System.Threading.Tasks;

namespace Xeddit.Services.Http
{
    public interface IHttpClient
    {
        Task<string> GetAsync(string path);
        Task PostAsync(Uri uri);
        Task PutAsync(Uri uri);
        Task DeleteAsync(Uri uri);
    }
}