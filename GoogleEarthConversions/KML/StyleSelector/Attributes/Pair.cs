using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class Pair : IPair
    {
        public KeyValuePair<StyleStateEnum, IStyleUrl> ModeUrlMap { get; set; }

        public Pair(IStyleUrl styleUrl, StyleStateEnum styleStateEnum = StyleStateEnum.Normal)
        {
            ModeUrlMap = new KeyValuePair<StyleStateEnum, IStyleUrl>(styleStateEnum, styleUrl);
        }

        public Pair(Uri url, StyleStateEnum styleStateEnum = StyleStateEnum.Normal)
        {
            var styleUrl = new StyleUrl(url);
            ModeUrlMap = new KeyValuePair<StyleStateEnum, IStyleUrl>(styleStateEnum, styleUrl);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Pair) && Equals((Pair)obj);
        }

        protected bool Equals(Pair other)
        {
            return Equals(ModeUrlMap, other.ModeUrlMap);
        }

        public static bool operator ==(Pair a, Pair b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Pair a, Pair b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            return string.Format("<{0}><{1}>{2}</{1}>{3}</{0}>", nameof(Pair),
                                                                            "key",
                                                                            ModeUrlMap.Key.ToString().ConvertFirstCharacterToLowerCase(),
                                                                            ModeUrlMap.Value.SerialiseToKML());
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
