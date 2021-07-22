using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector
{
    public interface IStyleMap : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        ICollection<IPair> Pairs { get; set; }
    }
}
