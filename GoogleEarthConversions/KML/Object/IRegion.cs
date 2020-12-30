using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object
{
    public interface IRegion
    {
        string Id { get; set; }
        string TargetId { get; set; }
    }
}
