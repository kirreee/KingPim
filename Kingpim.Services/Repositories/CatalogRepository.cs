using Kingpim.DAL.Models;
using Kingpim.Data;
using Kingpim.Services.Dtos;
using Kingpim.Services.Factories;
using Kingpim.Services.Interfaces;
using Kingpim.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kingpim.Services.Repositories
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
            List<Catalog> catalogs = _ctx.Catalogs.ToList();
            List<CatalogViewModel> catalogViewModelsList = new List<CatalogViewModel>();

            catalogs.ForEach(catalog =>
            {
                ApplicationUser user = _ctx.Users.FirstOrDefault(f => f.Id == catalog.UserId);
                catalogViewModelsList.Add(CatalogsFactory.CatalogToViewModel(catalog, user.UserName));
            });

            return catalogViewModelsList;
        }

        public HttpStatusCode CreateCatalog(CreateCatalogDto catalogDto, string userId)
        {
            Catalog catalog = CatalogsFactory.CatalogToDbo(catalogDto);
            ApplicationUser user = _ctx.Users.FirstOrDefault(f => f.Id == userId);

            catalog.User = user;
            catalog.UserId = user.Id;

            try
            {
                _ctx.Catalogs.Add(catalog);
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public CatalogViewModel GetCatalogById(int catalogId)
        {
            Catalog catalog = _ctx.Catalogs.FirstOrDefault(f => f.Id == catalogId);
            ApplicationUser user = _ctx.Users.FirstOrDefault(f => f.Id == catalog.UserId);
            

            CatalogViewModel catalogViewModel = CatalogsFactory.CatalogToViewModel(catalog, user.UserName);

            return catalogViewModel;
        }

        public HttpStatusCode UpdateCatalog(int catalogId, UpdateCatalogDto updateCatalogDto)
        {
            if(catalogId <= 0)
            {
                return HttpStatusCode.NotFound;
            }

            Catalog catalog = _ctx.Catalogs.FirstOrDefault(f => f.Id == catalogId);
            catalog.Name = updateCatalogDto.Name;
            catalog.LastModifiedDate = DateTime.Now;

            try
            {
                _ctx.Entry(catalog).State = EntityState.Modified;
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public HttpStatusCode DeleteCatalog(int catalogId)
        {
            if (catalogId <= 0)
            {
                return HttpStatusCode.NotFound;
            }

            Catalog catalog = _ctx.Catalogs.FirstOrDefault(f => f.Id == catalogId);

            try
            {
                _ctx.Catalogs.Remove(catalog);
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
