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
    public class CategoriesController : ControllerBase
    {
       private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        }
         
        [HttpGet, Route("GetAllCategories")]
        public ActionResult<List<CatalogViewModel>> GetAllCategories()
        {
            return Ok(_categoryRepository.GetAllCategories());
        }

        [HttpPost, Route("CreateCategory")]
        public HttpStatusCode CreateCategory(CreateCategoryDto createCategoryDto)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(userId))
            {
                return HttpStatusCode.Unauthorized;
            }

            var response = _categoryRepository.CreateCategory(createCategoryDto, userId);
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

        [HttpGet, Route("GetCategoryById/{categoryId}")]
        public ActionResult<CatalogViewModel> GetCategoryById(int categoryId)
        {
           return Ok(_categoryRepository.GetCategoryById(categoryId));
        }

        [HttpPost, Route("UpdateCategory/{categoryId}")]
        public HttpStatusCode UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto)
        {
            var response = _categoryRepository.UpdateCategory(categoryId,updateCategoryDto);
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

        [HttpDelete, Route("DeleteCategory/{categoryId}")]
        public HttpStatusCode DeleteCategory(int categoryId)
        {
            var response = _categoryRepository.DeleteCategory(categoryId);
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