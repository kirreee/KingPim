using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kingpim.DAL.Models;
using Kingpim.Data;
using Kingpim.Services.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Kingpim.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {

        private readonly ApplicationDbContext _ctx;
        private readonly ExportHelper _exportHelper;

        public ExportController(ApplicationDbContext context, ExportHelper exportHelper)
        {
            _ctx = context;
            _exportHelper = exportHelper;
        }

        [HttpGet, Route("ExportFullCatalog/{catalogId}")]
        public ActionResult ExportCatalog(int catalogId)
        {
            Catalog catalog = _ctx.Catalogs.FirstOrDefault(f => f.Id == catalogId);

            catalog.Categories = _ctx.Categories.Where(x => x.CatalogId == catalog.Id).ToList();

            catalog.Categories.ForEach(category =>
            {
                category.Subcategories = _ctx.Subcategories.Where(x => x.CategoryId == category.Id).ToList();

                category.Subcategories.ForEach(subcategory =>
                {
                    subcategory.Products = _ctx.Products.Where(x => x.SubcategoryId == subcategory.Id).ToList();
                });

            });

            var result = _exportHelper.ExportDataJson(catalog, null, null);

            return Ok(result);
        }

        [HttpGet, Route("ExportFullCategory/{categoryId}")]
        public ActionResult ExportFullCategory(int categoryId)
        {
            Category category = _ctx.Categories.FirstOrDefault(f => f.Id == categoryId);
            category.Subcategories = _ctx.Subcategories.Where(x => x.CategoryId == category.Id).ToList();

            category.Subcategories.ForEach(subcategory =>
            {
                subcategory.Products = _ctx.Products.Where(x => x.SubcategoryId == subcategory.Id).ToList();
            });

            var result = _exportHelper.ExportDataJson(null, category, null);

            return Ok(result);
        }

        [HttpGet, Route("ExportFullSubcategory/{subcategoryId}")]
        public ActionResult ExportFullSubcategory(int subcategoryId)
        {
            Subcategory subcategory = _ctx.Subcategories.FirstOrDefault(f => f.Id == subcategoryId);
            subcategory.Products = _ctx.Products.Where(x => x.SubcategoryId == subcategory.Id).ToList();

            var result = _exportHelper.ExportDataJson(null, null, subcategory);

            return Ok(result);
        }
    }
}