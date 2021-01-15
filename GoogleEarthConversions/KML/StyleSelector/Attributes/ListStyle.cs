using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class ListStyle : GoogleEarthObject, IListStyle
    {
        public IListItemType ListItemType { get; set; }
        public IColor BgColor { get; set; }
        public IItemIcon ItemIcon { get; set; }

        public ListStyle()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            ListItemType = new ListItemType();
            BgColor = new Color(nameof(BgColor).ConvertFirstCharacterToLowerCase())
            {
                Value = System.Drawing.Color.FromArgb(255, 255, 255, 255),
                DefaultColor = System.Drawing.Color.FromArgb(255, 255, 255, 255)
            };
            ItemIcon = new ItemIcon();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(ListStyle) && Equals((ListStyle)obj);
        }

        protected bool Equals(ListStyle other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(ListItemType, other.ListItemType) &&
                   Equals(BgColor, other.BgColor) &&
                   Equals(ItemIcon, other.ItemIcon);
        }

        public static bool operator ==(ListStyle a, ListStyle b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(ListStyle a, ListStyle b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ConvertObjectToKML()
        {
            var body = GetKMLBody();
            if (body == string.Empty)
                return string.Empty;

            StringWriter sw = new StringWriter();

            sw.Write(OpeningTag(GetType()));
            sw.Write(body);
            sw.Write(ClosingTag(GetType()));

            return sw.ToString();
        }

        private string GetKMLBody()
        {
            StringWriter sw = new StringWriter();

            sw.Write(ListItemType.ConvertObjectToKML());
            sw.Write(BgColor.ConvertObjectToKML());
            sw.Write(ItemIcon.ConvertObjectToKML());

            return sw.ToString();
        }
    }
}
