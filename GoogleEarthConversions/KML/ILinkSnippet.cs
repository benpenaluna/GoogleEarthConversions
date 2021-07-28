using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML
{
    public interface ILinkSnippet : IKMLFormat
    {
        int MaxLines { get; set; }
    }
}
