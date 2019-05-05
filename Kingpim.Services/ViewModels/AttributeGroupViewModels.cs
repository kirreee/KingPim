using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.ViewModels
{
    public class AttributeGroupViewModel
    {
        public int AttributeGroupId { get; set; }
        public string AttributeGroupName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
