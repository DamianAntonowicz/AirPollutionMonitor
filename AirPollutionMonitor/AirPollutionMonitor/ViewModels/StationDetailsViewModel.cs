using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AirPollutionMonitor.Models;
using AirPollutionMonitor.Services;
using Refit;
using Xamarin.Forms;

namespace AirPollutionMonitor.ViewModels
{
    public class StationDetailsViewModel : BaseViewModel
    {
        private readonly IGiosApi _giosApi = RestService.For<IGiosApi>("http://api.gios.gov.pl");
        private int _stationId;

        private StationDetails _stationDetails;
        public StationDetails StationDetails
        {
            get => _stationDetails;
            set => SetProperty(ref _stationDetails, value);
        }
        
        public Command LoadStationDetailsCommand { get; }

        public StationDetailsViewModel(int stationId)
        {
            _stationId = stationId;
            LoadStationDetailsCommand = new Command(async () => await LoadStationDetails());
        }

        private async Task LoadStationDetails()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;

            try
            {
                StationDetails = await _giosApi.GetStationDetails(_stationId);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}