using System;
using System.Collections.Generic;
using System.Text;

namespace Users_DASM.Models
{
    public class FileModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Size { get; set; }

        public string UploadedDate { get; set; }

        public string Category { get; set; }

        public string Status { get; set; }

        public string FilePath { get; set; }

        public string UploadedBy { get; set; }

        public string UserLevel { get; set; }
    }
}
