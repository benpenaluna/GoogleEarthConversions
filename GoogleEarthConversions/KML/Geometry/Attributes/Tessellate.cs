using GoogleEarthConversions.Core.Common;
using System;

namespace GoogleEarthConversions.Core.KML.Geometry.Attributes
{
    public class Tessellate : ITessellate
    {
        private bool _followsTerrain;

        public bool FollowsTerrain
        {
            get { return _followsTerrain; }
            set
            {
                _followsTerrain = value;
                FollowsTerrain_OnChange(EventArgs.Empty);
            }
        }

        public event EventHandler FollowsTerrain_Changed;
        protected virtual void FollowsTerrain_OnChange(EventArgs e)
        {
            FollowsTerrain_Changed?.Invoke(this, e);
        }

        public Tessellate(bool followsTerrain = false)
        {
            FollowsTerrain = followsTerrain;
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Tessellate) && Equals((Tessellate)obj);
        }

        protected bool Equals(Tessellate other)
        {
            return Equals(FollowsTerrain, other.FollowsTerrain);
        }

        public static bool operator ==(Tessellate a, Tessellate b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Tessellate a, Tessellate b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            if (FollowsTerrain == false)
                return "";

            return string.Format("<{0}>1</{0}>", nameof(Tessellate).ConvertFirstCharacterToLowerCase());
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
