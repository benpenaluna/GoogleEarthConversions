using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public abstract class Geometry : GoogleEarthObject, IKMLFormat
    {
        public IAltitudeMode AltitudeMode { get; set; }

        public IExtrude Extrude { get; set; }

        public abstract string ConvertObjectToKML();

        protected string OpeningTag(Type type)
        {
            return string.Format("<{0} {1}=\"{2}\">", type.Name, nameof(Id).ConvertFirstCharacterToLowerCase(), Id);
        }

        protected string ClosingTag(Type type)
        {
            return string.Format("</{0}>", type.Name);
        }
    }
}
