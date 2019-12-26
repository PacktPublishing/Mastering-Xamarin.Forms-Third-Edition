using System;
using Android.App;
using Android.Content;
using Android.OS;

namespace TripLog.Droid.Renderers
{
    public class DatePickerDialogFragment : DialogFragment
    {
        private readonly Context _context;
        private readonly DateTime _date;
        private readonly Action<DateTime> _dateSetCallback;

        public DatePickerDialogFragment(Context context, DateTime date, Action<DateTime> dateSetCallback)
        {
            _context = context;
            _date = date;
            _dateSetCallback = dateSetCallback;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            return new DatePickerDialog(_context, OnDateSet, _date.Year, _date.Month - 1, _date.Day);
        }

        private void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs args)
        {
            _dateSetCallback(args.Date);
        }
    }
}