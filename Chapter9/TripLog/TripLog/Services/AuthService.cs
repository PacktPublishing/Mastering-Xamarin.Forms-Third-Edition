using System;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;

namespace TripLog.Services
{
	public class AuthService : IAuthService
	{
        public void SignInAsync(string clientId,
               Uri authUrl,
               Uri callbackUrl,
               Action<string> tokenCallback,
               Action<string> errorCallback)
        {
            var presenter = new OAuthLoginPresenter();
            var authenticator = new OAuth2Authenticator(clientId, "", authUrl, callbackUrl);

            authenticator.Completed += (sender, args) =>
            {
                if (args.Account != null && args.IsAuthenticated)
                {
                    tokenCallback?.Invoke(args.Account.Properties["access_token"]);
                }
                else
                {
                    errorCallback?.Invoke("Not authenticated");
                }
            };

            authenticator.Error += (sender, args) =>
            {
                errorCallback?.Invoke(args.Message);
            };

            presenter.Login(authenticator);
        }
    }
}
