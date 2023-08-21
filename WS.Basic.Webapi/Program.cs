using System.Reflection;
using WS.Basic.Webapi.Data;
using WS.Basic.Webapi.Mappers;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("BasicConnectionStrings");
builder.Services.AddDbContext<ProductDbContext>(op => op.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(typeof(WebapiProfile).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "WS.Basic.WebApi",
        Description = "Api basica de crud",
        Contact = new OpenApiContact
        {
            Name = "Weslei Moreira",
            Email = "wesleimoreira600@gmail.com",
            Url = new Uri("https://github.com/wesleiMoreira")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
