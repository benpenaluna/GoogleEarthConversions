using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class BasicLink : IBasicLink
    {
        private readonly IHref _href;
        public string Href
        {
            get => _href.Value;
            set => _href.Value = value;
        }

        public BasicLink(string absolutePath = "")
        {
            _href = new Href(absolutePath);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(BasicLink) && Equals((BasicLink)obj);
        }

        protected bool Equals(BasicLink other)
        {
            return Equals(Href, other.Href);
        }

        public static bool operator ==(BasicLink a, BasicLink b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(BasicLink a, BasicLink b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Href == string.Empty)
                return string.Empty;

            return string.Format("<atom:link {0}=\"{1}\" />", nameof(Href).ConvertFirstCharacterToLowerCase(), Href);
        }

        public static BasicLink DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
