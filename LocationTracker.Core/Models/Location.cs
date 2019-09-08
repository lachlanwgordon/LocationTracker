using System;
namespace LocationTracker.Core
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool ShouldRemove { get; set; }
        public string Name { get; set; }

        public Location()
        {
        }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}
