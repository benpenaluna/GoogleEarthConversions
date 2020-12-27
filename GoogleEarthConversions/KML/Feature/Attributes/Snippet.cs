using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class Snippet : ISnippet
    {
        public string ShortDescription { get; set; }
        public int MaxLines { get; set; }

        public Snippet(string shortDescription = "", int maxLines = 2)
        {
            ShortDescription = shortDescription;
            MaxLines = maxLines;
        }
        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Snippet) && Equals((Snippet)obj);
        }

        protected bool Equals(Snippet other)
        {
            return Equals(ShortDescription, other.ShortDescription) &&
                   Equals(MaxLines, other.MaxLines);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ConvertObjectToKML()
        {
            if (ShortDescription == string.Empty)
                return string.Empty;

            return string.Format("<{0} maxLines=\"{1}\">{2}</{0}>", nameof(Snippet), MaxLines, ShortDescription);
        }
    }
}
