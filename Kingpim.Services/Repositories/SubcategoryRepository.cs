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
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly ApplicationDbContext _ctx;
        public SubcategoryRepository(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public List<SubcategoryViewModel> GetAllSubcategories()
        {
            List<Subcategory> subcategories = _ctx.Subcategories.ToList();
            List<SubcategoryViewModel> subcategoryViewModel = new List<SubcategoryViewModel>();

            subcategories.ForEach(subcategory =>
            {
                Category category = _ctx.Categories.FirstOrDefault(f => f.Id == subcategory.CategoryId);
                subcategoryViewModel.Add(SubcategoryFactory.SubcategoryToViewModel(subcategory, category.Name));
            });

            return subcategoryViewModel;
        }

        public HttpStatusCode CreateSubcategory(CreateSubcategoryDto createSubcategoryDto)
        {
            Category category = _ctx.Categories.FirstOrDefault(f => f.Id == createSubcategoryDto.CategoryId);
            Subcategory subcategory = SubcategoryFactory.SubcategoryToDbo(createSubcategoryDto);

            subcategory.Category = category;
            subcategory.CategoryId = category.Id;

            try
            {
                _ctx.Subcategories.Add(subcategory);
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public HttpStatusCode DeleteSubcategory(int subcategoryId)
        {
            Subcategory subcategory = _ctx.Subcategories.FirstOrDefault(f => f.Id == subcategoryId);

            if (subcategory == null)
            {
                return HttpStatusCode.NotFound;
            }

            try
            {
                _ctx.Subcategories.Remove(subcategory);
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public SubcategoryViewModel GetSubcategoryById(int subcategoryId)
        {
            Subcategory subcategory = _ctx.Subcategories.FirstOrDefault(f => f.Id == subcategoryId);
            Category category = _ctx.Categories.FirstOrDefault(f => f.Id == subcategory.CategoryId);

            return SubcategoryFactory.SubcategoryToViewModel(subcategory, category.Name);
        }

        public HttpStatusCode UpdateSubcategory(int subcategoryId, UpdateSubcategoryDto updateSubcategoryDto)
        {
            Subcategory subcategory = _ctx.Subcategories.FirstOrDefault(f => f.Id == subcategoryId);
            if(subcategory == null)
            {
                return HttpStatusCode.NotFound;
            }

            subcategory.IsPublished = updateSubcategoryDto.IsPublished;
            subcategory.Name = updateSubcategoryDto.SubcategoryName;

            Category category = _ctx.Categories.FirstOrDefault(f => f.Id == updateSubcategoryDto.CategoryId);
            if(category != null)
            {
                subcategory.Category = category;
                subcategory.CategoryId = category.Id;
            }

            try
            {
                _ctx.Entry(subcategory).State = EntityState.Modified;
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
