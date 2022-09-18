using System.Reflection;
using Application.Features.Courses.Rules;
using Application.Utilities.Security.JWT;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationServiceRegister
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<CourseBusinessRules>();
        //validation for MediatR 
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}