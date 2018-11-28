﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models
{
    public class GastronomicVenue
    {
        public Guid GastronomicVenueId { get; set; }
        public string GastronomicVenueName { get; set; }
        public string GastronomicVenueDescription { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? HouseNr { get; set; }
        public int? LocalNr { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public Boolean Active { get; set; }
        public string PostCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public int? SumGrade { get; set; }
        public int? Grades { get; set; }
        public double? Grade { get; set; }
        //godziny otwarcia
    }
}
