using Kingpim.DAL.Models;
using Kingpim.Data;
using Kingpim.Services.Dtos;
using Kingpim.Services.Factories;
using Kingpim.Services.Interfaces;
using Kingpim.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kingpim.Services.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _ctx;

        public CategoryRepository(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public List<CategoryViewModel> GetAllCategories()
        {
            List<Category> categories = _ctx.Categories.ToList();
            List<CategoryViewModel> categoriesViewModel = new List<CategoryViewModel>();

            categories.ForEach(category =>
            {
                Catalog catalog = _ctx.Catalogs.FirstOrDefault(f => f.Id == category.CatalogId);
                ApplicationUser user = _ctx.Users.FirstOrDefault(f => f.Id == category.UserId);

                categoriesViewModel.Add(CategoriesFactory.CategoryToViewModel(category, catalog.Name, user.UserName));
            });

            return categoriesViewModel;
        }

        public HttpStatusCode CreateCategory(CreateCategoryDto createCategoryDto, string userId)
        {
            Category category = CategoriesFactory.CategoryToDbo(createCategoryDto);

            Catalog catalog = _ctx.Catalogs.FirstOrDefault(f => f.Id == createCategoryDto.CatalogId);
            category.Catalog = catalog;
            category.CatalogId = catalog.Id;

            ApplicationUser user = _ctx.Users.FirstOrDefault(f => f.Id == userId);
            category.User = user;
            category.UserId = user.Id;

            try
            {
                _ctx.Categories.Add(category);
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public HttpStatusCode UpdateCategory(int categoryId, UpdateCategoryDto updateCategoryDto)
        {
            if (categoryId <= 0)
            {
                return HttpStatusCode.NotFound;
            }

            Catalog catalog = _ctx.Catalogs.FirstOrDefault(f => f.Id == updateCategoryDto.CatalogId);

            Category category = _ctx.Categories.FirstOrDefault(f => f.Id == categoryId);
            category.Name = updateCategoryDto.CategoryName;
            category.IsPublished = updateCategoryDto.IsPublished;
            category.LastModifiedDate = DateTime.Now;
            category.CatalogId = catalog.Id;
            category.Catalog = catalog;

            try
            {
                _ctx.Entry(category).State = EntityState.Modified;
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public HttpStatusCode DeleteCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                return HttpStatusCode.NotFound;
            }

            Category category = _ctx.Categories.FirstOrDefault(f => f.Id == categoryId);

            try
            {
                _ctx.Categories.Remove(category);
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public CategoryViewModel GetCategoryById(int categoryId)
        {
            Category category = _ctx.Categories.FirstOrDefault(f => f.Id == categoryId);
            Catalog catalog = _ctx.Catalogs.FirstOrDefault(f => f.Id == category.CatalogId);
            ApplicationUser user = _ctx.Users.FirstOrDefault(f => f.Id == category.UserId);

            return CategoriesFactory.CategoryToViewModel(category, catalog.Name, user.UserName);
        }
    }
}
