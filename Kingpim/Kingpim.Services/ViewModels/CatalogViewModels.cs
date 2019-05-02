using Kingpim.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.ViewModels
{
    public class CatalogViewModel
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
