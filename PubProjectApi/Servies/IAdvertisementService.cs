using PubProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Servies
{
    public interface IAdvertisementService
    {
        Task<IEnumerable<Advertisement>> GetAll();
        Task<IEnumerable<Advertisement>> GetByTag(string tag);
    }
}
