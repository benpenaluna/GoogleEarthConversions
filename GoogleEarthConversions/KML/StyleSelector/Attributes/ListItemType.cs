using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class ListItemType : IListItemType
    {
        public ListItemTypeEnum ItemType { get; set; }

        public ListItemType(ListItemTypeEnum itemType = ListItemTypeEnum.Check)
        {
            ItemType = itemType;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(ListItemType) && Equals((ListItemType)obj);
        }

        protected bool Equals(ListItemType other)
        {
            return Equals(ItemType, other.ItemType);
        }

        public static bool operator ==(ListItemType a, ListItemType b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(ListItemType a, ListItemType b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (ItemType == ListItemTypeEnum.Check)
                return "";
            
            return string.Format("<{0}>{1}</{0}>", nameof(ListItemType).ConvertFirstCharacterToLowerCase(),
                                                   ItemType.ToString().ConvertFirstCharacterToLowerCase());
        }
    }
}
