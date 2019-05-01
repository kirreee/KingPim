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
    }
}
