using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public interface IListItemType : IKMLFormat
    {
        ListItemTypeEnum ItemType { get; set; }
    }
}
