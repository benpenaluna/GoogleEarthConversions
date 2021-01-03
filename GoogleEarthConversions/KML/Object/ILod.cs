using GoogleEarthConversions.Core.KML.Object.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object
{
    public interface ILod : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        ILodElement MinLodPixels { get; set; }
        ILodElement MaxLodPixels { get; set; }
        ILodElement MinFadeExtent { get; set; }
        ILodElement MaxFadeExtent { get; set; }
    }
}
