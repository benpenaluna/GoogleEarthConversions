using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace GoogleEarthConversions.Core.Common
{
    public static class Conversions
    {
        public static T TryParse<T>(string inValue)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, inValue);
        } 
    }
}
