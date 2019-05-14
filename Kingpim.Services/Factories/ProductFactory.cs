using Kingpim.DAL.Models;
using Kingpim.Data;
using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kingpim.Services.Factories
{
    public class ProductFactory
    {
        private readonly ApplicationDbContext _ctx;

        public ProductFactory(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public ProductViewModel ProductToViewModel(Product product)
        {
            SystemAttribute systemAttribute = _ctx.SystemAttributes.FirstOrDefault(f => f.Id == product.SystemAttributeId);

            var viewModel = new ProductViewModel()
            {
                ProductId = product.Id,
                CreationDate = product.CreationDate,
                IsPublished = product.IsPublished,
                LastModified = product.LastModifiedDate,
                LastModifiedBy = systemAttribute.LastModifiedBy,
                ProductName = product.Name,
                VersioNumber = systemAttribute.VersioNumber,
                Version = systemAttribute.Version,
            };

            return viewModel;
        }

        public Product ProductToDbo(CreateProductDto createProductDto)
        {
            Subcategory subcategory = _ctx.Subcategories.FirstOrDefault(x => x.Id == createProductDto.SubcategoryId);

            var model = new Product()
            {
                Name = createProductDto.ProductName,
                IsPublished = createProductDto.IsProductPublished,
                Subcategory = subcategory,
                SubcategoryId = subcategory.Id
            };

            return model;
        }
    }
}
