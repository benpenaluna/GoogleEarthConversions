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
        public ICollection<IPair> Pairs { get; set; }

        public StyleMap(IPair pair1, IPair pair2 = null)
        {
            InitialiseBaseProperties(pair1, pair2);
        }

        public StyleMap(IStyleUrl styleUrl, StyleStateEnum styleStateEnum = StyleStateEnum.Normal)
        {
            InitialiseBaseProperties(new Pair(styleUrl, styleStateEnum), null); 
        }

        public StyleMap(Uri url, StyleStateEnum styleStateEnum = StyleStateEnum.Normal)
        {
            InitialiseBaseProperties(new Pair(url, styleStateEnum), null);
        }

        private void InitialiseBaseProperties(IPair pair1, IPair pair2)
        {
            Id = string.Empty;
            TargetId = string.Empty;

            Pairs = new List<IPair>() { pair1 };
            if (pair2 != null)
                Pairs.Add(pair2);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(StyleMap) && Equals((StyleMap)obj);
        }

        protected bool Equals(StyleMap other)
        {
            return Equals(Pairs, other.Pairs);
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

        public override string SerialiseToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            
            foreach (var pair in Pairs)
            {
                sw.Write(pair.SerialiseToKML());
            }

            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }
    }
}
