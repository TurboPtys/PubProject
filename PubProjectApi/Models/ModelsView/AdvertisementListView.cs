using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models.ModelsView
{
    public class AdvertisementListView
    {
        public Advertisement Advertisement { get; set; }
        public GastronomicVenue GastronomicVenue { get; set; }
        public int CountLikes { get; set; }
        public IEnumerable<Like> Likes { get; set; }

    }
}
