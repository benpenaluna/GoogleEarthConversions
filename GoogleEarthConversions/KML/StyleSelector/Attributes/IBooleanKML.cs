using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IBooleanKML : IKMLFormat
    {
        string KmlTagName { get; set; }
        bool Value { get; set; }
        bool Default { get; set; }
    }
}
