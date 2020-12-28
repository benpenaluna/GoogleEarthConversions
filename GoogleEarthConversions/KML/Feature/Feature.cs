using GoogleEarthConversions.Core.KML.Feature.Attributes;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public abstract class Feature : GoogleEarthObject, IKMLFormat  // TODO: Finish adding properties to this abstract class
    {
        IName Name { get; set; }
        IVisibility Visibility { get; set; }
        IOpen Open { get; set; }
        IAddress Address { get; set; }
        IPhoneNumber PhoneNumber { get; set; }
        ISnippet Snippet { get; set; }

        public abstract string ConvertObjectToKML();
    }
}
