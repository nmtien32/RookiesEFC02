using RookiesEFC02.Data;
using RookiesEFC02.Models;
using RookiesEFC02.Repositories.Interfaces;

namespace RookiesEFC02.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
        }
    }
}