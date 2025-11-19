using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minha API de Exemplo",
        Version = "v1",
        Description = "API de exemplo com Swagger no .NET",
        Contact = new OpenApiContact
        {
            Name = "Douglas",
            Email = "bydouglascontato@gmail.com"
        }
    });
});

var app = builder.Build();



//Console.WriteLine("IsDevelopment: ", app.Environment.IsDevelopment());

// Middleware do Swagger (apenas em desenvolvimento)
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1");
        c.RoutePrefix = string.Empty; // Deixa o Swagger em "/"
    });
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.Urls.Add("http://*:80");

app.MapControllers();

app.Run();
