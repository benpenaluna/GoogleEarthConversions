using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using GoogleEarthConversions.Core.KML.Object;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public interface INetworkLink
    {
        string Id { get; set; }
        string TargetId { get; set; }

        IName Name { get; set; }
        IVisibility Visibility { get; set; }
        IOpen Open { get; set; }
        IAuthor Author { get; set; }
        IAddress Address { get; set; }
        IPhoneNumber PhoneNumber { get; set; }
        ISnippet Snippet { get; set; }
        AbstractView.AbstractView AbstractView { get; set; }
        TimePrimitive.TimePrimitive TimePrimitive { get; set; }
        IStyleUrl StyleUrl { get; }
        StyleSelector.StyleSelector StyleSelector { get; set; }
        IRegion Region { get; set; }
        IExtendedData ExtendedData { get; set; }

        GenericKML<bool> RefreshVisibility { get; set; }
        GenericKML<bool> FlyToView { get; set; }
        ILink Link { get; set; }
    }
}
