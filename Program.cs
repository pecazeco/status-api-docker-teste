var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configuração de CORS para permitir requisições do portal à api
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowPortal",
        policy => policy.AllowAnyOrigin() // Em produção, trocaremos pelo link do S3
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Habilita CORS para a política definida
app.UseCors("AllowPortal");

app.UseAuthorization();

app.MapControllers();

app.Run();
