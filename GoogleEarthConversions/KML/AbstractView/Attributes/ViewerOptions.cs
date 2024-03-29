﻿using GoogleEarthConversions.Core.Common;
using System;
using System.IO;

namespace GoogleEarthConversions.Core.KML.AbstractView.Attributes
{
    public class ViewerOptions : IViewerOptions
    {
        private IOption Historicalimagery { get; set; }
        public bool HistoricalimageryEnabled
        {
            get { return Historicalimagery.Enabled; }
            set { Historicalimagery.Enabled = value; }
        }
        private IOption Sunlight { get; set; }
        public bool SunlightEnabled
        {
            get { return Sunlight.Enabled; }
            set { Sunlight.Enabled = value; }
        }
        private IOption Streetview { get; set; }
        public bool StreetviewEnabled
        {
            get { return Streetview.Enabled; }
            set { Streetview.Enabled = value; }
        }

        public ViewerOptions(bool historicalimageryEnabled = false, bool sunlightEnabled = false, bool streetviewEnabled = false)
        {
            Historicalimagery = new Option(OptionName.Historicalimagery, historicalimageryEnabled);
            Sunlight = new Option(OptionName.Sunlight, sunlightEnabled);
            Streetview = new Option(OptionName.Streetview, streetviewEnabled);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(ViewerOptions) && Equals((ViewerOptions)obj);
        }

        public static bool operator ==(ViewerOptions a, ViewerOptions b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(ViewerOptions a, ViewerOptions b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        protected bool Equals(ViewerOptions other)
        {
            return Equals(Historicalimagery, other.Historicalimagery) &&
                   Equals(Sunlight, other.Sunlight) &&
                   Equals(Streetview, other.Streetview);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            StringWriter sw = new StringWriter();

            sw.Write(string.Format("<gx:{0}>", nameof(ViewerOptions)));
            sw.Write(Historicalimagery.SerialiseToKML());
            sw.Write(Sunlight.SerialiseToKML());
            sw.Write(Streetview.SerialiseToKML());
            sw.Write(string.Format("</gx:{0}>", nameof(ViewerOptions)));

            return sw.ToString();
        }

        public static ViewerOptions DeserialiseFromKML(string kml)
        {
            throw new NotImplementedException();
        }
    }
}
