using Application.Repositories;
using Domain.Entities;
using Persistence.DataContext;

namespace Persistence.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(Context context) : base(context)
    {
    }
}