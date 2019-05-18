using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Kingpim.DAL.Models;
using Kingpim.Data;
using Kingpim.Services.Dtos;
using Kingpim.Services.Helpers;
using Kingpim.Services.Interfaces;
using Kingpim.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kingpim.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly FileUploadHelper _fileUploadHelper;
        private readonly ApplicationDbContext _ctx;

        public ProductsController(
            IProductRepository produtRepository,
            FileUploadHelper fileUploadHelper,
            ApplicationDbContext context)
        {
            _productRepository = produtRepository;
            _fileUploadHelper = fileUploadHelper;
            _ctx = context;
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
            if (productId <= 0)
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

        [HttpPost, Route("FileUpload/{productId}")]
        public HttpStatusCode FileUpload(IFormFile file, int productId)
        {
            if (productId <= 0)
            {
                return HttpStatusCode.NotFound;
            }

            //Save file in folder.
            _fileUploadHelper.SaveFileInFolder(file);

            var response = _productRepository.FileUpload(file, productId);
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

        [HttpPost, Route("SetMainImage/{fileId}")]
        public HttpStatusCode SetMainImage(int fileId)
        {

            List<File> files = _ctx.Files.ToList();
            files.ForEach(x =>
            {
                x.IsMainFile = false;
                _ctx.Entry(x).State = EntityState.Modified;
            });

            File file = _ctx.Files.FirstOrDefault(f => f.Id == fileId);

            file.IsMainFile = true;

            try
            {
                _ctx.Entry(file).State = EntityState.Modified;
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        [HttpPost, Route("SetMediaType/{mediaTypeId}/{fileId}")]
        public HttpStatusCode SetMediaType(int mediaTypeId, int fileId)
        {

            if (mediaTypeId <= 0)
            {
                return HttpStatusCode.NotFound;
            }

            if (fileId <= 0)
            {
                return HttpStatusCode.NotFound;
            }

            File file = _ctx.Files.FirstOrDefault(f => f.Id == fileId);
            file.MediaType = EnumHelper.GetMediaType(mediaTypeId);

            try
            {
                _ctx.Entry(file).State = EntityState.Modified;
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        [HttpGet, Route("GetMediumTypes")]
        public List<MediaTypeViewModel> GetMediaTypes()
        {
            return EnumHelper.GetListOfMediatypes();
        }
    }
}