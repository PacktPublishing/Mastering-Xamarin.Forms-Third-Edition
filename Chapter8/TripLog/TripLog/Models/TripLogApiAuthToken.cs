using System;
namespace TripLog.Models
{
    public class TripLogApiUser
    {
        public string UserId { get; set; }
    }

    public class TripLogApiAuthToken
    {
        public TripLogApiUser User { get; set; }
        public string AuthenticationToken { get; set; }
    }
}
