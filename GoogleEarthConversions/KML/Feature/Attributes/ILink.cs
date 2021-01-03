using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public interface ILink : IKMLFormat
    {
        string Href { get; set; }
    }
}
