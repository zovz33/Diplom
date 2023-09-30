﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using PrimeTableware.ASPNET.Application.Common.Behaviours;
using MediatR;

namespace PrimeTableware.ASPNET.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services) 
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
