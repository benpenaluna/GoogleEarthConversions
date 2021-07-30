using System;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    internal class DummyAbstractView : AbstractView
    {
        public DummyAbstractView()
        {
            InitialiseBaseProperties();
        }

        public override string SerialiseToKML()
        {
            return string.Empty;
        }
    }
}
