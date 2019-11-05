using System;
using System.Collections.Generic;
using AirPollutionMonitor.ViewModels;
using Xamarin.Forms;

namespace AirPollutionMonitor.Views
{
    public partial class StationDetailsPage : ContentPage
    {
        private readonly StationDetailsViewModel _viewModel;
        
        public StationDetailsPage(int stationId)
        {
            InitializeComponent();
            BindingContext = _viewModel = new StationDetailsViewModel(stationId);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.StationDetails == null)
            {
                _viewModel.LoadStationDetailsCommand.Execute(null);
            }
        }
    }
}
