using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models.ModelsView.Advert
{
    public class AdvertsListView
    {

        public IEnumerable<AdvertisementListView> Adverts { get; set; }

        public SearchAdvert SearchAdvert {get;set;}

    }
}
