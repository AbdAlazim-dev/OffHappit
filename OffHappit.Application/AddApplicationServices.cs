using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OffHappit.Application.Contracts;
using OffHappit.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OffHappit.Application.Services.AuthServices;

namespace OffHappit.Application;

public static class AddApplicationServices
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });

        services.AddScoped<IAuthServices, AuthServices>();
        return services;
    }
}
