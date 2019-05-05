using Kingpim.DAL.Models;
using Kingpim.Services.Dtos;
using Kingpim.Services.Helpers;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kingpim.Services.Factories
{
    public static class AttributeFactory
    {
        public static AttributeViewModel AttributeToViewModel(DAL.Models.Attribute attribute, string attributeGroupName)
        {

            string valueType = EnumHelper.EnumValueTypeToString(attribute.Value);
            var attributeViewModel = new AttributeViewModel()
            {
                AttributeId = attribute.Id,
                AttributeName = attribute.Name,
                CreationDate = attribute.CreationDate,
                LastModifiedDate = attribute.LastModifiedDate,
                ValueType = valueType,
                AttributeGroupName = attributeGroupName
            };

            return attributeViewModel;
        }

        public static DAL.Models.Attribute AttributeToDbo(CreateAttributeDto createAttributeDto, AttributeGroup attributeGroup)
        {
            var model = new DAL.Models.Attribute()
            {
                Name = createAttributeDto.AttributeName,
                Value = EnumHelper.GetValueType(createAttributeDto.ValueTypeId),
                AttributeGroupId = createAttributeDto.AttributeGroupId,
                AttributeGroup = attributeGroup,
                CreationDate = DateTime.Now
            };

            return model;
        }
    }
}
