using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models.ModelsView.Venue
{
    public class GastronomicVenueListView
    {
        public IEnumerable<GastronomicVenue> GastronomicVenues { get; set; }
        public SearchVenue SearchVenue { get; set; }
    }
}
