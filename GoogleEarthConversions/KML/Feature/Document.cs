﻿using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;

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

        public override string SerialiseToKML()
        {
            var baseKML = GetFeatureKMLTags(includeTypeTag: false);

            return string.Format("<{0}>{1}{2}{3}</{0}>", nameof(Document), baseKML, GetStylesKML(), GetFeaturesKML());
        }

        private string GetStylesKML()
        {
            StringWriter stylesKML = new StringWriter();
            foreach (var styleSelector in StyleSelectors)
            {
                stylesKML.Write(styleSelector.SerialiseToKML());
            }

            return stylesKML.ToString();
        }

        public static Document DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
