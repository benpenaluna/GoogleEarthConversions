using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class ItemIcon : IItemIcon
    {
        public IState State { get; set; }

        private IHref _href;
        public string Href
        {
            get => _href.Value;
            set => _href.Value = value;
        }

        public ItemIcon()
        {
            State = new State();
            _href = new Href(string.Empty);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(ItemIcon) && Equals((ItemIcon)obj);
        }

        protected bool Equals(ItemIcon other)
        {
            return Equals(State, other.State) &&
                   Equals(Href, other.Href);
        }

        public static bool operator ==(ItemIcon a, ItemIcon b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(ItemIcon a, ItemIcon b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ConvertObjectToKML()
        {
            var hrefKMLString = Href == string.Empty ? string.Empty : string.Format("<{0}>{1}</{0}>", nameof(Href).ConvertFirstCharacterToLowerCase(), Href);

            return string.Format("<{0}>{1}{2}</{0}>", nameof(ItemIcon), State.ConvertObjectToKML(), hrefKMLString);
        }
    }
}
