namespace RendaFixaExpert.App.ConfiguracaoExtensions
{
    public partial class ServiceCollection
    {
        public static IServiceCollection AddDependenciasNegocio(this IServiceCollection services)
        {
            services.AddTransient<ICalculosInvestimentos, InvestimentoPresenterServices>();
            services.AddControllers().AddJsonOptions(x => { x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
            return services;
        }
    }
}
