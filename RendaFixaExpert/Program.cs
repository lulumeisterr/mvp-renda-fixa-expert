var builder = WebApplication.CreateBuilder(args);

//Configuração de injeção de dependencias dos servicos.

builder.Services.AddDependenciasNegocio();
builder.AddOpenAPI(); //Swagger Extensions
builder.Services.AddCorsCollection();

var app = builder.Build();
app.UseRouting();
app.UseCollectionCors();
app.MapControllers();
app.UseOpenSwagger();
app.Run();