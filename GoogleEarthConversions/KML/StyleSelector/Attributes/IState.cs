using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IState : IKMLFormat
    {
        ItemStateModeEnum ItemStateMode { get; set; }
        ItemIconModeEnum ItemIconMode { get; set; }
    }
}
