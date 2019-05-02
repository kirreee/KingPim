using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.DAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Catalog> Catalogs { get; set; }
    }
}
