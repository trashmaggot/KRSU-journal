using Application.Repositories;
using Domain.Entities;
using Persistence.DataContext;

namespace Persistence.Repositories;

public class GroupRepository : Repository<Group>, IGroupRepository
{
    public GroupRepository(Context context) : base(context)
    {
    }
}