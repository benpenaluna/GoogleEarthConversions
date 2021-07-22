using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.TimePrimitive
{
    internal class DummyTimePrimitive : TimePrimitive
    {
        public DummyTimePrimitive()
        {
            Id = string.Empty;
            TargetId = string.Empty;
        }
        
        public override string SerialiseToKML()
        {
            return string.Empty;
        }
    }
}
