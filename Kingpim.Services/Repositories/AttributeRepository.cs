using Kingpim.DAL.Models;
using Kingpim.Data;
using Kingpim.Services.Dtos;
using Kingpim.Services.Factories;
using Kingpim.Services.Helpers;
using Kingpim.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Kingpim.Services.Repositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly ApplicationDbContext _ctx;

        public AttributeRepository(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public List<AttributeViewModel> GetAllAttributes()
        {
            List<DAL.Models.Attribute> attributes = _ctx.Attributes.ToList();
            List<AttributeViewModel> attributeViewModels = new List<AttributeViewModel>();

            attributes.ForEach(attribute =>
            {
                AttributeGroup attributeGroup = _ctx.AttributeGroups.FirstOrDefault(f => f.Id == attribute.AttributeGroupId);

                attributeViewModels.Add(AttributeFactory.AttributeToViewModel(attribute, attributeGroup.Name));
            });

            return attributeViewModels;
        }

        public AttributeViewModel GetAttributeById(int attributeId)
        {
            DAL.Models.Attribute attribute = _ctx.Attributes.FirstOrDefault(f => f.Id == attributeId);
            AttributeGroup attributeGroup = _ctx.AttributeGroups.FirstOrDefault(f => f.Id == attribute.AttributeGroupId);

            AttributeViewModel attributeViewModel = AttributeFactory.AttributeToViewModel(attribute, attributeGroup.Name);

            return attributeViewModel;
        }

        public HttpStatusCode CreateAttribute(CreateAttributeDto createAttributeDto)
        {
            AttributeGroup attributeGroup = _ctx.AttributeGroups
                .FirstOrDefault(f => f.Id == createAttributeDto.AttributeGroupId);

            var model =  AttributeFactory.AttributeToDbo(createAttributeDto, attributeGroup);

            try
            {
                _ctx.Attributes.Add(model);
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public HttpStatusCode UpdateAttribute(int attributeId, UpdateAttributeDto updateAttributeDto)
        {
            if(updateAttributeDto.AttributeGroupId <= 0)
            {
                return HttpStatusCode.NotFound;
            }

            DAL.Models.Attribute attribute = _ctx.Attributes.FirstOrDefault(f => f.Id == attributeId);
            attribute.Name = updateAttributeDto.AttributeName;
            attribute.Value = EnumHelper.GetValueType(updateAttributeDto.ValueTypeId);
            attribute.LastModifiedDate = DateTime.Now;

            AttributeGroup attributeGroup = _ctx.AttributeGroups.FirstOrDefault(f => f.Id == updateAttributeDto.AttributeGroupId);
            attribute.AttributeGroup = attributeGroup;
            attribute.AttributeGroupId = attributeGroup.Id;

            try
            {
                _ctx.Entry(attribute).State = EntityState.Modified;
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public HttpStatusCode DeleteAttribute(int attributeId)
        {
            DAL.Models.Attribute attribute = _ctx.Attributes.FirstOrDefault(f => f.Id == attributeId);

            if (attribute == null)
            {
                return HttpStatusCode.NotFound;
            }

            try
            {
                _ctx.Attributes.Remove(attribute);
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
