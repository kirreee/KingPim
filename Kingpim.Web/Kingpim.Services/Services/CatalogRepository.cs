using Kingpim.DAL.Models;
using Kingpim.Data;
using Kingpim.Services.Dtos;
using Kingpim.Services.Interfaces;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kingpim.Services.Services
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ApplicationDbContext _ctx;
        public CatalogRepository(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public List<CatalogViewModel> GetAllCatalogs()
        {
            var catalogsViewModel = new List<CatalogViewModel>();
            var catalogs = _ctx.Catalogs.ToList();
            catalogs.ForEach(catalog =>
            {
                List<Category> categories = catalog.Categories.ToList();
                categories.ForEach(category =>
                {
                    catalogsViewModel.Add(new CatalogViewModel()
                    {
                        CatalogName = catalog.Name,
                        CategoryNames = category.Name
                    });
                });
            });

            return catalogsViewModel;
        }

        public HttpStatusCode CreateCatalog(CreateCatalogDto catalog)
        {
            var model = new Catalog();
            {
                model.Name = catalog.Name;
            }

            try
            {
                _ctx.Catalogs.Add(model);
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
