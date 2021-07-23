using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public interface IViewRefreshMode : IKMLFormat
    {
        ViewRefreshModeEnum Value { get; set; }
    }
}
