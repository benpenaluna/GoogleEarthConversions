using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IPair : IKMLFormat
    {
        KeyValuePair<StyleStateEnum, IStyleUrl> ModeUrlMap { get; set; }
    }
}
