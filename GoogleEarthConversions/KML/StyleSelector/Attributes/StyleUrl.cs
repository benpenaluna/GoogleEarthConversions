using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class StyleUrl : IStyleUrl
    {
        public Uri Url { get; set; }

        public bool StyleInLocalDocument { get; set; }

        public StyleUrl(Uri href, bool styleLocal = true)
        {
            Url = href;
            StyleInLocalDocument = styleLocal;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(StyleUrl) && Equals((StyleUrl)obj);
        }

        protected bool Equals(StyleUrl other)
        {
            return Equals(Url, other.Url);
        }

        public static bool operator ==(StyleUrl a, StyleUrl b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(StyleUrl a, StyleUrl b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            var url = StyleInLocalDocument ? Url.Fragment : Url.AbsoluteUri;
            
            return string.Format("<{0}>{1}</{0}>", nameof(StyleUrl).ConvertFirstCharacterToLowerCase(), url);
        }
    }
}
