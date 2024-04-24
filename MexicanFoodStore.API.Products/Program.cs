using AutoMapper;
using MexicanFoodStore.Data.Contexts;
using MexicanFoodStore.Data.Entities;
using MexicanFoodStore.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MexicanFoodStore.API.DTO.DTOs;
using MexicanFoodStore.API.Extensions.Extensions;
using MexicanFoodStore.API.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MexicanFoodStoreContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("MexicanFoodStoreConnection")));

// CORS Cross-Origin Resource Sharing
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsAllAccessPolicy", opt =>
    opt.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    );
});

RegisterServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


RegisterEndpoints();

app.UseCors("CorsAllAccessPolicy");


app.Run();
void RegisterEndpoints()
{
    app.AddEndpoint<Product, ProductPostDTO, ProductPutDTO, ProductGetDTO>();
    app.MapGet($"/api/productsbycategory/{{categoryId}}", async (IDbService db, int categoryId) =>
    {
        try
        {
            var result = await ((ProductDbService)db).GetProductsByCategoryAsync(categoryId);
            return Results.Ok(result);
        }
        catch
        {
        }
        return Results.BadRequest($"Couldn't get the requested products of type {typeof(Product).Name}.");
    });
}
void RegisterServices()
{
    ConfigureAutoMapper();
    builder.Services.AddScoped<IDbService, ProductDbService>();
}
void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Product, ProductPostDTO>().ReverseMap();
        cfg.CreateMap<Product, ProductPutDTO>().ReverseMap();
        cfg.CreateMap<Product, ProductGetDTO>().ReverseMap();
        cfg.CreateMap<ProductCategory, ProductCategoryDTO>().ReverseMap();

    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}