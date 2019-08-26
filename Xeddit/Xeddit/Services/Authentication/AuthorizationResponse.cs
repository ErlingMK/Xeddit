using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Xeddit.Services.Authentication
{
    public interface IAuthorizationResponse
    {
        string Code { get; }
        string State { get; }
        bool ErrorOccured { get; }
        bool UserDeniedAccess { get; }
    }

    public class AuthorizationResponse : IAuthorizationResponse
    {
        public AuthorizationResponse(Uri callbackUri)
        {
            var queriesCollection = HttpUtility.ParseQueryString(callbackUri.Query);

            if (queriesCollection.HasKeys())
            {
                if (queriesCollection.AllKeys.Any(k => k == "error"))
                {
                    ErrorHandling(queriesCollection.Get("error"));
                }
                else
                {
                    Code = queriesCollection.Get("code");
                    State = queriesCollection.Get("state");

                    VerifyState();
                }
            }
        }

        private void VerifyState()
        {
            // TODO: Verify State value

            if (Xamarin.Essentials.Preferences.ContainsKey("state"))
            {

            }
        }

        private void ErrorHandling(string error)
        {
            ErrorOccured = true;

            if (error == "access_denied") UserDeniedAccess = true;

            // TODO: Handle rest of errors.
        }

        public string Code { get; }
        public string State { get; }
        public bool ErrorOccured { get; private set; }
        public bool UserDeniedAccess { get; private set; }
    }
}
