using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models
{
    public class GastronomicVenue
    {
        public Guid GastronomicVenueId { get; set; }
        public string GastronomicVenueName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? HouseNr { get; set; }
        public int? LocalNr { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public Boolean Active { get; set; }
        //godziny otwarcia
    }
}
