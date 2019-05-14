using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.DAL.Models
{
    public class SystemAttribute
    {
        public int Id { get; set; }
        public string LastModifiedBy { get; set; }
        public string VersioNumber { get; set; }
        public int Version { get; set; }
        public bool IsPublished { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
