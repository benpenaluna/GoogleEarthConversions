using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.TimePrimitive
{
    public class DummyTimePrimitive : TimePrimitive
    {
        public DummyTimePrimitive()
        {
            Id = string.Empty;
            TargetId = string.Empty;
        }
        
        public override string ConvertObjectToKML()
        {
            return string.Empty;
        }
    }
}
