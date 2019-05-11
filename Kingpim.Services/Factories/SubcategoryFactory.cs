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
    public class SubcategoryFactory
    {

        private readonly ApplicationDbContext _ctx;

        public SubcategoryFactory(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public SubcategoryViewModel SubcategoryToViewModel(Subcategory subcategory)
        {
            List<AttributeGroupViewModel> attributeGroups = new List<AttributeGroupViewModel>();

            subcategory.SubcategoryAttributes.ForEach(subAttribute =>
            {
                AttributeGroup attributeGroup = _ctx.AttributeGroups.FirstOrDefault(f => f.Id == subAttribute.AttributeGroupId);
                attributeGroups.Add(AttributeGroupFactory.AttributeGroupToViewModel(attributeGroup));
            });

            var subcategoryViewModel = new SubcategoryViewModel()
            {
                SubcategoryId = subcategory.Id,
                SubcategoryName = subcategory.Name,
                IsPublished = subcategory.IsPublished,
                CreationDate = subcategory.CreationDate,
                LastModifiedDate = subcategory.LastModifiedDate,
                AttributeGroups = attributeGroups
            };

            return subcategoryViewModel;
        }

        public Subcategory SubcategoryToDbo(CreateSubcategoryDto createSubcategoryDto)
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
