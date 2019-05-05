using Kingpim.DAL.Models;
using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.Factories
{
    public static class SubcategoryFactory
    {
        public static SubcategoryViewModel SubcategoryToViewModel(Subcategory subcategory, string categoryName)
        {
            var subcategoryViewModel = new SubcategoryViewModel()
            {
                SubcategoryId = subcategory.Id,
                SubcategoryName = subcategory.Name,
                IsPublished = subcategory.IsPublished,
                CategoryName = categoryName,
                CreationDate = subcategory.CreationDate,
                LastModifiedDate = subcategory.LastModifiedDate
                
            };

            return subcategoryViewModel;
        }

        public static Subcategory SubcategoryToDbo(CreateSubcategoryDto createSubcategoryDto)
        {
            var model = new Subcategory()
            {
                Name = createSubcategoryDto.SubcategoryName,
                IsPublished = createSubcategoryDto.IsPublished,
                CreationDate = DateTime.Now
            };

            return model;
        }
    }
}
