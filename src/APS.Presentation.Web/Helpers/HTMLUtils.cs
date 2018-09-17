using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APS.Presentation.Web.Helpers
{
    public static class HTMLUtils
    {
        public static string DistanciaLatitudeLongitude(double lat, double lon) {

            var lat2 = (double)HttpContext.Current.Session["Latitude"];
            var lon2 = (double)HttpContext.Current.Session["Longitude"];

            Func<double, double> deg2rad = (deg) =>
            {
                return deg * (Math.PI / 180);
            };

            var R = 6371; // Radius of the earth in km
            var dLat = deg2rad(lat2 - lat);  // deg2rad below
            var dLon = deg2rad(lon2 - lon);
            var a =
              Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
              Math.Cos(deg2rad(lat)) * Math.Cos(deg2rad(lat2)) *
              Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
              ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = Math.Round(R * c); // Distance em km

            var post = "km";
            if (d < 1000)
                post = "m";

            return $"{d.ToString()}{post}";
        }
    }
}