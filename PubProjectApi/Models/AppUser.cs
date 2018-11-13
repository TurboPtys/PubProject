﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models
{
    public class AppUser : IdentityUser
    {
        public bool Active { get; set; }
    }
}
