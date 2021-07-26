using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.TimePrimitive.Attributes;
using System;
using System.IO;

namespace GoogleEarthConversions.Core.KML.TimePrimitive
{
    public class TimeStamp : TimePrimitive, TimePrimative
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

        public static bool operator ==(TimeStamp a, TimeStamp b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(TimeStamp a, TimeStamp b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string SerialiseToKML()
        {
            var googleEarthNamespace = "gx:";

            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType(), googleEarthNamespace));

            sw.Write(When.SerialiseToKML());

            sw.Write(ClosingTag(GetType(), googleEarthNamespace));

            return sw.ToString();
        }

        public override object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
