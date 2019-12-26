using System;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Services
{
    public interface ILocationService
    {
        Task<GeoCoords> GetGeoCoordinatesAsync();
    }
}
