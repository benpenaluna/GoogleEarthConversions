using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class DummyFeature : Feature
    {
        public DummyFeature()
        {
            InitiailiseFeatureProperties();
        }

        public override string SerialiseToKML()
        {
            return string.Empty;
        }
    }
}
