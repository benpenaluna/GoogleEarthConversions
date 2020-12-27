using GoogleEarthConversions.Core.KML.Feature.Attributes;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public abstract class Feature : GoogleEarthObject, IKMLFormat
    {
        IName Name { get; set; }
        IVisibility Visibility { get; set; }
        IOpen Open { get; set; }
        IAddress Address { get; set; }
        IPhoneNumber PhoneNumber { get; set; }

        public abstract string ConvertObjectToKML();
    }
}
