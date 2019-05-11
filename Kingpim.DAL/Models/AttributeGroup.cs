using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.DAL.Models
{
    public class AttributeGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public List<Kingpim.DAL.Models.Attribute> Attributes { get; set; }
        public List<SubcategoryAttribute> SubcategoryAttributes { get; set; }
    }
}
