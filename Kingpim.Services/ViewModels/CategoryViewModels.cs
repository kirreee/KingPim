using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CatalogName { get; set; }
        public string CreatedBy { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
