using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models.ModelsView.Advert
{
    public class AddLike
    {
        public Guid UserId { get; set; }
        public Guid AdvertId { get; set;}

    }
}
