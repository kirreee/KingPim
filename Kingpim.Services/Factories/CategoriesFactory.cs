using Kingpim.DAL.Models;
using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.Factories
{
    public static class CategoriesFactory
    {
        public static CategoryViewModel CategoryToViewModel(Category category, string catalogName, string userName)
        {
            var categoriesViewModel = new CategoryViewModel()
            {
                CategoryId =  category.Id,
                CategoryName = category.Name,
                IsPublished = category.IsPublished,
                CreatedBy = userName,
                CatalogName = catalogName
            };

            return categoriesViewModel;
        }

        public static Category CategoryToDbo(CreateCategoryDto createCategoryDto)
        {
            var model = new Category()
            {
                Name = createCategoryDto.CategoryName,
                IsPublished = createCategoryDto.IsPublished,
                
            };

            return model;
        }
    }
}
