using Kingpim.DAL.Models;
using Kingpim.Data;
using Kingpim.Services.Dtos;
using Kingpim.Services.Factories;
using Kingpim.Services.Interfaces;
using Kingpim.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kingpim.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _ctx;
        private readonly ProductFactory _productFactory;

        public ProductRepository(ApplicationDbContext context, ProductFactory productFactory)
        {
            _ctx = context;
            _productFactory = productFactory;
        }

        public List<ProductViewModel> GetAllProducts()
        {
            List<Product> products = _ctx.Products.ToList();

            List<ProductViewModel> productViewModels = new List<ProductViewModel>();

            products.ForEach(product =>
            {
                productViewModels.Add(
                     _productFactory.ProductToViewModel(product)
                );

            });

            return productViewModels;
        }

        public HttpStatusCode CreatProduct(CreateProductDto createProductDto)
        {
            Subcategory subcategory = _ctx.Subcategories.FirstOrDefault(x => x.Id == createProductDto.SubcategoryId);

            if (subcategory == null)
            {
                return HttpStatusCode.NotFound;
            }

            var systemAttributeModel = new SystemAttribute()
            {
                CreationDate = DateTime.Now,
                IsPublished = createProductDto.IsProductPublished,
                VersioNumber = Guid.NewGuid().ToString(),
                Version = 1,
            };

            try
            {
                _ctx.SystemAttributes.Add(systemAttributeModel);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            var model = new Product()
            {
                Name = createProductDto.ProductName,
                IsPublished = createProductDto.IsProductPublished,
                Subcategory = subcategory,
                SubcategoryId = subcategory.Id,
                SystemAttribute = systemAttributeModel,
                SystemAttributeId = systemAttributeModel.Id,
                CreationDate = DateTime.Now
            };


            try
            {
                _ctx.Products.Add(model);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }

            return HttpStatusCode.OK;
        }

        public HttpStatusCode DeleteProduct(int productId)
        {
            Product product = _ctx.Products.FirstOrDefault(f => f.Id == productId);

            try
            {
                _ctx.Products.Remove(product);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }

            return HttpStatusCode.OK;
        }

        public HttpStatusCode UpdateProduct(int productId, UpdateProductDto updateProductDto, string userId)
        {
            Product product = _ctx.Products.FirstOrDefault(f => f.Id == productId);
            product.Name = updateProductDto.ProductName;
            product.IsPublished = updateProductDto.IsProductPublished;
            product.LastModifiedDate = DateTime.Now;

            Subcategory subcategory = _ctx.Subcategories.FirstOrDefault(f => f.Id == updateProductDto.SubcategoryId);
            product.Subcategory = subcategory;
            product.SubcategoryId = subcategory.Id;

            try
            {
                _ctx.Entry(product).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }

            ApplicationUser user = _ctx.Users.FirstOrDefault(f => f.Id == userId);

            SystemAttribute systemAttribute = _ctx.SystemAttributes.FirstOrDefault(f => f.Id == product.SystemAttributeId);
            systemAttribute.IsPublished = updateProductDto.IsProductPublished;
            systemAttribute.LastModifiedBy = user.UserName;
            systemAttribute.LastModified = DateTime.Now;
            systemAttribute.VersioNumber = systemAttribute.VersioNumber;
            systemAttribute.Version++;

            try
            {
                _ctx.Entry(systemAttribute).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }

            return HttpStatusCode.OK;
        }

        public HttpStatusCode FileUpload(IFormFile file, int productId)
        {
            Product product = _ctx.Products.FirstOrDefault(f => f.Id == productId);

            var model = new File()
            {
                CreationDate = DateTime.Now,
                FileName = file.FileName,
                IsMainFile = false,
                IsPublished = false,
                Product = product,
                ProductId = product.Id,
                FileType = file.ContentType

            };

            try
            {
                _ctx.Files.Add(model);
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public ProductViewModel GetProductById(int productId)
        {

            Product product = _ctx.Products.FirstOrDefault(f => f.Id == productId);

            ProductViewModel productViewModel = _productFactory.ProductToViewModel(product);

            return productViewModel;
        }
    }
}
