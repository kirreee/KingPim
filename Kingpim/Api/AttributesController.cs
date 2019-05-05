using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kingpim.Services.Dtos;
using Kingpim.Services.Helpers;
using Kingpim.Services.Repositories;
using Kingpim.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kingpim.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributesController : ControllerBase
    {
        private readonly IAttributeRepository _attributeRepository;

        public AttributesController(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }

        [HttpGet, Route("GetAllAttributes")]
        public ActionResult<List<AttributeViewModel>> GetAllAttributes()
        {
            return _attributeRepository.GetAllAttributes();
        }

        [HttpGet, Route("GetAttributeById/{attributeId}")]
        public ActionResult<AttributeViewModel> GetAttributeById(int attributeId)
        {
            return _attributeRepository.GetAttributeById(attributeId);
        }

        [HttpPost, Route("CreateAttribute")]
        public HttpStatusCode CreateAttribute(CreateAttributeDto createAttributeDto)
        {
            var response = _attributeRepository.CreateAttribute(createAttributeDto);

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

        [HttpPost, Route("UpdateAttribute/{attributeId}")]
        public HttpStatusCode UpdateAttributeById(int attributeId, UpdateAttributeDto updateAttributeDto)
        {
            var response = _attributeRepository.UpdateAttribute(attributeId, updateAttributeDto);
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

        [HttpDelete, Route("DeleteAttribute/{attributeId}")]
        public HttpStatusCode DeleteAttribute(int attributeId)
        {
            var response = _attributeRepository.DeleteAttribute(attributeId);
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

        [HttpGet, Route("GetValueTypes")]
        public ActionResult<List<ValueTypeViewModel>> GetValueTypes()
        {
            List<ValueTypeViewModel> valueViewModels = EnumHelper.GetListOfValueTypes();
            return valueViewModels;
        }
    }
}