using Kingpim.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.DAL.Models
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual AttributeGroup AttributeGroup { get; set; }
        public int AttributeGroupId { get; set; }
        public List<AttributeValue> AttributeValues { get; set; }
        public Value Value { get; set; }
    }
}
