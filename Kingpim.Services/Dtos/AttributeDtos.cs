using Kingpim.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using ValueType = Kingpim.DAL.Enums.ValueType;

namespace Kingpim.Services.Dtos
{
    public class CreateAttributeDto
    {
        public string AttributeName { get; set; }
        public int AttributeGroupId { get; set; }
        public int ValueTypeId { get; set; }
    }

    public class UpdateAttributeDto
    {
        public string AttributeName { get; set; }
        public int AttributeGroupId { get; set; }
        public int ValueTypeId { get; set; }
    }
}
