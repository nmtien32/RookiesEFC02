using RookiesEFC02.Models;
using RookiesEFC02.Repositories;
using RookiesEFC02.Repositories.Interfaces;
using RookiesEFC02.DTOs.Product;
using RookiesEFC02.Services.Interfaces;

namespace RookiesEFC02.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public AddProductResponse Create(AddProductRequest createModel)
        {
            using (var transaction = _productRepository.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepository.Get(s => s.Id == createModel.CategoryId);

                    if (category != null)
                    {
                        var createProduct = new Product
                        {
                            ProductName = createModel.ProductName,
                            Manufacturer = createModel.Manufacturer,
                            CategoryId = category.Id,
                        };
                        var product = _productRepository.Create(createProduct);

                        _productRepository.SaveChanges();
                        transaction.Commit();

                        return new AddProductResponse
                        {
                            ProductId = product.Id,
                            ProductName = product.ProductName,
                            Manufacturer = product.Manufacturer,
                            CategoryId = product.CategoryId
                        };
                    }
                    return null;
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var transaction = _productRepository.DatabaseTransaction())
            {
                try
                {
                    var deleteProduct = _productRepository.Get(p => p.Id == id);

                    if (deleteProduct != null)
                    {
                        bool result = _productRepository.Delete(deleteProduct);

                        _productRepository.SaveChanges();

                        transaction.Commit();
                        return result;
                    }
                    return false;
                }
                catch
                {
                    transaction.RollBack();
                    return false;
                }
            }
        }

        public IEnumerable<GetProductResponse> GetAll()
        {
            var listProduct = _productRepository.GetAll(p => true)
            .Select(product => new GetProductResponse
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Manufacturer = product.Manufacturer,
                CategoryId = product.CategoryId
            });
            return listProduct;
        }

        public GetProductResponse GetById(int id)
        {
            var requestProduct = _productRepository.Get(p => p.Id == id);

            if (requestProduct != null)
            {
                return new GetProductResponse
                {
                    ProductId = requestProduct.Id,
                    ProductName = requestProduct.ProductName,
                    Manufacturer = requestProduct.Manufacturer,
                    CategoryId = requestProduct.CategoryId
                };
            }
            return null;
        }

        public UpdateProductResponse Update(int id, UpdateProductRequest updateModel)
        {
            using (var transaction = _productRepository.DatabaseTransaction())
            {
                try
                {
                    var product = _productRepository.Get(p => p.Id == id);

                    if (product != null)
                    {
                        var category = _categoryRepository.Get(c => c.Id == updateModel.CategoryId);

                        if (category != null)
                        {
                            product.ProductName = updateModel.ProductName;
                            product.Manufacturer = updateModel.Manufacturer;
                            product.CategoryId = updateModel.CategoryId;

                            var updatedProduct = _productRepository.Update(product);

                            _productRepository.SaveChanges();
                            transaction.Commit();

                            return new UpdateProductResponse
                            {
                                ProductId = updatedProduct.Id,
                                ProductName = updatedProduct.ProductName,
                                Manufacturer = updatedProduct.Manufacturer,
                                CategoryId = updatedProduct.CategoryId
                            };
                        }
                        return null;
                    }
                    return null;
                }
                catch
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }
    }
}