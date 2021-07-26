using System.Collections.Generic;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IPair : IKMLFormat
    {
        KeyValuePair<StyleStateEnum, IStyleUrl> ModeUrlMap { get; set; }
    }
}
