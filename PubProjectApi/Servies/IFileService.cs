using PubProjectApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Servies
{
    public interface IFileService
    {
        void AddFile(File file);
        Task<File> GetFile(Guid id);
    }
}
