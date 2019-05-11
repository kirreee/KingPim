using Kingpim.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.ViewModels
{
    public class SubcategoryViewModel
    {
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public string CategoryName { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public List<AttributeGroupViewModel> AttributeGroups { get; set; }
    }
}
