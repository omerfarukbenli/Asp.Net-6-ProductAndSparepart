using Microsoft.EntityFrameworkCore;
using ProductAndSparepart.Business.Abstract;
using ProductAndSparepart.Business.Concrete;
using ProductAndSparepart.Data.Abstract;
using ProductAndSparepart.Data.Concrete;
using ProductAndSparepart.Data.Context;
using ProductAndSparepart.Data.Map;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DataContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(DataContext)).GetName().Name);
    });
});



builder.Services.AddAutoMapper(typeof(MappingProfile)); //mapin yapýldýðý yer


builder.Services.AddScoped<ISparepartRepository, SparepartRepository>();
builder.Services.AddScoped<ISparepartService, SparepartService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
