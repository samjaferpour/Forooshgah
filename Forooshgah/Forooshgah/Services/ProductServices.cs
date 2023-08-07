using Forooshgah.Dtos;
using Forooshgah.Entities;
using Microsoft.AspNetCore.Http;
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
    }
}
