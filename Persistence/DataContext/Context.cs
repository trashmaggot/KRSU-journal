using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DataContext;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public DbSet<Order> Orders { get; set; }
}