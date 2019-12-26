using System;
using Xamarin.Essentials;
using Ninject.Modules;
using TripLog.ViewModels;
using TripLog.Services;

namespace TripLog.Modules
{
    public class TripLogCoreModule : NinjectModule
    {
        public override void Load()
        {
            // ViewModels
            Bind<SignInViewModel>().ToSelf();
            Bind<MainViewModel>().ToSelf();
            Bind<DetailViewModel>().ToSelf();
            Bind<NewEntryViewModel>().ToSelf();

            // Core Services
            var apiAuthToken = Preferences.Get("apitoken", "");
            var tripLogService = new TripLogApiDataService(new Uri("https://<your-function-name>.azurewebsites.net"), apiAuthToken);
            Bind<ITripLogDataService>()
                .ToMethod(x => tripLogService)
                .InSingletonScope();

            Bind<Akavache.IBlobCache>().ToConstant(Akavache.BlobCache.LocalMachine);
            Bind<IAuthService>().To<AuthService>().InSingletonScope();
            Bind<IAnalyticsService>().To<AppCenterAnalyticsService>().InSingletonScope();
        }
    }
}
