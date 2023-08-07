using Forooshgah.Dtos;
using Forooshgah.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forooshgah.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            this._productServices = productServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm]AddProductRequest addProductRequest)
        {
            var response = await _productServices.AddProduct(addProductRequest);
            return Ok(response);
        }
    }
}
