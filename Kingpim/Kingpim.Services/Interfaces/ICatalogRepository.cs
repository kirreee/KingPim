using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Kingpim.Services.Interfaces
{
    public interface ICatalogRepository
    {
        List<CatalogViewModel> GetAllCatalogs();
        HttpStatusCode CreateCatalog(CreateCatalogDto catalog, string userId);
        CatalogViewModel GetCatalogById(int catalogId);
        HttpStatusCode UpdateCatalog(int catalogId, UpdateCatalogDto updateCatalogDto);
        HttpStatusCode DeleteCatalog(int catalogId);
    }
}
