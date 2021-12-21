using System;
using System.Globalization;
using Xamarin.Forms;

namespace C971_CourseTracker.Utils
{
    class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = (string)value;
            switch (val)
            {
                case "completed":
                    return Brush.Lime;
                case "dropped":
                    return Brush.DarkRed;
                default:
                    break;
            }
            return Brush.Orange;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
