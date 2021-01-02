using GeoFunctions.Core.Coordinates;
using GeoFunctions.Core.Coordinates.Measurement;
using GoogleEarthConversions.Core.Geographical;
using GoogleEarthConversions.Core.KML.Geometry.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleEarthConversions.Core.KML.Object
{
    public interface ILatLonAltBox : IKMLFormat
    {
        ISphericalCoordinateKML North { get; }
        ISphericalCoordinateKML South { get; }
        ISphericalCoordinateKML East { get; }
        ISphericalCoordinateKML West { get; }
        IDistanceKML MinAltitude { get; }
        IDistanceKML MaxAltitude { get; }
        IAltitudeMode AltitudeMode { get; set; }

        void UpdateNorthAngle(IAngle angle);
        void UpdateSouthAngle(IAngle angle);
        void UpdateEastAngle(IAngle angle);
        void UpdateWestAngle(IAngle angle);
        void UpdateMinAltitude(double distance, DistanceMeasurement measurement);
        void UpdateMaxAltitude(double distance, DistanceMeasurement measurement);
    }
}
