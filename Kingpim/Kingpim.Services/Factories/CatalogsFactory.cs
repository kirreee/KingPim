using Kingpim.DAL.Models;
using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kingpim.Services.Factories
{
    public static class CatalogsFactory
    {
        public static CatalogViewModel CatalogToViewModel(Catalog catalog, string userName)
        {
            var catalogViewModel = new CatalogViewModel()
            {
                CatalogId = catalog.Id,
                CatalogName = catalog.Name,
                CreationDate = catalog.CreationDate,
                UserName = userName
            };

            return catalogViewModel;
        }

        public static Catalog CatalogToDbo(CreateCatalogDto catalogDto)
        {
            var model = new Catalog();
            {
                model.Name = catalogDto.Name;
                model.CreationDate = DateTime.Now;
            }

            return model;
        }
    }
}
