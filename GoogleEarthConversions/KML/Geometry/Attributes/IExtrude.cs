using System;

namespace GoogleEarthConversions.Core.KML.Geometry.Attributes
{
    public interface IExtrude : IKMLFormat
    {
        bool Extruded { get; set; }

        event EventHandler Extruded_Changed;
    }
}
