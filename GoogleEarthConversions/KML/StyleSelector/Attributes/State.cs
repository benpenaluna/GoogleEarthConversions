using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class State : IState
    {
        private const ItemStateModeEnum DefaultStateMode = ItemStateModeEnum.Open;
        private const ItemIconModeEnum DefaultIconMode = ItemIconModeEnum.Nil;

        public ItemStateModeEnum ItemStateMode { get; set; }
        public ItemIconModeEnum ItemIconMode { get; set; }

        public State(ItemStateModeEnum stateMode = DefaultStateMode, ItemIconModeEnum iconMode = DefaultIconMode)
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

        public string SerialiseToKML()
        {
            if (ItemStateMode == DefaultStateMode && ItemIconMode == DefaultIconMode)
                return string.Empty;

            var stateString = ItemStateMode.ToString().ConvertFirstCharacterToLowerCase();

            if (ItemIconMode != ItemIconModeEnum.Nil)
                stateString += " " + ItemIconMode.ToString().ConvertFirstCharacterToLowerCase();

            return string.Format("<{0}>{1}</{0}>", nameof(State).ConvertFirstCharacterToLowerCase(), stateString);
        }

        public static State DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
