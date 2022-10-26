using catalog.API.data;
using catalog.API.repository;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine(builder.Configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
Console.WriteLine(builder.Configuration.GetValue<string>("ElasticConfiguration:Uri"));

// Add services to the container.
builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
