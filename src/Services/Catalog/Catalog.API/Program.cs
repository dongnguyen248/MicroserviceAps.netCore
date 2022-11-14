using Catalog.API.Data;
using Catalog.API.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ProductStoreDatabaseSetting>(
builder.Configuration.GetSection("ProductStoreDatabase"));
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductContext,ProductStoreDatabaseSetting>();
builder.Logging.AddFile("D:\\MicroserviceAspdotnetCore\\src\\Services\\Catalog\\Catalog.APILogs\\myapp-{Date}.txt");

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
