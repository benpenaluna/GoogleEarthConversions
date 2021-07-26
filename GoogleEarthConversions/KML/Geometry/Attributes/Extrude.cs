using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Geometry.Attributes
{
    public class Extrude : IExtrude
    {
        private bool _extruded;

        public bool Extruded
        {
            get { return _extruded; }
            set
            {
                _extruded = value;
                Extruded_Changed_OnChange(EventArgs.Empty);
            }
        }

        public event EventHandler Extruded_Changed;
        protected virtual void Extruded_Changed_OnChange(EventArgs e)
        {
            Extruded_Changed?.Invoke(this, e);
        }

        public Extrude(bool extruded = false)
        {
            Extruded = extruded;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Extrude) && Equals((Extrude)obj);
        }

        protected bool Equals(Extrude other)
        {
            return Equals(Extruded, other.Extruded);
        }

        public static bool operator ==(Extrude a, Extrude b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Extrude a, Extrude b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (Extruded == false)
                return "";

            return string.Format("<{0}>1</{0}>", nameof(Extrude).ConvertFirstCharacterToLowerCase());
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
