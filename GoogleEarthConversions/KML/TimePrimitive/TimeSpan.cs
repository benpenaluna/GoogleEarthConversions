using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.TimePrimitive.Attributes;
using System;
using System.IO;

namespace GoogleEarthConversions.Core.KML.TimePrimitive
{
    public class TimeSpan : TimePrimitive, ITimeSpan
    {
        public ITimeSpanDateTime Begin { get; set; }
        public ITimeSpanDateTime End { get; set; }

        public TimeSpan(DateTime? begin, DateTime? end)
        {
            Id = string.Empty;
            TargetId = string.Empty; 
            Begin = new TimeSpanDateTime(begin);
            End = new TimeSpanDateTime(end);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(TimeSpan) && Equals((TimeSpan)obj);
        }

        protected bool Equals(TimeSpan other)
        {
            return Equals(Begin, other.Begin) &&
                   Equals(End, other.End);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string SerialiseToKML()
        {
            if (Begin.Enabled == false && End.Enabled == false)
                return "";
            
            var googleEarthNamespace = "gx:";
            var timeformat = "yyyy-MM-ddTHH:mm:ss";

            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType(), googleEarthNamespace));

            if (Begin.Enabled == true)
                sw.Write(string.Format("<{0}>{1}</{0}>", nameof(Begin).ConvertFirstCharacterToLowerCase(), Begin.DateTime.ToString(timeformat)));

            if (End.Enabled == true)
                sw.Write(string.Format("<{0}>{1}</{0}>", nameof(End).ConvertFirstCharacterToLowerCase(), End.DateTime.ToString(timeformat)));

            sw.Write(ClosingTag(GetType(), googleEarthNamespace));

            return sw.ToString();
        }
    }
}
