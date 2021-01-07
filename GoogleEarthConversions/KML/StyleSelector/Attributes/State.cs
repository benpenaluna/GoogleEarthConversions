using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class State : IState
    {
        public ItemStateModeEnum ItemStateMode { get; set; }
        public ItemIconModeEnum ItemIconMode { get; set; }

        public State(ItemStateModeEnum stateMode = ItemStateModeEnum.Open, ItemIconModeEnum iconMode = ItemIconModeEnum.Nil)
        {
            ItemStateMode = stateMode;
            ItemIconMode = iconMode;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(State) && Equals((State)obj);
        }

        protected bool Equals(State other)
        {
            return Equals(ItemStateMode, other.ItemStateMode) &&
                   Equals(ItemIconMode, other.ItemIconMode);
        }

        public static bool operator ==(State a, State b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(State a, State b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string ConvertObjectToKML()
        {
            var stateString = ItemStateMode.ToString().ConvertFirstCharacterToLowerCase();

            if (ItemIconMode != ItemIconModeEnum.Nil)
                stateString += " " + ItemIconMode.ToString().ConvertFirstCharacterToLowerCase();

            return string.Format("<{0}>{1}</{0}>", nameof(State).ConvertFirstCharacterToLowerCase(), stateString);
        }
    }
}
