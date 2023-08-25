using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AppParqueadero.Converter
{
    public class DateConvert : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           if(value is string Date)
            {
                return DateTime.Parse(Date).ToString("hh:mm");
            }
            return DateTime.Now.Hour;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
