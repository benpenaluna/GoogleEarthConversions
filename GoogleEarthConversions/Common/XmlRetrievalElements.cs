using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.Common
{
    public class XmlRetrievalElements : IXmlRetrievalElements
    {
        public string ElementName { get; set; }

        public IDictionary<string, string> ChildElements { get; set; }

        public XmlRetrievalElements()
        {
            ElementName = string.Empty;
            ChildElements = new Dictionary<string, string>();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(XmlRetrievalElements) && Equals((XmlRetrievalElements)obj);
        }

        protected bool Equals(XmlRetrievalElements other)
        {
            return Equals(ElementName, other.ElementName) &&
                   Equals(ChildElements, other.ChildElements);
        }

        public static bool operator ==(XmlRetrievalElements a, XmlRetrievalElements b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(XmlRetrievalElements a, XmlRetrievalElements b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


    }
}
