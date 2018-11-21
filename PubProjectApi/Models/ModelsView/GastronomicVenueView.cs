using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models.ModelsView
{
    public class GastronomicVenueView
    {
        public IEnumerable<Advertisement> Advertisements { get; set; }
        public GastronomicVenue GastronomicVenue { get; set; }
        public double Grade { get; set; }
    }
}
