using RatingDadJokes.Data.Service;
using RatingDadJokes.Shared.Discovery;
using RatingDadJokesAPI.Exceptions;
using RatingDadJokesAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddLogging(config =>
{
    config.AddConsole();
    config.AddDebug();
});
builder.Services.AddTransient<CustomExceptionHandler>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRatingJokesDataService(builder.Configuration);
builder.Services.AddDiscovery(builder.Configuration);
builder.Services.AddSecretManager(builder.Configuration);
builder.Services.AddDadJokesIoDataProvider(builder.Configuration);
builder.Services.AddRedisCacheProvider(builder.Configuration);

var app = builder.Build();
app.UseCors(corsBuilder =>
{
    corsBuilder.WithOrigins(builder.Configuration.GetSection("AllowedHosts").Value ?? "*")
    .AllowAnyHeader()
    .AllowAnyMethod();
});

app.UseMiddleware<CustomExceptionHandler>();

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