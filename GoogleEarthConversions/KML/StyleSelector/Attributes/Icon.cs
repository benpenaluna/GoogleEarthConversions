using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class Icon : IIcon
    {
        private IHref _href;
        public string Href
        {
            get => _href.Value;
            set => _href.Value = value;
        }

        public Icon(string href = "")
        {
            _href = new Href(href);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Icon) && Equals((Icon)obj);
        }

        protected bool Equals(Icon other)
        {
            return Equals(Href, other.Href);
        }

        public static bool operator ==(Icon a, Icon b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Icon a, Icon b)
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
                return "";

            return string.Format("<{0}><{1}>{2}</{1}></{0}>", nameof(Icon), nameof(Href).ConvertFirstCharacterToLowerCase(), Href);
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
