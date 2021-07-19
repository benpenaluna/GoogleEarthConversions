using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public interface IData : IKMLFormat
    {
        string Name { get; set; }
        string DisplayName { get; set; }
        string Value { get; set; }
    }
}
