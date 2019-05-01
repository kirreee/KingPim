using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.DAL.Models
{
   public class ReadOnlyAttribute
    {
        public int Id { get; set; }
        public DateTime LastModified { get; set; }
        public string LastModifiedBy { get; set; }
        public int Version { get; set; }
        public bool IsPublish { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
