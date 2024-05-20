using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace GeoSynapse.MouseNinja.Converters
{
    public class BrightnessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double sliderValue)  // Check if the value is a double representing the slider value
            {
                byte brightness = (byte)(50 + (100 - sliderValue) * 2.04);
                var color =  Color.FromRgb(brightness, brightness, brightness);
                return new SolidColorBrush(color);
            }

            // Handle cases where the value might not be a double
            return Brushes.Black; // Default to black if the value is unexpected
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
