using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public interface IViewFormat : IKMLFormat
    {
        IBoundingBox BoundingBox { get; set; }
    }
}
