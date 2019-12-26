using System;
using System.Linq;
using Xamarin.Forms;
using TripLog.Models;
using TripLog.ViewModels;
using TripLog.Services;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        MainViewModel ViewModel => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel(DependencyService.Get<INavService>());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Initialize MainViewModel
            ViewModel?.Init();
        }
    }
}
