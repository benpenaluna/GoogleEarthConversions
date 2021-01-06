using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IText : IKMLFormat
    {
        string Value { get; set; }
    }
}
