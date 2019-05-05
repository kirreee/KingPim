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
    public class AttributeGroupRepository : IAttributeGroupRepository
    {
        private readonly ApplicationDbContext _ctx;
        public AttributeGroupRepository(ApplicationDbContext context)
        {
            _ctx = context;
        }

        public List<AttributeGroupViewModel> GetAllAttributeGroups()
        {
            List<AttributeGroup> attributeGroups = _ctx.AttributeGroups.ToList();
            List<AttributeGroupViewModel> attributeGroupViewModel = new List<AttributeGroupViewModel>();

            attributeGroups.ForEach(attributeGroup =>
            {
                attributeGroupViewModel.Add(AttributeGroupFactory.AttributeGroupToViewModel(attributeGroup));
            });

            return attributeGroupViewModel;
        }

        public AttributeGroupViewModel GetAttributeGroupById(int attributeGroupId)
        {
            AttributeGroup attributeGroup = _ctx.AttributeGroups.FirstOrDefault(f => f.Id == attributeGroupId);
            AttributeGroupViewModel attributeGroupViewModel = AttributeGroupFactory.AttributeGroupToViewModel(attributeGroup);

            return attributeGroupViewModel;
        }

        public HttpStatusCode CreateAttributeGroup(CreateAttributeGroupDto createAttributeGroupDto)
        {
            AttributeGroup attributeGroup = AttributeGroupFactory.AttributeGroupToDbo(createAttributeGroupDto);

            try
            {
                _ctx.AttributeGroups.Add(attributeGroup);
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public HttpStatusCode DeleteAttributeGroup(int attributeGroupId)
        {
            AttributeGroup attributeGroup = _ctx.AttributeGroups.FirstOrDefault(f => f.Id == attributeGroupId);
            try
            {
                _ctx.AttributeGroups.Remove(attributeGroup);
                _ctx.SaveChanges();

                return HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                return HttpStatusCode.InternalServerError;
            }
        }

        public HttpStatusCode UpdateAttributeGroup(int attributeGroupId, UpdateAttributeGroupDto updateAttributeGroupDto)
        {
            if(attributeGroupId <= 0)
            {
                return HttpStatusCode.NotFound;
            }

            AttributeGroup attributeGroup = _ctx.AttributeGroups.FirstOrDefault(f => f.Id == attributeGroupId);
            attributeGroup.Name = updateAttributeGroupDto.AttributeGroupName;
            attributeGroup.LastModifiedDate = DateTime.Now;

            try
            {
                _ctx.Entry(attributeGroup).State = EntityState.Modified;
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
