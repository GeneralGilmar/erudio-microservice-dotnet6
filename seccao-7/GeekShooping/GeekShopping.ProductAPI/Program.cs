using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.ProductAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


/*builder.Services.AddDbContext<MySqlContext>(
    //options => options.UseMySql(builder.Configuration.GetConnectionString("MySQlConnectionString"),
    new MySqlServerVersion( new Version(8,0,34)))
    );*/
builder.Services.AddDbContext<MySqlContext>(opts =>{ opts.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c=> c.SwaggerDoc("v1", new OpenApiInfo { Title ="GeekShopping.ProductAPI", Version="v1"})
    );

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
