using Kingpim.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using ValueType = Kingpim.DAL.Enums.ValueType;

namespace Kingpim.DAL.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public virtual AttributeGroup AttributeGroup { get; set; }
        public int AttributeGroupId { get; set; }
        public List<AttributeValue> AttributeValues { get; set; }
        public ValueType Value { get; set; }
    }
}
