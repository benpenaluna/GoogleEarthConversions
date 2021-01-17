using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    internal class DummyAbstractView : AbstractView
    {
        public DummyAbstractView()
        {
            InitialiseBaseProperties();
        }
        
        public override string ConvertObjectToKML()
        {
            return string.Empty;
        }
    }
}
