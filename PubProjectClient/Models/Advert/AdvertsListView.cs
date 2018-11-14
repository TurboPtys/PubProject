using PubProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectClient.Models.Advert
{
    public class AdvertsListView
    {
        public Advertisement Advert { get; set; }
        public GastronomicVenue GastronomicVenue { get; set; }
    }
}
