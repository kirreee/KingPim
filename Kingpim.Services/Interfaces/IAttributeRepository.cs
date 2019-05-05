using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Kingpim.Services.Repositories
{
    public interface IAttributeRepository
    {
        List<AttributeViewModel> GetAllAttributes();
        AttributeViewModel GetAttributeById(int attributeId);
        HttpStatusCode CreateAttribute(CreateAttributeDto createAttributeDto);
        HttpStatusCode UpdateAttribute(int attributeId, UpdateAttributeDto updateAttributeDto);
        HttpStatusCode DeleteAttribute(int attributeId);
    }
}
