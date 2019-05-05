using Kingpim.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using ValueType = Kingpim.DAL.Enums.ValueType;

namespace Kingpim.Services.ViewModels
{
    public class AttributeViewModel
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public string AttributeGroupName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string ValueType { get; set; }
    }
}
