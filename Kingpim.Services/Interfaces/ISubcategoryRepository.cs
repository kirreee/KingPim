using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Kingpim.Services.Interfaces
{
    public interface ISubcategoryRepository
    {
        List<SubcategoryViewModel> GetAllSubcategories();
        HttpStatusCode CreateSubcategory(CreateSubcategoryDto createSubcategoryDto);
        SubcategoryViewModel GetSubcategoryById(int subcategoryId);
        HttpStatusCode UpdateSubcategory(int subcategoryId, UpdateSubcategoryDto updateSubcategoryDto);
        HttpStatusCode DeleteSubcategory(int subcategoryId);
    }
}
