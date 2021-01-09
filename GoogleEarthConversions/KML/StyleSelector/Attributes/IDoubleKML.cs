using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IDoubleKML : IKMLFormat
    {
        string KmlTagName { get; set; }
        double Value { get; set; }
        double Default { get; set; }
    }
}
