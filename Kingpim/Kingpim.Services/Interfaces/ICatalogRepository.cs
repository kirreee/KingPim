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
        HttpStatusCode CreateCatalog(CreateCatalogDto catalog);
        HttpStatusCode DeleteCatalog(int catalogId);
    }
}
