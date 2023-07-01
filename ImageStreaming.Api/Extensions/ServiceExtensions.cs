using System;
using ImageStreaming.Api.Mappings;
using ImageStreaming.Application.Common.Interfaces;
using ImageStreaming.Application.Services;
using ImageStreaming.Infrastructure.Common;
using ImageStreaming.Infrastructure.Common.Interfaces;
using ImageStreaming.Infrastructure.Repositories;
using ImageStreaming.Shared.Persistence.Common;
using ImageStreaming.Shared.Persistence.Common.Interfaces.Repositories;
using ImageStreaming.Shared.Persistence.Common.Interfaces.Services;
using ImageStreaming.Shared.Persistence.Repositories;
using ImageStreaming.Shared.Persistence.Services;

namespace ImageStreaming.Api.Extensions
{
	public static class ServiceExtensions
	{
        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryDbContext>();
            // Base units
            services.AddScoped<BaseDbContext, InMemoryDbContext>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Services
            services.AddScoped<IImageService, ImageService>();

            // Repositories
            services.AddScoped<IImageRepository, ImageRepository>();

            // Auto Mapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}

