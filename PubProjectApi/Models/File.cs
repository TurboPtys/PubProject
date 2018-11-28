using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PubProjectApi.Models
{
    public class File
    {
        public Guid FileId { get; set; }
        public string FileName { get; set; }
        //public byte[] Content { get; set; }
        //public FileType FileType { get; set; }
        public Guid OwnerId { get; set; }
    }
}
