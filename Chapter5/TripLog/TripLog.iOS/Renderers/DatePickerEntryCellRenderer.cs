using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;
using TripLog.Controls;
using TripLog.iOS.Renderers;

[assembly: ExportRenderer(typeof(DatePickerEntryCell), typeof(DatePickerEntryCellRenderer))]
namespace TripLog.iOS.Renderers
{
    public class DatePickerEntryCellRenderer : EntryCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            var datepickerCell = (DatePickerEntryCell)item;
            UITextField textField = null;

            if (cell != null)
            {
                textField = (UITextField)cell.ContentView.Subviews[0];
            }

            // Default datepicker display attributes
            var mode = UIDatePickerMode.Date;
            var displayFormat = "d";
            var date = NSDate.Now;
            var isLocalTime = false;

            // Update datepicker based on Cell's properties
            if (datepickerCell != null)
            {
                // Kind must be Universal or Local to cast to NSDate
                if (datepickerCell.Date.Kind == DateTimeKind.Unspecified)
                {
                    var local = new DateTime(datepickerCell.Date.Ticks, DateTimeKind.Local);

                    date = (NSDate)local;
                }
                else
                {
                    date = (NSDate)datepickerCell.Date;
                }

                isLocalTime = datepickerCell.Date.Kind == DateTimeKind.Local
                    || datepickerCell.Date.Kind == DateTimeKind.Unspecified;
            }

            // Create iOS datepicker
            var datepicker = new UIDatePicker
            {
                Mode = mode,
                BackgroundColor = UIColor.White,
                Date = date,
                TimeZone = isLocalTime ? NSTimeZone.LocalTimeZone : new NSTimeZone("UTC")
            };

            // Create a toolbar with a done button that will
            // close the datepicker and set the selected value
            var done = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (s, e) =>
                {
                    var pickedDate = (DateTime)datepicker.Date;

                    if (isLocalTime)
                    {
                        pickedDate = pickedDate.ToLocalTime();
                    }

                    // Update the value of the UITextField within the Cell
                    if (textField != null)
                    {
                        textField.Text = pickedDate.ToString(displayFormat);
                        textField.ResignFirstResponder();
                    }

                    // Update the Date property on the Cell
                    if (datepickerCell != null)
                    {
                        datepickerCell.Date = pickedDate;
                        datepickerCell.SendCompleted();
                    }
                });

            var toolbar = new UIToolbar
            {
                BarStyle = UIBarStyle.Default,
                Translucent = false
            };

            toolbar.SizeToFit();
            toolbar.SetItems(new[] { done }, true);

            // Set the input view, toolbar and initial value for the Cell's UITextField
            if (textField != null)
            {
                textField.InputView = datepicker;
                textField.InputAccessoryView = toolbar;

                if (datepickerCell != null)
                {
                    textField.Text = datepickerCell.Date.ToString(displayFormat);
                }
            }

            return cell;
        }
    }
}
