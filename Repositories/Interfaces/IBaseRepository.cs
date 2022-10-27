using System.Linq.Expressions;
using RookiesEFC02.Repositories.Interfaces;

namespace RookiesEFC02.Repositories;

public interface IBaseRepository<T> where T : class
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    T? Get(Expression<Func<T, bool>> predicate);
    T Create(T entity);
    T Update(T entity);
    bool Delete(T entity);
    int SaveChanges();
    IDatabaseTransaction DatabaseTransaction();
}