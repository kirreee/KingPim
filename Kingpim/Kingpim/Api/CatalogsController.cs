using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kingpim.Services.Dtos;
using Kingpim.Services.Interfaces;
using Kingpim.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kingpim.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        private readonly ICatalogRepository _catalogRepository;
        public CatalogsController(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        [HttpGet, Route("GetAllCatalogs")]
        public ActionResult<List<CatalogViewModel>> GetAllCatalogs()
        {
            return _catalogRepository.GetAllCatalogs();
        }

        [HttpPost, Route("CreateCatalog")]
        public HttpStatusCode CreateCatalog(CreateCatalogDto catalog)
        {
            var response = _catalogRepository.CreateCatalog(catalog);
            if(response == HttpStatusCode.OK)
            {
                return HttpStatusCode.OK;
            }
            
            if(response == HttpStatusCode.InternalServerError)
            {
                return HttpStatusCode.InternalServerError;
            }

            return HttpStatusCode.NotFound;
        }

        [HttpDelete, Route("DeleteCatalog/{catalogId}")]
        public HttpStatusCode DeleteCatalog(int catalogId)
        {
            var response = _catalogRepository.DeleteCatalog(catalogId);
            if(response == HttpStatusCode.OK)
            {
                return HttpStatusCode.OK;
            }

            if (response == HttpStatusCode.InternalServerError)
            {
                return HttpStatusCode.InternalServerError;
            }

            return HttpStatusCode.NotFound;
        }
    }
}