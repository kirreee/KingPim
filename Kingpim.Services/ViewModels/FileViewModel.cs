using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.ViewModels
{
    public class FileViewModel
    {
        public int FileId { get; set; }
        public string File { get; set; }
        public string FileType { get; set; }
        public bool IsPublished { get; set; }
        public bool IsMainFile { get; set; }

    }
}
