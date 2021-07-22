using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class Link : ILink
    {
        private IHref _href;
        public string Href
        {
            get => _href.Value;
            set => _href.Value = value;
        }

        public Link(string absolutePath = "")
        {
            _href = new Href(absolutePath);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Link) && Equals((Link)obj);
        }

        protected bool Equals(Link other)
        {
            return Equals(Href, other.Href);
        }

        public static bool operator ==(Link a, Link b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Link a, Link b)
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

            return string.Format("<atom:{0} {1}=\"{2}\" />", nameof(Link).ConvertFirstCharacterToLowerCase(),
                                                                       nameof(Href).ConvertFirstCharacterToLowerCase(),
                                                                       Href);
        }
    }
}
