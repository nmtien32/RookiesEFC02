using Microsoft.EntityFrameworkCore;
using RookiesEFC02.Data;
using RookiesEFC02.Repositories.Interfaces;
using System.Linq.Expressions;

namespace RookiesEFC02.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    private readonly ProductContext _context;
    public BaseRepository(ProductContext context)
    {
        _dbSet = context.Set<T>();
        _context = context;
    }

    public T Create(T entity)
    {
        return _dbSet.Add(entity).Entity;
    }

    public IDatabaseTransaction DatabaseTransaction()
    {
        return new EntityDatabaseTransaction(_context);
    }

    public bool Delete(T entity)
    {
        _dbSet.Remove(entity);

        return true;
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return predicate == null ? _dbSet.FirstOrDefault() : _dbSet.FirstOrDefault(predicate);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        return predicate == null ? _dbSet : _dbSet.Where(predicate);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public T Update(T entity)
    {
        return _dbSet.Update(entity).Entity;
    }
}