using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IStyleUrl : IKMLFormat
    {
        Uri Url { get; set; }
    }
}
