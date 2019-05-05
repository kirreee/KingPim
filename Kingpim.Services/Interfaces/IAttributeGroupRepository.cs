using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Kingpim.Services.Interfaces
{
    public interface IAttributeGroupRepository
    {
        List<AttributeGroupViewModel> GetAllAttributeGroups();
        AttributeGroupViewModel GetAttributeGroupById(int attributeGroupId);
        HttpStatusCode CreateAttributeGroup(CreateAttributeGroupDto createAttributeGroupDto);
        HttpStatusCode UpdateAttributeGroup(int attributeGroupId, UpdateAttributeGroupDto updateAttributeGroupDto);
        HttpStatusCode DeleteAttributeGroup(int attributeGroupId);
    }
}
