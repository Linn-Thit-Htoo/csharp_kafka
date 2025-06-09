using csharp_kafka.Producer.Configurations;
using csharp_kafka.Producer.Features.Product.CreateProduct;

namespace csharp_kafka.Producer.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependencies(
        this IServiceCollection services,
        WebApplicationBuilder builder
    )
    {
        builder
            .Configuration.SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile(
                $"appsettings.{builder.Environment.EnvironmentName}.json",
                optional: false,
                reloadOnChange: true
            )
            .AddEnvironmentVariables();

        builder
            .Services.AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<CreateProductService>();
        builder.Services.AddHealthChecks();
        builder.Services.Configure<AppSetting>(builder.Configuration);

        return services;
    }
}
