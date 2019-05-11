using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.DAL.Models
{
    public class SubcategoryAttribute
    {
        public int Id { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public int SubcategoryId { get; set; }
        public virtual AttributeGroup AttributeGroup { get; set; }
        public int AttributeGroupId { get; set; }
    }
}
