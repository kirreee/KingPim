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
        private readonly SubcategoryFactory _subcategoryFactory;
        IAttributeGroupRepository _attributeGroupRepository;

        public SubcategoryRepository(ApplicationDbContext context, SubcategoryFactory subcategoryFactory,
           IAttributeGroupRepository attributeGroupRepository)
        {
            _ctx = context;
            _subcategoryFactory = subcategoryFactory;
            _attributeGroupRepository = attributeGroupRepository;
        }

        public List<SubcategoryViewModel> GetAllSubcategories()
        {

            List<Subcategory> subcategories = _ctx.Subcategories
                .Include(x => x.SubcategoryAttributes).ToList();

            List<SubcategoryViewModel> subcategoryViewModels = new List<SubcategoryViewModel>();

            subcategories.ForEach(subcategory =>
            {
                subcategoryViewModels.Add(_subcategoryFactory.SubcategoryToViewModel(subcategory));
            });

            return subcategoryViewModels;
        }

        public HttpStatusCode CreateSubcategory(CreateSubcategoryDto createSubcategoryDto)
        {
            Category category = _ctx.Categories.FirstOrDefault(f => f.Id == createSubcategoryDto.CategoryId);
            Subcategory subcategory = _subcategoryFactory.SubcategoryToDbo(createSubcategoryDto);

            subcategory.Category = category;
            subcategory.CategoryId = category.Id;

            List<SubcategoryAttribute> subcategoryAttributes = new List<SubcategoryAttribute>();
            var attributeGroupsIds = createSubcategoryDto.SubcategoiresIds.ToList();

            attributeGroupsIds.ForEach(id =>
            {
                subcategoryAttributes.Add(new SubcategoryAttribute()
                {
                    Subcategory = subcategory,
                    AttributeGroupId = id,
                });
            });

            subcategory.SubcategoryAttributes = subcategoryAttributes;

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

            Subcategory subcategory = _ctx.Subcategories.Include(x => x.SubcategoryAttributes).FirstOrDefault(f => f.Id == subcategoryId);
            SubcategoryViewModel subcategoryViewModel = _subcategoryFactory.SubcategoryToViewModel(subcategory);

            Category category = _ctx.Categories.FirstOrDefault(f => f.Id == subcategory.CategoryId);
            subcategoryViewModel.CategoryName = category.Name;

            return subcategoryViewModel;
        }

        public HttpStatusCode UpdateSubcategory(int subcategoryId, UpdateSubcategoryDto updateSubcategoryDto)
        {
            Subcategory subcategory = _ctx.Subcategories.Include(x => x.Category).Include(x => x.SubcategoryAttributes)
                .FirstOrDefault(f => f.Id == subcategoryId);

            if (subcategory == null)
            {
                return HttpStatusCode.NotFound;
            }

            subcategory.IsPublished = updateSubcategoryDto.IsPublished;
            subcategory.Name = updateSubcategoryDto.SubcategoryName;
            subcategory.LastModifiedDate = DateTime.Now;

            Category category = _ctx.Categories.FirstOrDefault(f => f.Id == updateSubcategoryDto.CategoryId);
            if (category != null)
            {
                subcategory.Category = subcategory.Category;
                subcategory.CategoryId = subcategory.CategoryId;
            }

            updateSubcategoryDto.SelectedAttributeGroupsIdsToDelete.ForEach(attributeGroupId =>
            {
                SubcategoryAttribute subcategoryAttribute = _ctx.SubcategoryAttributes.Include(x => x.AttributeGroup)
                .FirstOrDefault(f => f.AttributeGroupId == attributeGroupId);

                subcategory.SubcategoryAttributes.Remove(subcategoryAttribute);

            });

            if (updateSubcategoryDto.SelectedAttributeGroupsIdsToCreate != null)
            {
                updateSubcategoryDto.SelectedAttributeGroupsIdsToCreate.ForEach(attributeGroupId =>
                {
                    subcategory.SubcategoryAttributes.Add(new SubcategoryAttribute()
                    {
                        Subcategory = subcategory,
                        AttributeGroupId = attributeGroupId,
                    });
                });
            }

            subcategory.SubcategoryAttributes = subcategory.SubcategoryAttributes;

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
