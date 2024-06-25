using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DataContext;
using Persistence.Repositories;

namespace Persistence.Extensions;

public static class PersistenceConfiguration
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("db-connection");
        services.AddDbContext<Context>(opt => opt.UseNpgsql(connectionString));

        services.AddScoped<IOrderRepository,      OrderRepository>();
        services.AddScoped<IStudentRepository,    StudentRepository>();
        services.AddScoped<IAttendanceRepository, AttendanceRepository>();
        services.AddScoped<ICourseRepository,     CourseRepository>();
        services.AddScoped<IGroupRepository,      GroupRepository>();
        services.AddScoped<ILessonRepository,     LessonRepository>();
    }
}