using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public abstract class Container : Feature 
    {
        public ICollection<Feature> Features { get; set; }

        protected void InitialiseBaseProperties()
        {
            Features = new List<Feature>();
            InitiailiseFeatureProperties();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Container) && Equals((Container)obj);
        }

        protected bool Equals(Container other)
        {
            return Equals(Features, other.Features) &&
                   base.Equals(other);
        }

        public static bool operator ==(Container a, Container b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Container a, Container b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected string GetFeaturesKML()
        {
            StringWriter featuresKML = new StringWriter();
            foreach (var feature in Features)
            {
                featuresKML.Write(feature.SerialiseToKML());
            }

            return featuresKML.ToString();
        }
    }
}
