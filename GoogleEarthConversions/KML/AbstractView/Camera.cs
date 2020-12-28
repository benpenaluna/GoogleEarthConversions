using System;

namespace GoogleEarthConversions.Core.KML.AbstractView
{
    public class Camera : ICamera
    {
        public TimePrimitive.TimePrimitive TimePrimitive { get; set; }

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
