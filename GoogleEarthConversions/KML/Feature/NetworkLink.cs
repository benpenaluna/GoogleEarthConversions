using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Feature.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public class NetworkLink : Feature, INetworkLink
    {
        public IBooleanKML RefreshVisibility { get; set; }
        public IBooleanKML FlyToView { get; set; }

        public NetworkLink(IBasicLink link)
        {
            InitiailiseFeatureProperties();
            InitialiseNetworkLinkProperties(link);
        }

        private void InitialiseNetworkLinkProperties(IBasicLink link)
        {
            RefreshVisibility = new BooleanKML(nameof(RefreshVisibility).ConvertFirstCharacterToLowerCase()) { Value = false, Default = false };
            FlyToView = new BooleanKML(nameof(FlyToView).ConvertFirstCharacterToLowerCase()) { Value = false, Default = false };
            Link = link ?? throw new NullReferenceException(string.Format("'{0}' must not be null.", nameof(link)));
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(NetworkLink) && Equals((NetworkLink)obj);
        }

        protected bool Equals(NetworkLink other)
        {
            return Equals(RefreshVisibility, other.RefreshVisibility) &&
                   Equals(FlyToView, other.FlyToView) &&
                   base.Equals(other);
        }

        public static bool operator ==(NetworkLink a, NetworkLink b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(NetworkLink a, NetworkLink b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string SerialiseToKML()
        {
            var baseKML = GetFeatureKMLTags(includeTypeTag: false);
            var refreshVisibilityKML = RefreshVisibility.SerialiseToKML();
            var flyToViewKML = FlyToView.SerialiseToKML();

            return string.Format("<{0}>{1}{2}{3}</{0}>", nameof(NetworkLink), baseKML, refreshVisibilityKML, flyToViewKML); 
        }
    }
}
