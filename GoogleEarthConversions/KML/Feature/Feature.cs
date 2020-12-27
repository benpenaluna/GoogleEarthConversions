using GoogleEarthConversions.Core.KML.Feature.Attributes;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public abstract class Feature : GoogleEarthObject, IKMLFormat
    {
        IName Name { get; set; }

        public abstract string ConvertObjectToKML();
    }
}
