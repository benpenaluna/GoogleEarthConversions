using System;

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

        public override object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
