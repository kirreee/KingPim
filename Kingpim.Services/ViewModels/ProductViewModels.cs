using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string LastModifiedBy { get; set; }
        public string VersioNumber { get; set; }
        public int Version { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModified { get; set; }
        public List<FileViewModel> Files { get; set; }
    }
}
