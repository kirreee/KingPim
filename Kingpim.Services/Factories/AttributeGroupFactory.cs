using Kingpim.DAL.Models;
using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.Factories
{
    public static class AttributeGroupFactory
    {
        public static AttributeGroupViewModel AttributeGroupToViewModel(AttributeGroup attributeGroup)
        {
            var attributeGroupViewModel = new AttributeGroupViewModel()
            {
                AttributeGroupId = attributeGroup.Id,
                AttributeGroupName = attributeGroup.Name,
                CreationDate = attributeGroup.CreationDate,
                LastModifiedDate = attributeGroup.LastModifiedDate
            };

            return attributeGroupViewModel;
        }

        public static AttributeGroup AttributeGroupToDbo(CreateAttributeGroupDto createAttributeGroupDto)
        {
            var model = new AttributeGroup()
            {
                Name = createAttributeGroupDto.AttributeGroupName,
                CreationDate = DateTime.Now
            };

            return model;
        }
    }
}
