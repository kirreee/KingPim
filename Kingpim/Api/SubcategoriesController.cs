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
    public class SubcategoriesController : ControllerBase
    {
        private readonly ISubcategoryRepository _subcategoryRepository;
        public SubcategoriesController(ISubcategoryRepository subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        [HttpGet, Route("GetAllSubcategories")]
        public ActionResult<List<SubcategoryViewModel>> GetAllSubcategories()
        {
            return _subcategoryRepository.GetAllSubcategories();
        }

        [HttpGet, Route("GetSubcategoryById/{subcategoryId}")]
        public ActionResult<SubcategoryViewModel> GetSubcategoryById(int subcategoryId)
        {
            if(subcategoryId <= 0)
            {
                return NotFound();
            }

            return _subcategoryRepository.GetSubcategoryById(subcategoryId);
        }

        [HttpPost, Route("CreateSubcategory")]
        public HttpStatusCode CreateSubcategory(CreateSubcategoryDto createSubcategoryDto)
        {
            var response = _subcategoryRepository.CreateSubcategory(createSubcategoryDto);
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

        [HttpPost, Route("UpdateSubcategory/{subcategoryId}")]
        public HttpStatusCode UpdateSubcategory(int subcategoryId, UpdateSubcategoryDto updateSubcategoryDto)
        {
            var response = _subcategoryRepository.UpdateSubcategory(subcategoryId, updateSubcategoryDto);
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

        [HttpDelete, Route("DeleteSubcategory/{subcategoryId}")]
        public HttpStatusCode DeleteSubcategoty(int subcategoryId)
        {
            var response = _subcategoryRepository.DeleteSubcategory(subcategoryId);
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