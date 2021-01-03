using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public interface IAuthor : IKMLFormat
    {
        string Name { get; set; }
    }
}
