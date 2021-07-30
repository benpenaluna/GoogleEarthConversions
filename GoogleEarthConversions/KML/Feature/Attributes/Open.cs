using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Feature.Attributes
{
    public class Open : IOpen
    {
        public FolderAppearance Appearance { get; set; }

        public Open(FolderAppearance appearance = FolderAppearance.Collapsed)
        {
            Appearance = appearance;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Open) && Equals((Open)obj);
        }

        protected bool Equals(Open other)
        {
            return Equals(Appearance, other.Appearance);
        }

        public static bool operator ==(Open a, Open b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Open a, Open b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Appearance == FolderAppearance.Collapsed)
                return "";

            return string.Format("<{0}>1</{0}>", nameof(Open).ConvertFirstCharacterToLowerCase());
        }

        public static Open DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
