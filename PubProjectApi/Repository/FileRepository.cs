using PubProjectApi.Models;
using PubProjectApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Repository
{
    public class FileRepository: Repository<File>, IFileRepository
    {
        public FileRepository(ApplicationDbContext context) : base(context) { }
        
   
    }
}
