using GoogleEarthConversions.Core.KML.AbstractView.Attributes;
using System;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public class Camera : AbstractView, ICamera
    {
        public Camera()
        {
            TimePrimitive = new TimePrimitive.TimeSpan(null, null);
        }

        public string ConvertObjectToKML()
        {
            throw new NotImplementedException();
        }
    }
}
