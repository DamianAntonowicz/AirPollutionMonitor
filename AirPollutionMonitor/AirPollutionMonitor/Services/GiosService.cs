using System.Collections.Generic;
using System.Threading.Tasks;
using AirPollutionMonitor.Models;
using Refit;

namespace AirPollutionMonitor.Services
{
    public interface IGiosApi
    {
        [Get("/pjp-api/rest/station/findAll")]
        Task<List<Station>> GetStations();

        [Get("/pjp-api/rest/aqindex/getIndex/{stationId}")]
        Task<StationDetails> GetStationDetails(int stationId);
    }
}