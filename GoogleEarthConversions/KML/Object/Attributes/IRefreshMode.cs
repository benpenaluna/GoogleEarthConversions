using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public interface IRefreshMode : IKMLFormat
    {
        RefreshModeEnum Value { get; set; }
    }
}
