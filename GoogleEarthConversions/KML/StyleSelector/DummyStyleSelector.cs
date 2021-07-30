using System;

namespace GoogleEarthConversions.Core.KML.StyleSelector
{
    internal class DummyStyleSelector : StyleSelector
    {
        public DummyStyleSelector()
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
