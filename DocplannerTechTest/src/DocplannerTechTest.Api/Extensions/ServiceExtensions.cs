using DocplannerTechTest.Application.Interfaces;
using DocplannerTechTest.Application.Services;
using Microsoft.OpenApi.Models;

namespace DocplannerTechTest.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Application.Utils.AssemblyUtils.GetApplicationAssembly()));
            services.AddScoped<ISlotService, SlotService>();
        }

        public static void AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DocplannerTechTest API", Version = "v1" });
            });
        }

        public static void AddInfrastructureServices(this IServiceCollection services) { }
    }
}