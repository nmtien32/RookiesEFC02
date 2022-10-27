using RookiesEFC02.DTOs.Product;

namespace RookiesEFC02.Services.Interfaces
{
    public interface IProductService
    {
        AddProductResponse Create(AddProductRequest createModel);
        IEnumerable<GetProductResponse> GetAll();
        GetProductResponse GetById(int id);
        UpdateProductResponse Update(int id, UpdateProductRequest updateModel);
        bool Delete(int id);
    }
}