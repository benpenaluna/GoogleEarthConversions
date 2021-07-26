using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.Object.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object
{
    public class Link : GoogleEarthObject, ILink
    {
        public IHref Href { get; set; }
        public IRefreshMode RefreshMode { get; set; }
        public IDoubleKML RefreshInterval { get; set; }
        public IViewRefreshMode ViewRefreshMode { get; set; }
        public IDoubleKML ViewRefreshTime { get; set; }
        public IDoubleKML ViewBoundScale { get; set; }
        public IViewFormat ViewFormat { get; set; }

        public Link()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            Href = new Href(string.Empty);
            RefreshMode = new RefreshMode();
            RefreshInterval = new DoubleKML(nameof(RefreshInterval).ConvertFirstCharacterToLowerCase());
            ViewRefreshMode = new ViewRefreshMode();
            ViewRefreshTime = new DoubleKML(nameof(ViewRefreshTime).ConvertFirstCharacterToLowerCase());
            ViewBoundScale = new DoubleKML(nameof(ViewBoundScale).ConvertFirstCharacterToLowerCase()) { Value = 1.0 };
            ViewFormat = new ViewFormat();
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(Link) && Equals((Link)obj);
        }

        protected bool Equals(Link other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(Href, other.Href) &&
                   Equals(RefreshMode, other.RefreshMode) &&
                   Equals(RefreshInterval, other.RefreshInterval) &&
                   Equals(ViewRefreshMode, other.ViewRefreshMode) &&
                   Equals(ViewRefreshTime, other.ViewRefreshTime) &&
                   Equals(ViewBoundScale, other.ViewBoundScale) &&
                   Equals(ViewFormat, other.ViewFormat);
        }

        public static bool operator ==(Link a, Link b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(Link a, Link b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            var body = string.Format("{0}{1}{2}{3}{4}{5}{6}", GetHrefKML(),
                                                              RefreshMode.SerialiseToKML(),
                                                              GetRefreshInterval(),
                                                              ViewRefreshMode.SerialiseToKML(),
                                                              GetViewRefreshTime(),
                                                              GetViewBoundScale(),
                                                              GetViewFormatKML());


            return body == string.Empty ? string.Empty : string.Format("<{0}>{1}</{0}>", nameof(Link), body);
        }

        private string GetHrefKML()
        {
            if (Href.Value == string.Empty)
                return string.Empty;
            
            return string.Format("<{0}>{1}</{0}>", nameof(Href).ConvertFirstCharacterToLowerCase(), Href.Value);
        }

        private string GetRefreshInterval()
        {
            if (RefreshInterval.Value == 0.0)
                return string.Empty;

            return RefreshInterval.SerialiseToKML();
        }

        private string GetViewRefreshTime()
        {
            if (ViewRefreshTime.Value == 0.0)
                return string.Empty;

            return ViewRefreshTime.SerialiseToKML();
        }

        private string GetViewBoundScale()
        {
            if (ViewBoundScale.Value == 1.0)
                return string.Empty;

            return ViewBoundScale.SerialiseToKML();
        }

        private string GetViewFormatKML()
        {
            Uri hrefUri;
            try { hrefUri = new Uri(Href.Value); }
            catch { return string.Empty; }

            if (Href.Value == string.Empty || hrefUri.IsFile)
                return string.Empty;

            return ViewFormat.SerialiseToKML();
        }

        public object DeserialiseFromKML()
        {
            throw new NotImplementedException();
        }
    }
}
