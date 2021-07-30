using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML
{
    public interface IKml : IKMLFormat
    {
        string XmlDeclaration { get; set; }
        IDictionary<string, IHref> XmlNameSpaces { get; set; }
        INetworkLinkControl NetworkLinkControl { get; set; } 
        Feature.Feature Feature { get; set; }
        KmlHint Hint { get; set; }
    }
}
