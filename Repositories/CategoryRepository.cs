using RookiesEFC02.Data;
using RookiesEFC02.Models;

namespace RookiesEFC02.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductContext context) : base(context)
        {
        }
    }
}