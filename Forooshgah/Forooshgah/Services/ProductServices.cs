using Forooshgah.Common;
using Forooshgah.Dtos;
using Forooshgah.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace Forooshgah.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ForooshgahDbContext _context;
        private readonly IFileServices _fileServices;

        public ProductServices(ForooshgahDbContext context,
                               IFileServices fileServices)
        {
            this._context = context;
            this._fileServices = fileServices;
        }
        public async Task<AddProductResponse> AddProduct(AddProductRequest addProductRequest)
        {
            var uploadFileRresponse = await _fileServices.UploadFile(new UploadFileRequest
            {
                File = addProductRequest.Image
            });
            var product = new Product
            {
                Name = addProductRequest.Name,
                Price = addProductRequest.Price,
                Description = addProductRequest.Description,
                ImageName = uploadFileRresponse.FileId
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return new AddProductResponse
            {
                ProductId = product.Id,
            };
        }

        public async Task<List<GetAllProductsResponse>> GetAllProducts()
        {
            var responses = new List<GetAllProductsResponse>();
            var products = await _context.Products.ToListAsync();
            foreach ( var product in products)
            {
                responses.Add(new GetAllProductsResponse
                {
                    Name= product.Name,
                    Price= product.Price,
                    Description = product.Description,
                    ImageBytes = Utility.ImageToBase64(Path.Combine(Directory.GetCurrentDirectory(), "Uploads", product.ImageName))
                });
            }
            return responses;
        }
    }
}
