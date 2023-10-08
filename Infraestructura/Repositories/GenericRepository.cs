using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly FarmacyContext _context;
    public GenericRepository(FarmacyContext context)
    {
        _context = context;
    }

    public virtual async Task<T> GetIdAsync(int id){
        return await _context.Set<T>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(){
        return await _context.Set<T>().ToListAsync();
    }

    public virtual void Add(T entity){
        _context.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities){
        _context.Set<T>().AddRange(entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression){
        return _context.Set<T>().Where(expression);
    }

    public void Remove(T entity){
        _context.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities){
        _context.Set<T>().RemoveRange(entities);
    } 

    public void Update(T entity){
        _context.Set<T>().Update(entity);
    }
}
