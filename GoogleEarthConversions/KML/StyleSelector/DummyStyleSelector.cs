using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector
{
    internal class DummyStyleSelector : StyleSelector
    {
        public DummyStyleSelector()
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
