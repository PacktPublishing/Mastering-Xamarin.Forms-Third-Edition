using System;
using Xamarin.Forms;

namespace TripLog.Controls
{
    public class DatePickerEntryCell : EntryCell
    {
        public static readonly BindableProperty DateProperty = BindableProperty.Create(
            nameof(Date),
            typeof(DateTime),
            typeof(DatePickerEntryCell),
            DateTime.Now,
            BindingMode.TwoWay);

        public DateTime Date
        {
            get => (DateTime)GetValue(DateProperty);
            set => SetValue(DateProperty, value);
        }
    }
}
