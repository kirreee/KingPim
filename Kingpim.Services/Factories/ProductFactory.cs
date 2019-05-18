using Kingpim.DAL.Models;
using Kingpim.Data;
using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kingpim.Services.Factories
{
    public class ProductFactory
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IConfiguration _configuration;

        public ProductFactory(ApplicationDbContext context, IConfiguration configuration)
        {
            _ctx = context;
            _configuration = configuration;
        }

        public ProductViewModel ProductToViewModel(Product product)
        {

            SystemAttribute systemAttribute = _ctx.SystemAttributes.FirstOrDefault(f => f.Id == product.SystemAttributeId);

            List<File> files = _ctx.Files.Where(w => w.ProductId == product.Id).ToList();

            List<FileViewModel> fileViewModels = new List<FileViewModel>();

            if (files.Count > 0)
            {
                string fileFolderName = _configuration.GetSection("FilesFolderPath")["Folder"];

                files.ForEach(file =>
                {
                    FileViewModel fileViewModel = new FileViewModel();
                    fileViewModel = new FileViewModel()
                    {
                        FileId = file.Id,
                        File = fileFolderName + file.FileName,
                        FileType = file.FileType,
                        IsMainFile = file.IsMainFile,
                        IsPublished = file.IsPublished
                    };

                    fileViewModels.Add(fileViewModel);
                });
            }

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
                Files = fileViewModels
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
