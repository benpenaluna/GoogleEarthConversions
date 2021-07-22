using GoogleEarthConversions.Core.KML;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.Common
{
    public interface IBooleanKML : IKMLFormat
    {
        string KmlTagName { get; set; }
        bool Value { get; set; }
        bool Default { get; set; }
    }
}
