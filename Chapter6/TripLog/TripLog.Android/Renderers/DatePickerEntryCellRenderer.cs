using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using View = Android.Views.View;
using TripLog.Controls;
using TripLog.Droid.Renderers;

[assembly: ExportRenderer(typeof(DatePickerEntryCell), typeof(DatePickerEntryCellRenderer))]
namespace TripLog.Droid.Renderers
{
    public class DatePickerEntryCellRenderer : EntryCellRenderer
    {
        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            var cell = (LinearLayout)base.GetCellCore(item, convertView, parent, context);
            var datepickerCell = (DatePickerEntryCell)item;

            EditText textView = null;

            if (cell != null)
            {
                textView = ((EntryCellView)cell).EditText;
            }

            // Default datepicker display attributes
            var displayFormat = "d";
            var date = DateTime.Today;
            var currentDate = DateTime.MinValue;

            Action<DateTime> pickedDateCallback = pickedDate =>
            {
                if (datepickerCell != null)
                {
                    datepickerCell.Date = pickedDate;
                }

                if (textView != null)
                {
                    textView.Text = pickedDate.ToString(displayFormat);
                }
            };

            if (textView != null)
            {
                // Hide keyboard since we're using the datepicker dialog
                textView.InputType = 0;

                if (!textView.HasOnClickListeners)
                {
                    // Show the datepicker when focusing on the cell
                    textView.FocusChange += (s, e) =>
                    {
                        DateTime.TryParse(textView.Text, out currentDate);

                        if (currentDate == DateTime.MinValue)
                        {
                            currentDate = DateTime.Now;
                        }

                        if (!textView.HasFocus)
                        {
                            return;
                        }

                        ShowDatePickerDialogFragment(context, currentDate, pickedDateCallback);
                    };

                    // Show the datepicker when clicking on the cell
                    textView.Click += (s, e) =>
                    {
                        DateTime.TryParse(textView.Text, out currentDate);

                        if (currentDate == DateTime.MinValue)
                        {
                            currentDate = DateTime.Now;
                        }

                        ShowDatePickerDialogFragment(context, currentDate, pickedDateCallback);
                    };
                }

                if (datepickerCell != null)
                {
                    textView.Text = datepickerCell.Date.ToString(displayFormat);
                }
            }

            return cell;
        }

        void ShowDatePickerDialogFragment(Context context, DateTime date, Action<DateTime> dateSetCallback)
        {
            var fragTransaction = ((Activity)context).FragmentManager.BeginTransaction();
            var dialog = new DatePickerDialogFragment(context, date, dateSetCallback);

            dialog.Show(fragTransaction, "datepicker_dialog");
        }
    }
}
