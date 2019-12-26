using System;
using System.Collections.Generic;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace TripLog.Services
{
    public class AppCenterAnalyticsService : IAnalyticsService
    {
        public void TrackEvent(string eventKey)
        {
            Analytics.TrackEvent(eventKey);
        }

        public void TrackEvent(string eventKey, IDictionary<string, string> data)
        {
            Analytics.TrackEvent(eventKey, data);
        }

        public void TrackError(Exception exception)
        {
            Crashes.TrackError(exception);
        }

        public void TrackError(Exception exception, IDictionary<string, string> data)
        {
            Crashes.TrackError(exception, data);
        }
    }
}
