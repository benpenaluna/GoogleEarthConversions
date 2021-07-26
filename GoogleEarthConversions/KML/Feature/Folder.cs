using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public class Folder : Container, IFolder
    {
        public Folder()
        {
            InitialiseBaseProperties();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Folder) && Equals((Folder)obj);
        }

        protected bool Equals(Folder other)
        {
            return Equals(Id, other.Id) &&
                   base.Equals(other);
        }

        public static bool operator ==(Folder a, Folder b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Folder a, Folder b)
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

            return string.Format("<{0}>{1}{2}</{0}>", nameof(Folder), baseKML, GetFeaturesKML());
        }

        public override object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
