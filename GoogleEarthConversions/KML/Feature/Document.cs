using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public class Document : Container, IDocument
    {
        public ICollection<StyleSelector.StyleSelector> StyleSelectors { get; set; }

        public Document()
        {
            StyleSelectors = new List<StyleSelector.StyleSelector>();
            InitialiseBaseProperties();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Document) && Equals((Document)obj);
        }

        protected bool Equals(Document other)
        {
            return Equals(Id, other.Id) &&
                   base.Equals(other);
        }

        public static bool operator ==(Document a, Document b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Document a, Document b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ConvertObjectToKML() // TODO: Unit Test this once Placemark created
        {
            throw new NotImplementedException();
        }
    }
}
