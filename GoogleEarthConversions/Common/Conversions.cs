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
            if (typeof(T) == typeof(bool))
                inValue = ConvertBoolFromKMLFormat(inValue);

            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, inValue);
        }
        
        public static string ConvertBoolFromKMLFormat(string inValue)
        {
            if (inValue == "0" || inValue == "1")
            {
                return inValue == "0" ? "false" : "true";
            }

            return inValue;
        }
    }
}
