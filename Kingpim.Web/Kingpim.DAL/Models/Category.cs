﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Subcategory>Subcategories { get; set; }
        public virtual Catalog Catalog { get; set; }
        public int CatalogId { get; set; }
        public bool IsPublished { get; set; }
    }
}
