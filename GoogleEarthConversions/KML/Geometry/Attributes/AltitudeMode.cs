using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Geometry.Attributes
{
    public class AltitudeMode : IAltitudeMode
    {
        private AltMode _altMode;

        public AltMode AltMode
        {
            get { return _altMode; }
            set
            {
                _altMode = value;
                AltMode_OnChange(EventArgs.Empty);
            }
        }

        public event EventHandler AltMode_Changed;
        protected virtual void AltMode_OnChange(EventArgs e)
        {
            AltMode_Changed?.Invoke(this, e);
        }


        public AltitudeMode(AltMode altMode = AltMode.ClampToGround)
        {
            AltMode = altMode;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(AltitudeMode) && Equals((AltitudeMode)obj);
        }

        protected bool Equals(AltitudeMode other)
        {
            return Equals(AltMode, other.AltMode);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (AltMode == AltMode.ClampToGround)
                return "";

            if (AltMode == AltMode.ClampToSeaFloor || AltMode == AltMode.RelativeToSeaFloor)
                return string.Format("<gx:{0}>{1}</gx:{0}>", nameof(AltitudeMode).ConvertFirstCharacterToLowerCase(),
                                                             AltMode.ToString().ConvertFirstCharacterToLowerCase());


            return string.Format("<{0}>{1}</{0}>", nameof(AltitudeMode).ConvertFirstCharacterToLowerCase(),
                                                   AltMode.ToString().ConvertFirstCharacterToLowerCase());
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
