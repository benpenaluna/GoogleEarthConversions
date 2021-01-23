using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.AbstractView;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using GoogleEarthConversions.Core.KML.Object;
using GoogleEarthConversions.Core.KML.StyleSelector;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using GoogleEarthConversions.Core.KML.TimePrimitive;
using System;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public abstract class Feature : GoogleEarthObject, IKMLFormat
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#feature

        public IName Name { get; set; }
        public IVisibility Visibility { get; set; }
        public IOpen Open { get; set; }
        public IAuthor Author { get; set; }
        public ILink Link { get; set; }
        public IAddress Address { get; set; }
        public IPhoneNumber PhoneNumber { get; set; }
        public ISnippet Snippet { get; set; }
        public AbstractView.AbstractView AbstractView { get; set; }
        public TimePrimitive.TimePrimitive TimePrimitive { get; set; }
        public IStyleUrl StyleUrl { get; private set; }
        public StyleSelector.StyleSelector StyleSelector { get; set; }
        public IRegion Region { get; set; }
        
        private string _extendedData;
        public string ExtendedData
        {
            get => _extendedData;
            set 
            {
                if (value != string.Empty && !value.IsValidXML())
                    throw new InvalidOperationException(string.Format("{0} must contain valid XML.", nameof(ExtendedData)));
                
                _extendedData = value; 
            }
        }

        protected void InitiailiseFeatureProperties()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            Name = new Name();
            Visibility = new Visibility();
            Open = new Open();
            Author = new Author();
            Link = new Link();
            Address = new Address();
            PhoneNumber = new PhoneNumber();
            Snippet = new Snippet();
            AbstractView = new DummyAbstractView();
            TimePrimitive = new DummyTimePrimitive();
            StyleUrl = new DummyStyleUrl();
            StyleSelector = new DummyStyleSelector();
            Region = new Region();
            ExtendedData = string.Empty;
        }

        public void SetStyleUrl(IStyleUrl styleUrl)
        {
            StyleUrl = styleUrl;
        }

        public abstract string ConvertObjectToKML();

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Feature) && Equals((Feature)obj);
        }

        protected bool Equals(Feature other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(Name, other.Name) &&
                   Equals(Visibility, other.Visibility) &&
                   Equals(Open, other.Open) &&
                   Equals(Author, other.Author) &&
                   Equals(Link, other.Link) &&
                   Equals(Address, other.Address) &&
                   Equals(PhoneNumber, other.PhoneNumber) &&
                   Equals(Snippet, other.Snippet) &&
                   Equals(AbstractView, other.AbstractView) &&
                   Equals(TimePrimitive, other.TimePrimitive) &&
                   Equals(StyleUrl, other.StyleUrl) &&
                   Equals(StyleSelector, other.StyleSelector) &&
                   Equals(Region, other.Region) &&
                   Equals(ExtendedData, other.ExtendedData);
        }

        public static bool operator ==(Feature a, Feature b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Feature a, Feature b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
