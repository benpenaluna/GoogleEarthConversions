using GoogleEarthConversions.Core.KML.StyleSelector.Attributes;
using System.Collections.Generic;

namespace GoogleEarthConversions.Core.KML.StyleSelector
{
    public interface IStyleMap : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        ICollection<IPair> Pairs { get; set; }
    }
}
