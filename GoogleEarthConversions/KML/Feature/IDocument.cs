using GoogleEarthConversions.Core.KML.Feature.Attributes;
using GoogleEarthConversions.Core.KML.Object;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public interface IDocument
    {
        string Id { get; set; }
        string TargetId { get; set; }
        
        IName Name { get; set; }
        IVisibility Visibility { get; set; }
        IOpen Open { get; set; }
        IAuthor Author { get; set; }
        IBasicLink BasicLink { get; set; }
        IAddress Address { get; set; }
        IPhoneNumber PhoneNumber { get; set; }
        ISnippet Snippet { get; set; }
        AbstractView.AbstractView AbstractView { get; set; }
        TimePrimitive.TimePrimitive TimePrimitive { get; set; }
        IStyleUrl StyleUrl { get; }
        StyleSelector.StyleSelector StyleSelector { get; set; }
        IRegion Region { get; set; }
        IExtendedData ExtendedData { get; set; }

        ICollection<Feature> Features { get; set; }
        ICollection<StyleSelector.StyleSelector> StyleSelectors { get; set; }

        void SetStyleUrl(IStyleUrl styleUrl);
    }
}
