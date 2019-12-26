using System;

namespace TripLog.Services
{
    public interface IAuthService
    {
        void SignInAsync(string clientId,
            Uri authUrl,
            Uri callbackUrl,
            Action<string> tokenCallback,
            Action<string> errorCallback);
    }
}
