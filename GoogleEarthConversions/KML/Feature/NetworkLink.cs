using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Object;
using System;

namespace GoogleEarthConversions.Core.KML.Feature
{
    public class NetworkLink : Feature, INetworkLink
    {
        public IBooleanKML RefreshVisibility { get; set; }
        public IBooleanKML FlyToView { get; set; }
        public ILink Link { get; set; }

        public NetworkLink(ILink link)
        {
            if (link == null)
                throw new ArgumentNullException(string.Format("{0} must be a valid Link, not a null reference.", nameof(link)));

            if (!HrefUriIsValid(link.Href.Value, out string errorMessage))
                throw new UriFormatException(errorMessage);

            InitialiseNetworkLinkProperties(link);
        }

        public NetworkLink(string uri)
        {
            if (uri == null || uri == string.Empty)
                throw new ArgumentNullException(string.Format("{0} must be a valid Uri, not a null reference or empty string.", nameof(uri)));

            IHref href;
            try { href = new Href(uri); }
            catch (UriFormatException) { throw; }

            ILink link = new Link() { Href = href };
            InitialiseNetworkLinkProperties(link);
        }

        private static bool HrefUriIsValid(string href, out string errorMessage)
        {
            try { var uri = new Uri(href); }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        private void InitialiseNetworkLinkProperties(ILink link)
        {
            InitiailiseFeatureProperties();

            RefreshVisibility = new BooleanKML(nameof(RefreshVisibility).ConvertFirstCharacterToLowerCase()) { Value = false, Default = false };
            FlyToView = new BooleanKML(nameof(FlyToView).ConvertFirstCharacterToLowerCase()) { Value = false, Default = false };

            Link = link ?? new Link();
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
            var linkKML = Link.SerialiseToKML();

            return string.Format("<{0}>{1}{2}{3}{4}</{0}>", nameof(NetworkLink), baseKML, refreshVisibilityKML, flyToViewKML, linkKML);
        }

        public override object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
