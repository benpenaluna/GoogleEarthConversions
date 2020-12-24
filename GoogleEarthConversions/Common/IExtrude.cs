using GoogleEarthConversions.Core.KML;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.Common
{
    public interface IExtrude : IKMLFormat
    {
        bool Extruded { get; set; }

        event EventHandler Extruded_Changed;
    }
}
