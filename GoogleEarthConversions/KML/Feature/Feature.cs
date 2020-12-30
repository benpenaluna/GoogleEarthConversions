using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;

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
        AbstractView.AbstractView AbstractView { get; set; }
        TimePrimitive.TimePrimitive TimePrimitive { get; set; }
        Uri StyleUrl { get; set; }
        StyleSelector.StyleSelector StyleSelector { get; set; } // TODO: Create the Style and StyleMap classes

        public abstract string ConvertObjectToKML();
    }
}
