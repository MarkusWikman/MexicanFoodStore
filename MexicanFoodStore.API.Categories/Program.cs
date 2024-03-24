using AutoMapper;
using MexicanFoodStore.Data.Services;
using Microsoft.EntityFrameworkCore.Internal;

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
    app.AddEndpoint<Category, CategoryPostDTO, CategoryPutDTO, CategoryGetDTO>();
}
void RegisterServices()
{
    ConfigureAutoMapper();
    builder.Services.AddScoped<IDbService, CategoryDbService>();
}
void ConfigureAutoMapper()
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Category, CategoryPostDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryPutDTO>().ReverseMap();
        cfg.CreateMap<Category, CategoryGetDTO>().ReverseMap();
        cfg.CreateMap<Category, CategorySmallGetDTO>().ReverseMap();
        cfg.CreateMap<ProductCategory, ProductCategoryDTO>().ReverseMap();
    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}