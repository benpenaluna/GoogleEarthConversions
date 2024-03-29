﻿using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.AbstractView;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using GoogleEarthConversions.Core.KML.Object;
using GoogleEarthConversions.Core.KML.StyleSelector;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using GoogleEarthConversions.Core.KML.TimePrimitive;
using System.IO;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public abstract class Feature : GoogleEarthObject, IKMLFormat
    {
        // Source: https://developers.google.com/kml/documentation/kmlreference?hl=en#feature

        public IName Name { get; set; }
        public IVisibility Visibility { get; set; }
        public IOpen Open { get; set; }
        public IAuthor Author { get; set; }
        public IBasicLink BasicLink { get; set; }
        public IAddress Address { get; set; }
        public IPhoneNumber PhoneNumber { get; set; }
        public ISnippet Snippet { get; set; }
        public IDescription Description { get; set; }
        public AbstractView.AbstractView AbstractView { get; set; }
        public TimePrimitive.TimePrimitive TimePrimitive { get; set; }
        public IStyleUrl StyleUrl { get; private set; }
        public StyleSelector.StyleSelector StyleSelector { get; set; }
        public IRegion Region { get; set; }
        public IExtendedData ExtendedData { get; set; }


        protected void InitiailiseFeatureProperties()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            Name = new Name();
            Visibility = new Visibility();
            Open = new Open();
            Author = new Author();
            BasicLink = new BasicLink();
            Address = new Address();
            PhoneNumber = new PhoneNumber();
            Snippet = new Snippet();
            Description = new Description();
            AbstractView = new DummyAbstractView();
            TimePrimitive = new DummyTimePrimitive();
            StyleUrl = new DummyStyleUrl();
            StyleSelector = new DummyStyleSelector();
            Region = new Region();
            ExtendedData = new ExtendedData();
        }

        public void SetStyleUrl(IStyleUrl styleUrl)
        {
            StyleUrl = styleUrl;
        }

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
                   Equals(BasicLink, other.BasicLink) &&
                   Equals(Address, other.Address) &&
                   Equals(PhoneNumber, other.PhoneNumber) &&
                   Equals(Snippet, other.Snippet) &&
                   Equals(Description, other.Description) &&
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

        protected string GetFeatureKMLTags(bool includeTypeTag = true)
        {
            StringWriter sw = new StringWriter();

            if (includeTypeTag)
                sw.Write(OpeningTag(GetType()));

            sw.Write(Name.SerialiseToKML());
            sw.Write(Visibility.SerialiseToKML());
            sw.Write(Open.SerialiseToKML());
            sw.Write(Author.SerialiseToKML());
            sw.Write(BasicLink.SerialiseToKML());
            sw.Write(Address.SerialiseToKML());
            sw.Write(PhoneNumber.SerialiseToKML());
            sw.Write(Snippet.SerialiseToKML());
            sw.Write(Description.SerialiseToKML());
            sw.Write(AbstractView.SerialiseToKML());
            sw.Write(TimePrimitive.SerialiseToKML());
            sw.Write(StyleUrl.SerialiseToKML());
            sw.Write(StyleSelector.SerialiseToKML());
            sw.Write(Region.SerialiseToKML());
            sw.Write(ExtendedData.SerialiseToKML());

            if (includeTypeTag)
                sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }

        public abstract string SerialiseToKML();
    }
}
