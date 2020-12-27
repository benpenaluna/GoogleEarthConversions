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

        public string ConvertObjectToKML()
        {
            if (Extruded == false)
                return "";

            return string.Format("<{0}>1</{0}>", nameof(Extrude).ConvertFirstCharacterToLowerCase());
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Extrude) && Equals((Extrude)obj);
        }

        protected bool Equals(Extrude other)
        {
            return Equals(Extruded, other.Extruded);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
