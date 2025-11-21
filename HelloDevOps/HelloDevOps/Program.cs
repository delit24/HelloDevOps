using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hello DevOps API",
        Version = "v1",
        Description = "A simple ASP.NET Core Web API for DevOps demonstration",
        Contact = new OpenApiContact
        {
            Name = "DevOps Team"
        }
    });
});
var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
