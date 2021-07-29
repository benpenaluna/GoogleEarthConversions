using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML
{
    public interface ILinkSnippet : IKMLFormat
    {
        string KmlTagName { get; set; }
        string Value { get; set; }
        string Default { get; set; }

        int MaxLines { get; set; }
    }
}
