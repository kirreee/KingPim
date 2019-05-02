using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
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
            string userId =  User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(userId))
            {
                return HttpStatusCode.Unauthorized;
            }

            var response = _catalogRepository.CreateCatalog(catalog, userId);
            switch (response)
            {
                case HttpStatusCode.OK:
                    return HttpStatusCode.OK;
                case HttpStatusCode.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                default:
                    return HttpStatusCode.NotFound;
            }
        }

        [HttpGet, Route("GetCatalogById/{catalogId}")]
        public ActionResult<CatalogViewModel> GetCatalogById(int catalogId)
        {
            return _catalogRepository.GetCatalogById(catalogId);
        }

        [HttpPost, Route("UpdateCatalog/{catalogId}")]
        public HttpStatusCode UpdateCatalog(int catalogId, UpdateCatalogDto updateCatalogDto)
        {
            var response = _catalogRepository.UpdateCatalog(catalogId, updateCatalogDto);

            switch (response)
            {
                case HttpStatusCode.OK:
                    return HttpStatusCode.OK;
                case HttpStatusCode.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                default:
                    return HttpStatusCode.NotFound;
            }
        }

        [HttpDelete, Route("DeleteCatalog/{catalogId}")]
        public HttpStatusCode DeleteCatalog(int catalogId)
        {
            var response = _catalogRepository.DeleteCatalog(catalogId);

            switch (response)
            {
                case HttpStatusCode.OK:
                    return HttpStatusCode.OK;
                case HttpStatusCode.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                default:
                    return HttpStatusCode.NotFound;
            }
        }
    }
}