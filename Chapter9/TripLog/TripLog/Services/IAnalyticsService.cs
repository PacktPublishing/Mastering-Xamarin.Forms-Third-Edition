using System;
using System.Collections.Generic;

namespace TripLog.Services
{
    public interface IAnalyticsService
    {
        void TrackEvent(string eventKey);
        void TrackEvent(string eventKey, IDictionary<string, string> data);
        void TrackError(Exception exception);
        void TrackError(Exception exception, IDictionary<string, string> data);
    }
}
