using System;

namespace GoogleEarthConversions.Core.KML.TimePrimitive.Attributes
{
    public class TimeStamp : ITimeStamp
    {
        public IWhen When { get; set; }

        public TimeStamp(DateTime localDateTime, TimeZoneInfo timeZone)
        {
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
            return string.Format("<gx:{0}>{1}</gx:{0}>", nameof(TimeStamp), When.ConvertObjectToKML());
        }
    }
}
