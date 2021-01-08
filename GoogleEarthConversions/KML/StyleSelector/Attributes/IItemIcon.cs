using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IItemIcon : IKMLFormat
    {
        IState State { get; set; }
        string Href { get; set; }
    }
}
