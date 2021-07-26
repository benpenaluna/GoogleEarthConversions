using GoogleEarthConversions.Core.Common;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class HorizFov : IHorizFov
    {
        public double HorizontalFieldOfView { get; set; }

        public HorizFov(double horizontalFieldOfView = 60.0)
        {
            HorizontalFieldOfView = horizontalFieldOfView;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(HorizFov) && Equals((HorizFov)obj);
        }

        protected bool Equals(HorizFov other)
        {
            return Equals(HorizontalFieldOfView, other.HorizontalFieldOfView);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            return string.Format("<gx:{0}>{1}</gx:{0}>",
                                 nameof(HorizFov).ConvertFirstCharacterToLowerCase(),
                                 HorizontalFieldOfView);
        }

        public object DeserialiseFromKML()
        {
            throw new System.NotImplementedException();
        }
    }
}
