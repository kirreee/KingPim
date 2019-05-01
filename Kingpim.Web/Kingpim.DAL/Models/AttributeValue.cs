using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.DAL.Models
{
   public class AttributeValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual Kingpim.DAL.Models.Attribute Attribute { get; set; }
        public int AttributeId { get; set; }
        
    }
}
