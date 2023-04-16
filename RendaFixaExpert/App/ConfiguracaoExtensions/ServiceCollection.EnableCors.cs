namespace RendaFixaExpert.App.ConfiguracaoExtensions
{
    public partial class ServiceCollection
    {
        public static IServiceCollection AddCorsCollection(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
            return services;
        }

        public static IApplicationBuilder UseCollectionCors(this IApplicationBuilder app)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );
            return app;
        }
    }
}
