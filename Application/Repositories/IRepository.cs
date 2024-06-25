using System.Linq.Expressions;
using Domain.Common;

namespace Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    IQueryable<T> GetAll();
    IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

}