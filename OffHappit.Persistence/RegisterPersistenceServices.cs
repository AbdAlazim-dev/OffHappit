using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OffHappit.Application.Contracts;
using OffHappit.Application.Services;
using OffHappit.Persistence.DbContexts;
using OffHappit.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Persistence;

public static class RegisterPersistenceServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OffHappitsDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BassRepository<>));
        services.AddScoped<IAuthenticateRepository, AuthenticateRerpository>();
        services.AddScoped<IAuthServices, AuthServices>();

        return services;
    }
}
