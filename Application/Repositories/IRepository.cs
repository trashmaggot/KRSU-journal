using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
}