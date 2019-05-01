﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.DAL.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Product> Products { get; set; }
    }
}
