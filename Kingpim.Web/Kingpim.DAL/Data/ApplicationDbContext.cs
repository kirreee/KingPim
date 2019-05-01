using System;
using System.Collections.Generic;
using System.Text;
using Kingpim.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kingpim.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Kingpim.DAL.Models.Attribute>Attributes { get; set; }
        public DbSet<AttributeGroup> AttributeGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<ReadOnlyAttribute> ReadOnlyAttributes { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }

    }
}
