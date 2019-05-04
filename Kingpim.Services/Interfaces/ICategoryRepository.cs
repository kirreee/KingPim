using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Kingpim.Services.Interfaces
{
    public interface ICategoryRepository
    {
        List<CategoryViewModel> GetAllCategories();
        HttpStatusCode CreateCategory(CreateCategoryDto createCategoryDto, string userId);
        HttpStatusCode UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto);
        CategoryViewModel GetCategoryById(int categoryId);
        HttpStatusCode DeleteCategory(int categoryId);
    }
}
