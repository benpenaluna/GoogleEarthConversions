using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Geometry
{
    public abstract class Geometry : GoogleEarthObject, IKMLFormat
    {
        protected IAltitudeMode _altitudeMode;
        public IAltitudeMode AltitudeMode
        {
            get { return _altitudeMode; }
            set
            {
                _altitudeMode = value;
                AltitudeMode.AltMode_Changed += AltMode_OnChanged;
            }
        }

        private void AltMode_OnChanged(object sender, EventArgs e)
        {
            if (AltitudeMode.AltMode == AltMode.ClampToGround || AltitudeMode.AltMode == AltMode.ClampToSeaFloor)
                _extrude.Extruded = false;
        }

        private IExtrude _extrude;
        public IExtrude Extrude
        {
            get { return _extrude; }
            set
            {
                if (value.Extruded == false || (_altitudeMode.AltMode != AltMode.ClampToGround && _altitudeMode.AltMode != AltMode.ClampToSeaFloor))
                {
                    _extrude = value;
                    Extrude.Extruded_Changed += Extrude_OnChanged;
                }
                else
                    ThrowInvalidOperationExceptionOnExtrude();
            }
        }

        private void Extrude_OnChanged(object sender, EventArgs e)
        {
            if (Extrude.Extruded == false)
                return;

            if (AltitudeMode.AltMode == AltMode.ClampToGround || AltitudeMode.AltMode == AltMode.ClampToSeaFloor)
            {
                Extrude.Extruded = false;
                ThrowInvalidOperationExceptionOnExtrude();
            }
        }

        private void ThrowInvalidOperationExceptionOnExtrude()
        {
            var message = string.Format("Property '{0}' cannot be set to true when '{1}' is set to '{2}' or '{3}'.",
                                                            nameof(Extrude.Extruded),
                                                            nameof(AltitudeMode.AltMode),
                                                            nameof(AltMode.ClampToGround),
                                                            nameof(AltMode.ClampToSeaFloor));
            throw new InvalidOperationException(message);
        }

        public abstract string ConvertObjectToKML();

        protected string OpeningTag(Type type)
        {
            return string.Format("<{0} {1}=\"{2}\">", type.Name, nameof(Id).ConvertFirstCharacterToLowerCase(), Id);
        }

        protected string ClosingTag(Type type)
        {
            return string.Format("</{0}>", type.Name);
        }
    }
}
