using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public interface ITripLogDataService
    {
        Action<string> AuthorizedDelegate { get; set; }
        Action UnauthorizedDelegate { get; set; }

        Task AuthenticateAsync(string idProvider, string idProviderToken);
        void Unauthenticate();
        Task<IList<TripLogEntry>> GetEntriesAsync();
        Task<TripLogEntry> AddEntryAsync(TripLogEntry entry);
    }
}
