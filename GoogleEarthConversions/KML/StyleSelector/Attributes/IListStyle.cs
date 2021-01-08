using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IListStyle : IKMLFormat
    {
        string Id { get; set; }
        string TargetId { get; set; }
        IListItemType ListItemType { get; set; }
        IColor BgColor { get; set; }
        IItemIcon ItemIcon { get; set; }
    }
}
