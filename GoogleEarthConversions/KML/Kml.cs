using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML
{
    public class Kml : IKml
    {
        public string XmlDeclaration { get; set; }
        public IDictionary<string, IHref> XmlNameSpaces { get; set; }
        public INetworkLinkControl NetworkLinkControl { get; set; }
        public Feature.Feature Feature { get; set; }
        public KmlHint Hint { get; set; }

        public Kml()
        {
            XmlDeclaration = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            GenerateXmlNameSpaceList();
            NetworkLinkControl = new NetworkLinkControl();
            Feature = new DummyFeature();
            Hint = KmlHint.Earth;
        }

        private void GenerateXmlNameSpaceList()
        {
            XmlNameSpaces = new Dictionary<string, IHref>
            {
                { "", new Href("http://www.opengis.net/kml/2.2") },
                { "gx", new Href("http://www.google.com/kml/ext/2.2") },
                { "kml", new Href("http://www.opengis.net/kml/2.2") },
                { "atom", new Href("http://www.w3.org/2005/Atom") }
            };
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Kml) && Equals((Kml)obj);
        }

        protected bool Equals(Kml other)
        {
            return Equals(XmlDeclaration, other.XmlDeclaration) &&
                   Equals(XmlNameSpaces, other.XmlNameSpaces) &&
                   Equals(NetworkLinkControl, other.NetworkLinkControl) &&
                   Equals(Feature, other.Feature);
        }

        public static bool operator ==(Kml a, Kml b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Kml a, Kml b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            var sw = new StringBuilder();

            sw.Append(XmlDeclaration);
            sw.Append(GenerateKmlOpening());
            sw.Append(NetworkLinkControl.SerialiseToKML());
            sw.Append(Feature.SerialiseToKML());
            sw.Append(string.Format("</{0}>", nameof(Kml).ConvertFirstCharacterToLowerCase()));
            
            return sw.ToString();
        }

        private string GenerateKmlOpening()
        {
            var sw = new StringBuilder();

            sw.Append(string.Format("<{0}", nameof(Kml).ConvertFirstCharacterToLowerCase()));
            foreach (var xmlNameSpace in XmlNameSpaces)
            {
                var xmlNameSpaceKey = xmlNameSpace.Key == string.Empty ? string.Empty : string.Format(":{0}", xmlNameSpace.Key);                
                sw.Append(string.Format(" xmlns{0}=\"{1}\"", xmlNameSpaceKey, xmlNameSpace.Value.Value));
            }
            sw.Append(">");

            return sw.ToString();
        }

        public static Kml DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
