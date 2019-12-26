using System;
using TripLog.Services;
using Xamarin.Forms;

namespace TripLog.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        readonly IAuthService _authService;
        readonly ITripLogDataService _tripLogService;

        Command _signInCommand;
        public Command SignInCommand => _signInCommand ?? (_signInCommand = new Command(SignIn));

        public SignInViewModel(INavService navService, IAuthService authService, ITripLogDataService tripLogService)
            : base(navService)
        {
            _authService = authService;
            _tripLogService = tripLogService;
        }

        void SignIn()
        {
            // TODO: Update with your Facebook App Id and Function App name
            _authService.SignInAsync("YOUR_FACEBOOK_APPID",
                new Uri("https://m.facebook.com/dialog/oauth"),
                new Uri("https://<your-function-name>.azurewebsites.net/.auth/login/facebook/callback"),
                tokenCallback: async token =>
                {
                    // Use Facebook token to get Azure auth token
                    await _tripLogService.AuthenticateAsync("facebook", token);
                },
                errorCallback: e =>
                {
                    // TODO: Handle invalid authentication here
                });
        }
    }
}
