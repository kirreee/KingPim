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
        public static List<CatalogViewModel> CatalogToViewModel(List<Catalog> catalogs)
        {
            var catalogsViewModel = new List<CatalogViewModel>();
            var listOfCategoryNames = new List<string>();

            catalogs.ForEach(catalog =>
            {
                if (catalog.Categories != null)
                {
                    List<Category> categories = catalog.Categories.ToList();
                    categories.ForEach(category =>
                    {
                        listOfCategoryNames.Add(category.Name);
                    });
                }

                if(listOfCategoryNames.Count <= 0)
                {
                    listOfCategoryNames.Add("Har inga kategorier.");
                }

                catalogsViewModel.Add(new CatalogViewModel()
                {
                    CatalogId = catalog.Id,
                    CatalogName = catalog.Name,
                    CreationDate = catalog.CreationDate,
                    CategoryNames = listOfCategoryNames
                });

            });

            return catalogsViewModel;
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
