using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UniversitySystem.Application.DTOs.Sector;
using UniversitySystem.Application.Mapping;

namespace UniversitySystem.Application.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServiceRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new GeneralMap());
            });
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssemblyContaining<SectorPostDto>();
            services.AddMediatR(assembly);
        }
    }
}
