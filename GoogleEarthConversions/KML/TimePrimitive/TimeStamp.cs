using GoogleEarthConversions.Core.KML.TimePrimitive.Attributes;
using System;
using System.IO;

namespace GoogleEarthConversions.Core.KML.TimePrimitive
{
    public class TimeStamp : TimePrimitive, ITimeStamp
    {
        public IWhen When { get; set; }

        public TimeStamp(DateTime localDateTime, TimeZoneInfo timeZone)
        {
            Id = string.Empty;
            TargetId = string.Empty; 
            When = new When(localDateTime, timeZone);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(TimeStamp) && Equals((TimeStamp)obj);
        }

        protected bool Equals(TimeStamp other)
        {
            return Equals(When, other.When);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ConvertObjectToKML()
        {
            var googleEarthNamespace = "gx:";
            
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType(), googleEarthNamespace));

            sw.Write(When.ConvertObjectToKML());

            sw.Write(ClosingTag(GetType(), googleEarthNamespace));

            return sw.ToString();
        }
    }
}
