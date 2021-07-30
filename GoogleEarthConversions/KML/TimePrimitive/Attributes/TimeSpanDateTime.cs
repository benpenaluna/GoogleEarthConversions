using System;

namespace GoogleEarthConversions.Core.KML.TimePrimitive.Attributes
{
    public class TimeSpanDateTime : ITimeSpanDateTime
    {
        public DateTime DateTime { get; set; }
        public bool Enabled { get; set; }

        public TimeSpanDateTime(DateTime? dateTime)
        {
            DateTime = dateTime ?? DateTime.Now;
            Enabled = dateTime != null;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(TimeSpanDateTime) && Equals((TimeSpanDateTime)obj);
        }

        protected bool Equals(TimeSpanDateTime other)
        {
            return Equals(DateTime, other.DateTime) &&
                   Equals(Enabled, other.Enabled);
        }

        public static TimeSpanDateTime DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
