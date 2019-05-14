using Kingpim.Services.Dtos;
using Kingpim.Services.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Kingpim.Services.Interfaces
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(int productId);
        HttpStatusCode CreatProduct(CreateProductDto createProductDto);
        HttpStatusCode DeleteProduct(int productId);
        HttpStatusCode UpdateProduct(int productId, UpdateProductDto updateProductDto, string userId);
        HttpStatusCode FileUpload(IFormFile file, int productId);

    }
}
