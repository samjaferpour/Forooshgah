using Forooshgah.Dtos;

namespace Forooshgah.Services
{
    public interface IProductServices
    {
        Task<AddProductResponse> AddProduct(AddProductRequest addProductRequest);
    }
}
