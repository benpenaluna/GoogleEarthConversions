using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class When : IWhen
    {
        public DateTime LocalDateTime { get; set; }
        public TimeZoneInfo TimeZone { get; set; }

        public When(DateTime localDateTime, TimeZoneInfo timeZone)
        {
            LocalDateTime = localDateTime;
            TimeZone = timeZone;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(When) && Equals((When)obj);
        }

        protected bool Equals(When other)
        {
            return Equals(LocalDateTime, other.LocalDateTime) &&
                   Equals(TimeZone, other.TimeZone);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ConvertObjectToKML()
        {
            var dateTimeString = LocalDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
            
            var offset = TimeZone.GetUtcOffset(LocalDateTime);
            var timeZoneString = offset >= TimeSpan.Zero ? offset.ToString(@"\+hh\:mm") : offset.ToString(@"\-hh\:mm");

            return string.Format("<{0}>{1}{2}</{0}>", nameof(When).ConvertFirstCharacterToLowerCase(), dateTimeString, timeZoneString);
        }
    }
}
