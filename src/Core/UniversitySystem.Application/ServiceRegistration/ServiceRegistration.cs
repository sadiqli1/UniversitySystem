using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using UniversitySystem.Application.DTOs.Sector;
using UniversitySystem.Application.Mapping;

namespace UniversitySystem.Application.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new GeneralMap());
            });
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssemblyContaining<SectorPostDto>();
        }
    }
}
