var builder = WebApplication.CreateBuilder(args);

//Configuração de injeção de dependencias dos servicos.
builder.Services.AddDependenciasNegocio();
builder.AddOpenAPI(); //Swagger Extensions

var app = builder.Build();
app.MapControllers();
app.UseOpenSwagger();
app.Run();