using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.DAL.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
