using isRock.Template;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//👇add MemoryCache
builder.Services.AddMemoryCache();
builder.Services.AddControllers();

//👇add CacheService
builder.Services.AddScoped<CacheService>();

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
