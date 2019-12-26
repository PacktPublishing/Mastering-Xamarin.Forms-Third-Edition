using System;
using Xamarin.Forms;
using TripLog.ViewModels;

namespace TripLog.Views
{
    public partial class MainPage : ContentPage
    {
        MainViewModel ViewModel => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Initialize MainViewModel
            ViewModel?.Init();
        }
    }
}
