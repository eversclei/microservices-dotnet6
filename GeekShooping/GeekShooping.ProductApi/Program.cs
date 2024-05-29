

using AutoMapper;
using GeekShopping.ProductApi.Config;
using GeekShopping.ProductApi.Model.Context;
using GeekShopping.ProductApi.Repository;
using GeekShopping.ProductApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["ConnectionString:DefaultConnection"];
builder.Services.AddDbContext<SqlServerContext>(options =>
    options.UseSqlServer(connectionString));

IMapper mapper = MappingConfig.ResgisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Geek store", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
