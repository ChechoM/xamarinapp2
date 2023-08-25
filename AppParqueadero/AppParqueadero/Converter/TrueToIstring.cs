using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AppParqueadero.Converter
{
    public class TrueToIstring
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == "true"? "Si" : "No";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
