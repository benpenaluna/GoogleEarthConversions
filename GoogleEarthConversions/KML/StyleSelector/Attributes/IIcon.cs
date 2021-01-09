using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IIcon : IKMLFormat
    {
        string Href { get; set; }
    }
}
