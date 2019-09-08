using System;
using System.Globalization;
using LocationTracker.Core;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace LocationTracker.Converters
{
    public class LocationToPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Location == false)
            {
                return default(Position);
            }

            var input = (Location)value;


            var pos = new Position(input.Latitude, input.Longitude);

            return pos;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
