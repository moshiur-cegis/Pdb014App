using System;
using System.Collections.Generic;
using System.Linq;

namespace Pdb014App.Models.Basic
{
    public class GeoCoordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoCoordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    public static class GeoCoordinateDistanceExtensions
    {
        private const double _fact = Math.PI / 180;

        public static double GetDistanceTo(this GeoCoordinate baseCrd, GeoCoordinate targetCrd)
        {
            if (double.IsNaN(baseCrd.Latitude) || double.IsNaN(baseCrd.Longitude) ||
                double.IsNaN(targetCrd.Latitude) || double.IsNaN(targetCrd.Longitude))
            {
                return 0.0;
            }

            var baseRad = baseCrd.Latitude * _fact;
            var targetRad = targetCrd.Latitude * _fact;
            var theta = baseCrd.Longitude - targetCrd.Longitude;
            var thetaRad = theta * _fact;

            double dist = Math.Sin(baseRad) * Math.Sin(targetRad) +
                          Math.Cos(baseRad) * Math.Cos(targetRad) * Math.Cos(thetaRad);

            return Math.Acos(dist) * 6378137.0;
        }

        public static double DistanceTo(this GeoCoordinate startCrd, GeoCoordinate endCrd)
        {
            if (double.IsNaN(startCrd.Latitude) || double.IsNaN(startCrd.Longitude) ||
                double.IsNaN(endCrd.Latitude) || double.IsNaN(endCrd.Longitude))
            {
                return 0.0;
            }

            var sLat = startCrd.Latitude * _fact;
            var eLat = endCrd.Latitude * _fact;
            double dLat = eLat - sLat;
            double dLon = (endCrd.Longitude - startCrd.Longitude) * _fact;

            double dist = Math.Pow(Math.Sin(dLat / 2), 2) +
                       Math.Cos(sLat) * Math.Cos(eLat) * Math.Pow(Math.Sin(dLon / 2), 2);

            return 6378137.0 * 2 * Math.Asin(Math.Sqrt(dist));
        }

    }

}

