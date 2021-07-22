using GoogleEarthConversions.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object.Attributes
{
    public class LodElement : ILodElement
    {
        private Func<ILodElement, string> _convertObjectToKML;

        public double Value { get; set; }

        public LodElement(Func<ILodElement, string> convertObjectToKML, double value = 0.0)
        {
            _convertObjectToKML = convertObjectToKML;
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(LodElement) && Equals((LodElement)obj);
        }

        protected bool Equals(LodElement other)
        {
            return Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(LodElement a, LodElement b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(LodElement a, LodElement b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public string SerialiseToKML()
        {
            if (_convertObjectToKML != null)
                return _convertObjectToKML(this);

            return string.Format("<{0}>{1}</{0}>", nameof(LodElement).ConvertFirstCharacterToLowerCase(), Value);
        }
    }
}
