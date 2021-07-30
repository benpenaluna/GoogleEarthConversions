using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    public class HotSpot : IHotSpot
    {
        public double X { get; set; }
        public double Y { get; set; }
        public UnitsEnum Xunits { get; set; }
        public UnitsEnum Yunits { get; set; }

        public HotSpot()
        {
            X = 0.5;
            Y = 0.5;
            Xunits = UnitsEnum.Fraction;
            Yunits = UnitsEnum.Fraction;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(HotSpot) && Equals((HotSpot)obj);
        }

        protected bool Equals(HotSpot other)
        {
            return Equals(X, other.X) &&
                   Equals(Y, other.Y) &&
                   Equals(Xunits, other.Xunits) &&
                   Equals(Yunits, other.Yunits);
        }

        public static bool operator ==(HotSpot a, HotSpot b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(HotSpot a, HotSpot b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (X == 0.5 && Y == 0.5 && Xunits == UnitsEnum.Fraction && Yunits == UnitsEnum.Fraction)
                return string.Empty;

            return string.Format("<{0} {1}=\"{2}\" {3}=\"{4}\" {5}=\"{6}\" {7}=\"{8}\"/>",
                                 nameof(HotSpot).ConvertFirstCharacterToLowerCase(),
                                 nameof(X).ConvertFirstCharacterToLowerCase(), X,
                                 nameof(Y).ConvertFirstCharacterToLowerCase(), Y,
                                 nameof(Xunits).ConvertFirstCharacterToLowerCase(), Xunits.ToString().ConvertFirstCharacterToLowerCase(),
                                 nameof(Yunits).ConvertFirstCharacterToLowerCase(), Yunits.ToString().ConvertFirstCharacterToLowerCase());
        }

        public static HotSpot DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
