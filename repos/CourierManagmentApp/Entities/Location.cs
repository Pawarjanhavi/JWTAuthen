using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Location
    {

        private int locationID;
        private string locationName;
        private string address;

        // Default constructor
        public Location() { }

        // Parameterized constructor
        public Location(int locationID, string locationName, string address)
        {
            this.locationID = locationID;
            this.locationName = locationName;
            this.address = address;
        }

        // Getters and setters using full syntax
        public int LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }

        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        // ToString method to provide a string representation of the object
        public override string ToString()
        {
            return $"Location [LocationID={locationID}, LocationName={locationName}, Address={address}]";
        }
    }
}
