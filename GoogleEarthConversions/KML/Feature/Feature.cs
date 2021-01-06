using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using GoogleEarthConversions.Core.KML.Object;
using System;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public abstract class Feature : GoogleEarthObject, IKMLFormat  // TODO: Finish adding properties to this abstract class
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#feature

        IName Name { get; set; }
        
        IVisibility Visibility { get; set; }
        
        IOpen Open { get; set; }

        IAuthor Author { get; set; }
        
        ILink Link { get; set; }

        IAddress Address { get; set; }
        
        IPhoneNumber PhoneNumber { get; set; }
        
        ISnippet Snippet { get; set; }
        
        AbstractView.AbstractView AbstractView { get; set; }
        
        TimePrimitive.TimePrimitive TimePrimitive { get; set; }
        
        string StyleUrl { get; set; }
        
        StyleSelector.StyleSelector StyleSelector { get; set; } // TODO: Create the Style and StyleMap classes
        
        IRegion Region { get; set; }
        
        private string _extendedData;
        public string ExtendedData
        {
            get => _extendedData;
            set 
            {
                if (!value.IsValidXML())
                    throw new InvalidOperationException(string.Format("{0} must contain valid XML.", nameof(ExtendedData)));
                
                _extendedData = value; 
            }
        }

        public abstract string ConvertObjectToKML();
    }
}
