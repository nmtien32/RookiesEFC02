using Microsoft.AspNetCore.Mvc;
using RookiesEFC02.DTOs.Product;
using RookiesEFC02.Services.Interfaces;

namespace RookiesEFC02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public AddProductResponse? Add([FromBody] AddProductRequest addProductRequest)
        {
            return _productService.Create(addProductRequest);
        }

        [HttpGet]
        public IEnumerable<GetProductResponse> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet("{id}")]
        public GetProductResponse? GetById(int id)
        {
            return _productService.GetById(id);
        }

        [HttpPut("{id}")]
        public UpdateProductResponse? Update(int id, [FromBody] UpdateProductRequest updateProductRequest)
        {
            return _productService.Update(id, updateProductRequest);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _productService.Delete(id);
        }
    }
}