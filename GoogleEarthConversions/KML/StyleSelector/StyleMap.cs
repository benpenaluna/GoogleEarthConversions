using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector
{
    public class StyleMap : StyleSelector, IStyleMap
    {
        public IPair Pair { get; set; }

        public StyleMap(IPair pair)
        {
            InitialiseBaseProperties(pair);
        }

        public StyleMap(IStyleUrl styleUrl, StyleStateEnum styleStateEnum = StyleStateEnum.Normal)
        {
            InitialiseBaseProperties(new Pair(styleUrl, styleStateEnum)); 
        }

        public StyleMap(Uri url, StyleStateEnum styleStateEnum = StyleStateEnum.Normal)
        {
            InitialiseBaseProperties(new Pair(url, styleStateEnum));
        }

        private void InitialiseBaseProperties(IPair pair)
        {
            Id = string.Empty;
            TargetId = string.Empty;
            Pair = pair;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(StyleMap) && Equals((StyleMap)obj);
        }

        protected bool Equals(StyleMap other)
        {
            return Equals(Pair, other.Pair);
        }

        public static bool operator ==(StyleMap a, StyleMap b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(StyleMap a, StyleMap b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ConvertObjectToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            sw.Write(Pair.ConvertObjectToKML());
            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
