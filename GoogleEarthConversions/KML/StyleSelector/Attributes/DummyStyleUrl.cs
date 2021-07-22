using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.StyleSelector.Attributes
{
    internal class DummyStyleUrl : IStyleUrl
    {
        public Uri Url { get; set; }

        public DummyStyleUrl()
        {
            Url = new Uri("http://google.com/");
        }

        public string SerialiseToKML()
        {
            return string.Empty;
        }
    }
}
