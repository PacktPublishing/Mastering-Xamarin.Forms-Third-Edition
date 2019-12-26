using System;
using Ninject.Modules;
using TripLog.Services;
using TripLog.Droid.Services;

namespace TripLog.Droid.Modules
{
    public class TripLogPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILocationService>()
                .To<LocationService>()
                .InSingletonScope();
        }
    }
}
