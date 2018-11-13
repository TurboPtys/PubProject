using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models
{
    public class Advertisement
    {
        [Key]
        public Guid AdvertisementId { get; set; }
        public DateTime DateAdded { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Boolean Active { get; set; }
        public string Tag { get; set; }
        public virtual GastronomicVenue GastronomicVenue { get; set; }
    }
}
