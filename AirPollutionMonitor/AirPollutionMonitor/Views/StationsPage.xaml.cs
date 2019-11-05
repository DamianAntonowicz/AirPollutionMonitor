using System;
using System.Collections.Generic;
using System.Linq;
using AirPollutionMonitor.Models;
using AirPollutionMonitor.ViewModels;
using Xamarin.Forms;

namespace AirPollutionMonitor.Views
{
    public partial class StationsPage : ContentPage
    {
        private readonly StationsViewModel _stationsViewModel;

        public StationsPage()
        {
            InitializeComponent();
            BindingContext = _stationsViewModel = new StationsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_stationsViewModel.Stations == null ||
                _stationsViewModel.Stations.Count == 0)
            {
                _stationsViewModel.LoadStationsCommand.Execute(null);
            }
        }

        private async void CollectionView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Station station)
            {
                await Navigation.PushAsync(new StationDetailsPage(station.Id));
            }

            CollectionViewStations.SelectedItem = null;
        }
    }
}
