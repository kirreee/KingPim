using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Kingpim.Data;
using Kingpim.Services.Dtos;
using Kingpim.Services.Interfaces;
using Kingpim.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kingpim.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository produtRepository)
        {
            _productRepository = produtRepository;
        }

        [HttpGet, Route("GetAllProducts")]
        public List<ProductViewModel> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        [HttpPost, Route("CreateProduct")]
        public HttpStatusCode CreatProduct(CreateProductDto createProductDto)
        {

            var response = _productRepository.CreatProduct(createProductDto);

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

        [HttpPost, Route("UpdateProduct/{productId}")]
        public HttpStatusCode UpdateProduct(int productId, UpdateProductDto updateProductDto)
        {

            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(userId))
            {
                return HttpStatusCode.Unauthorized;
            }

            var response = _productRepository.UpdateProduct(productId, updateProductDto, userId);

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

        [HttpGet, Route("GetProductById/{productId}")]
        public ProductViewModel GetProductById(int productId)
        {
            if(productId <= 0)
            {
                return null; //Todo: Do not return null.
            }

            ProductViewModel productViewModel = _productRepository.GetProductById(productId);

            return productViewModel;
        }

        [HttpDelete, Route("DeleteProduct/{productId}")]
        public HttpStatusCode DeleteProduct(int productId)
        {

            if (productId <= 0)
            {
                return HttpStatusCode.NotFound;
            }

            var response = _productRepository.DeleteProduct(productId);

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