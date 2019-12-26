using System;
using System.Collections.Generic;
using TripLog.Exceptions;
using TripLog.Models;
using TripLog.Services;

namespace TripLog.ViewModels
{
    public class DetailViewModel : BaseViewModel<TripLogEntry>
    {
        TripLogEntry _entry;
        public TripLogEntry Entry
        {
            get => _entry;
            set
            {
                _entry = value;
                OnPropertyChanged();
            }
        }

        public DetailViewModel(INavService navService, IAnalyticsService analyticsService)
            : base(navService, analyticsService)
        {
        }

        public override void Init()
        {
            throw new EntryNotProvidedException();
        }

        public override void Init(TripLogEntry parameter)
        {
            AnalyticsService.TrackEvent("Entry Detail Page", new Dictionary<string, string>
                {
                   { "Title", parameter.Title }
                });

            Entry = parameter;
        }
    }
}
