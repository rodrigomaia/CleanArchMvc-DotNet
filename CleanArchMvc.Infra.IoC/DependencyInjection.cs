using System.Reflection;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {

        services.AddDbContext<ApplicationDbContext>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        services.AddAutoMapper(typeof(DTOToCommandMappingProfile));

        //usando o DTOToCommandMappingProfile pra referenciar o projeto Application
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<DTOToCommandMappingProfile>());

        return services;
    }
}
