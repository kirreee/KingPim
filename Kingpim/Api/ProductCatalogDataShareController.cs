using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kingpim.DAL.Models;
using Kingpim.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kingpim.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCatalogDataShareController : ControllerBase
    {
        private readonly ApplicationDbContext _ctx;
        public ProductCatalogDataShareController(ApplicationDbContext context)
        {
            _ctx = context;
        }

        private const string ApiKey = "2fac1d10-5950-4665-b595-ffff273f88cf";

        [HttpGet, Route("GetFullProductData/{apiKey}")]
        public ActionResult GetFullProductData(string apiKey)
        {

            if (apiKey != ApiKey)
            {
                return Unauthorized();
            }

            List<Catalog> catalogs = _ctx.Catalogs.ToList();
            List<Category> categories = new List<Category>();
            List<Subcategory> subcategories = new List<Subcategory>();

            catalogs.ForEach(catalog =>
            {
                categories = _ctx.Categories.Where(x => x.CatalogId == catalog.Id).ToList();

                categories.ForEach(category =>
                {
                    subcategories = _ctx.Subcategories.Where(x => x.CategoryId == category.Id).Include(x => x.Products).ToList();

                    category.Subcategories = subcategories;

                    category.Subcategories.ForEach(subcategory =>
                    {
                        subcategory.SubcategoryAttributes = _ctx.SubcategoryAttributes.Where(x => x.SubcategoryId == subcategory.Id).ToList();

                        subcategory.SubcategoryAttributes.ForEach(subcategoryAttribute =>
                        {
                            subcategoryAttribute.AttributeGroup = _ctx.AttributeGroups.FirstOrDefault(f => f.Id == subcategoryAttribute.Id);
                        });

                    });

                });
            });


            return Ok(catalogs);
        }

        [HttpGet, Route("GetProductaBySubcategoryId/{apiKey}/{subcategoryId}")]
        public ActionResult GetProductsBySubcategoryId(string apiKey, int subcategoryId)
        {

            if (apiKey != ApiKey)
            {
                return Unauthorized();
            }

            Subcategory subcategory = _ctx.Subcategories.FirstOrDefault(f => f.Id == subcategoryId);

            List<Product> products = _ctx.Products.Where(x => x.SubcategoryId == subcategory.Id).ToList();

            subcategory.Products = products;

            return Ok(subcategory);
        }

        [HttpGet, Route("GetProductDataByCategoryId/{apiKey}/{categoryId}")]
        public ActionResult GetProductDataByCategoryId(string apiKey, int categoryId)
        {

            if (apiKey != ApiKey)
            {
                return Unauthorized();
            }

            if (categoryId <= 0)
            {
                return NotFound();
            }

            Category category = _ctx.Categories.FirstOrDefault(f => f.Id == categoryId);
            if (category == null)
            {
                return NotFound();
            }

            List<Subcategory> subcategories = _ctx.Subcategories.Where(x => x.CategoryId == category.Id).ToList();
            subcategories.ForEach(subcategory =>
            {
                subcategory.Products = _ctx.Products.Where(x => x.SubcategoryId == subcategory.Id).ToList();
            });

            category.Subcategories = subcategories;

            return Ok(category);
        }

        [HttpGet, Route("GetProductById/{apiKey}/{productId}")]
        public ActionResult GetProductById(string apiKey, int productId)
        {
            if (apiKey != ApiKey)
            {
                return Unauthorized();
            }

            if (productId <= 0)
            {
                return NotFound();
            }

            Product product = _ctx.Products.FirstOrDefault(f => f.Id == productId);
            if (product == null)
            {
                return NotFound();
            }

            product.Files = _ctx.Files.Where(x => x.ProductId == product.Id).ToList();
            product.Subcategory = _ctx.Subcategories.FirstOrDefault(f => f.Id == product.SubcategoryId);
            product.SystemAttribute = _ctx.SystemAttributes.FirstOrDefault(f => f.Id == product.SystemAttributeId);

            return Ok(product);
        }
    }

}