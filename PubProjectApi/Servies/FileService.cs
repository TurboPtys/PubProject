using PubProjectApi.Models;
using PubProjectApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Servies
{
    public class FileService: IFileService
    {
        IFileRepository _fileRepository;

        public FileService (IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public void AddFile(File file)
        {
            _fileRepository.Add(file);
        }

        public async Task<File> GetFile(Guid id)
        {
            return (await _fileRepository.GetAll()).Where(x => x.OwnerId.Equals(id)).FirstOrDefault();
        }
    }
}
