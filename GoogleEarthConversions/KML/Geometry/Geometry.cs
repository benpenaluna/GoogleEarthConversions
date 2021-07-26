using GoogleEarthConversions.Core.KML.Geometry.Attributes;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public abstract class Geometry : GoogleEarthObject, IKMLFormat
    {
        public IAltitudeMode AltitudeMode { get; set; }

        public IExtrude Extrude { get; set; }

        public abstract string SerialiseToKML();

        public abstract object DeserialiseFromKML();
    }
}
