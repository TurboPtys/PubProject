using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models.ModelsView.Advert
{
    public class AddAdvert
    {
        public string Title { get; set; }
        public string Discription { get; set; }
        public DateTime DateEvent { get; set; }
        public IFormFile File { get; set; }
        public Guid OwnerId { get; set; }
        public string Tag { get; set; }
    }
}
