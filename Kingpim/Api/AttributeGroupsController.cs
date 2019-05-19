using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kingpim.Services.Dtos;
using Kingpim.Services.Interfaces;
using Kingpim.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kingpim.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeGroupsController : ControllerBase
    {
        private readonly IAttributeGroupRepository _attributeGroupRepository;
        public AttributeGroupsController(IAttributeGroupRepository attributeGroupRepository)
        {
            _attributeGroupRepository = attributeGroupRepository;
        }

        [HttpGet, Route("GetAllAttributeGroups")]
        public ActionResult<List<AttributeGroupViewModel>> GetAllAttributeGroups()
        {
            return _attributeGroupRepository.GetAllAttributeGroups();
        }

        [HttpPost, Route("CreateAttributeGroup")]
        public HttpStatusCode CreateAttributeGroup(CreateAttributeGroupDto createAttributeGroupDto)
        {
            var response = _attributeGroupRepository.CreateAttributeGroup(createAttributeGroupDto);
            switch (response)
            {
                case HttpStatusCode.OK:
                    return HttpStatusCode.OK;
                case HttpStatusCode.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                default:
                    return HttpStatusCode.NotFound;
            }
        }

        [HttpGet, Route("GetAttributeGroupById/{attributeGroupId}")]
        public ActionResult<AttributeGroupViewModel> GetAttributeGroupById(int attributeGroupId)
        {
            if(attributeGroupId <= 0)
            {
                return NotFound();
            }

            return _attributeGroupRepository.GetAttributeGroupById(attributeGroupId);
        }

        [HttpPost, Route("UpdateAttributeGroup/{attributeGroupId}")]
        public HttpStatusCode UpdateAttributeGroup(int attributeGroupId, UpdateAttributeGroupDto updateAttributeGroupDto)
        {
            var response = _attributeGroupRepository.UpdateAttributeGroup(attributeGroupId, updateAttributeGroupDto);
            switch (response)
            {
                case HttpStatusCode.OK:
                    return HttpStatusCode.OK;
                case HttpStatusCode.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                default:
                    return HttpStatusCode.NotFound;
            }
        }

        [HttpDelete, Route("DeleteAttributeGroup/{attributeGroupId}")]
        public HttpStatusCode DeleteAttributeGroup(int attributeGroupId)
        {
            var response = _attributeGroupRepository.DeleteAttributeGroup(attributeGroupId);
            switch (response)
            {
                case HttpStatusCode.OK:
                    return HttpStatusCode.OK;
                case HttpStatusCode.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                default:
                    return HttpStatusCode.NotFound;
            }
        }
    }
}