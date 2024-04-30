using Microsoft.Extensions.DependencyInjection;
using OffHappit.Application.Contracts;
using OffHappit.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffHappit.Application;

public static class AddApplicationServices
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });

        return services;
    }
}
